use MycommAppDb
select * from orders
---problem 1
CREATE PROCEDURE sp_GetTotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_id,
        s.store_name,
        SUM(ISNULL(oi.quantity * oi.list_price * (1 - oi.discount),0)) AS total_sales
    FROM stores s
    JOIN orders o 
        ON s.store_id = o.store_id
    JOIN order_items oi 
        ON o.order_id = oi.order_id
    GROUP BY s.store_id, s.store_name
    ORDER BY total_sales DESC;
END;

EXEC sp_GetTotalSalesPerStore
CREATE PROCEDURE sp_GetOrdersByDateRange
@StartDate DATE,
@EndDate DATE
AS
BEGIN
  SELECT
    o.order_id,
	o.order_date
  FROM 
  orders o
  WHERE o.order_date BETWEEN @StartDate AND @EndDate
  ORDER BY o.order_date
END

EXEC sp_GetOrdersByDateRange
    @StartDate='2017-01-01',
	@EndDate='2018-04-14';

CREATE FUNCTION fn_TotalPrice
(
  @price DECIMAL(10,2),
  @quantity INT,
  @discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
 DECLARE @total DECIMAL(10,2)
 SET @discount=ISNULL(@discount,0)
 SET @total=(@price * @quantity) * (1-@discount)
 RETURN @total
END

SELECT dbo.fn_TotalPrice(1000,2,0.10) AS TotalAmount;

CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_id,
        p.product_name,
        SUM(oi.quantity) AS total_quantity_sold
    FROM products p
    JOIN order_items oi
        ON p.product_id = oi.product_id
    GROUP BY p.product_id, p.product_name
    ORDER BY total_quantity_sold DESC
);
SELECT * 
FROM dbo.fn_Top5SellingProducts();

--problem 2--
CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        -- Check if stock is sufficient
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN stocks s
            ON i.product_id = s.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR('Stock is insufficient for one or more products.',16,1)
            ROLLBACK TRANSACTION
            RETURN
        END

        -- Reduce stock quantity
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id

    END TRY

    BEGIN CATCH

        RAISERROR('Error occurred while updating stock.',16,1)
        ROLLBACK TRANSACTION

    END CATCH
END
INSERT INTO order_items(item_id,order_id,product_id,quantity,list_price,discount)
VALUES(10000,9,50,5,400,0)

select * from order_items
---problem 3
CREATE TRIGGER trg_ValidateShippedDate
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY
        
        IF EXISTS (
            SELECT 1
            FROM inserted
            WHERE order_status = 4 
            AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR('Shipped date cannot be NULL when order status is 4.',16,1);
            ROLLBACK TRANSACTION;
        END

    END TRY

    BEGIN CATCH
        RAISERROR('Error occurred while updating order.',16,1);
        ROLLBACK TRANSACTION;
    END CATCH
END;

UPDATE orders
SET order_status = 4, shipped_date = NULL
WHERE order_id = 1;

--problem 4--
BEGIN TRY
BEGIN TRANSACTION;

CREATE TABLE #Revenue
(
    order_id INT,
    store_id INT,
    revenue DECIMAL(10,2)
);

DECLARE @order_id INT, @store_id INT, @rev DECIMAL(10,2);

DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4;

OPEN order_cursor;

FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

WHILE @@FETCH_STATUS = 0
BEGIN

    SELECT @rev = SUM(quantity * list_price * (1 - ISNULL(discount,0)))
    FROM order_items
    WHERE order_id = @order_id;

    INSERT INTO #Revenue VALUES(@order_id,@store_id,ISNULL(@rev,0));

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id;
END

CLOSE order_cursor;
DEALLOCATE order_cursor;

SELECT store_id, SUM(revenue) AS total_revenue
FROM #Revenue
GROUP BY store_id;

COMMIT TRANSACTION;
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION;
PRINT ERROR_MESSAGE();
END CATCH;