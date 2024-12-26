
USE ProductDB;

-- Step 3: Create the 'products' table
CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incremented primary key
    product_name VARCHAR(255) NOT NULL,         -- Product name (cannot be NULL)
    is_recyclable BIT NOT NULL,             -- Boolean for recyclable status
    is_low_fat BIT NOT NULL                 -- Boolean for low-fat status
);
-- Step 4: Insert sample data into the products table
INSERT INTO products (product_name, is_recyclable, is_low_fat)
VALUES 
('Product A', 1, 1),  -- 1 for TRUE
('Product B', 1, 0),  -- 1 for TRUE, 0 for FALSE
('Product C', 0, 1),  -- 0 for FALSE, 1 for TRUE
('Product D', 1, 1);  -- 1 for TRUE


-- Step 5: Query to retrieve recyclable and low-fat products
SELECT product_id, product_name
FROM products
WHERE is_recyclable = 1 AND is_low_fat = 1;
