# Answer 
```sql
SELECT p.name as 'Product name', c.name AS 'Category name'
FROM products p
LEFT JOIN product_categories pc ON p.id = pc.product_id
LEFT JOIN categories c ON c.id = pc.category_id
```

# Tables 
```sql
CREATE TABLE products(
  id INT IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(100) 
);
```

```sql
CREATE TABLE categories(
  id INT IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(100) 
);
```

```sql
CREATE TABLE product_categories(
  id INT IDENTITY(1,1) PRIMARY KEY,
  product_id INT,
  FOREIGN KEY(product_id) REFERENCES products(id),
  category_id INT,
  FOREIGN KEY(category_id) REFERENCES categories(id)
);
```