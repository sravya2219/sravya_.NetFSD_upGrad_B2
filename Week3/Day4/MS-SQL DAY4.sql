---problem 1
use MycommAppDb
USE MycommAppDb;

SELECT 
   product_name + '(' + CAST(model_year AS VARCHAR) + ')' AS product_details,
   product_name,
   list_price,
   list_price - (
        SELECT AVG(list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
   ) AS price_difference
FROM products p1
WHERE list_price > (
      SELECT AVG(list_price)
      FROM products p2
      WHERE p2.category_id = p1.category_id
);

-- problem 2

SELECT 
    c.customer_id,
    c.first_name + ' ' + c.last_name AS full_name,
    total_value,
    CASE 
        WHEN total_value > 10000 THEN 'Premium'
        WHEN total_value BETWEEN 5000 AND 10000 THEN 'Regular'
        WHEN total_value < 5000 THEN 'Basic'
    END AS customer_category
FROM customers c
JOIN (
        SELECT 
            o.customer_id,
            SUM(oi.quantity * oi.list_price) AS total_value
        FROM orders o
        JOIN order_items oi
        ON o.order_id = oi.order_id
        GROUP BY o.customer_id
     ) AS order_totals
ON c.customer_id = order_totals.customer_id

UNION

-- Customers who have NOT placed orders
SELECT 
    c.customer_id,
    c.first_name + ' ' + c.last_name AS full_name,
    ISNULL(NULL,0) AS total_value,
    'No Orders' AS customer_category
FROM customers c
WHERE c.customer_id NOT IN (
        SELECT customer_id
        FROM orders
);

---problem 3

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue
FROM stores s
JOIN orders o 
    ON s.store_id = o.store_id
JOIN order_items oi 
    ON o.order_id = oi.order_id
JOIN products p 
    ON oi.product_id = p.product_id
GROUP BY s.store_name, p.product_name;