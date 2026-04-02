---problem 1

select first_name,last_name,order_id,order_date,order_status from customers
inner join orders on customers.customer_id=orders.customer_id 
where order_status= 1 or order_status=4
order by order_date desc

--problem 2

select p.product_name, b.brand_name, c.category_name, p.model_year,p.list_price from products p
inner join brands b
on p.brand_id=b.brand_id 
inner join categories c
on p.category_id=c.category_id
where list_price>500
order by list_price asc

--problem 3

select s.store_name, sum(oi.quantity * oi.list_price * (1-oi.discount)) as total_sales
from stores s
inner join orders o
on s.store_id=o.store_id
inner join order_items oi
on o.order_id=oi.order_id
where o.order_status=4
group by s.store_name
order by total_sales desc

--problem 4

select p.product_name
from products p
order by p.product_name asc