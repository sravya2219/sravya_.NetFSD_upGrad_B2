use MycommAppDb
create view vw_Products
AS
SELECT
  p.product_name,
  b.brand_name,
  c.category_name,
  p.model_year,
  p.list_price
FROM
products p
join brands b
on b.brand_id=p.brand_id
join categories c
on c.category_id=p.category_id

select * from vw_Products
---create view for orderdetails
CREATE VIEW vw_Order_Details
AS
SELECT 
    o.order_id,
    o.order_date,
    c.first_name + ' ' + c.last_name AS customer_name,
    s.store_name,
    st.first_name + ' ' + st.last_name AS staff_name,
    o.order_status
FROM orders o
JOIN customers c 
    ON o.customer_id = c.customer_id
JOIN stores s 
    ON o.store_id = s.store_id
JOIN staffs st 
    ON o.staff_id = st.staff_id;
select * from vw_Order_Details

---create indexs
create index idx_products_brand_id
on products(brand_id)
create index idx_products_category_id
on products(category_id)
create index idx__brand_id
on products(brand_id)

