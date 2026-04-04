
use MycommAppDb
select * from customers

---- problem 1
SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM customers c
INNER JOIN orders o
    ON c.customer_id = o.customer_id
WHERE o.order_status IN (1, 4)  -- 1: Pending, 4: Completed
ORDER BY o.order_date DESC;
--- problem 2
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b
    ON p.brand_id = b.brand_id
INNER JOIN categories c
    ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;


-- problem3

SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price) AS total_sales
FROM stores s
INNER JOIN orders o
    ON s.store_id = o.store_id
INNER JOIN order_items oi
    ON o.order_id = oi.order_id
WHERE o.order_status = 4  -- Completed orders only
GROUP BY s.store_name
ORDER BY total_sales DESC;


---problem 4

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS stock_quantity,
    COALESCE(SUM(oi.quantity), 0) AS total_quantity_sold
FROM stocks st
LEFT JOIN order_items oi
    ON st.product_id = oi.product_id AND st.store_id = oi.order_id
INNER JOIN products p
    ON st.product_id = p.product_id
INNER JOIN stores s
    ON st.store_id = s.store_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;