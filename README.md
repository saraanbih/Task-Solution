# 1. Authentication System 🔐

This is a simple user registration and authentication system built using **C#** and **SQL Server**. The system allows users to:

- **Register** with a `username`, `email`, and `password`.
- **Login** using their `email` and `password`.
- The system performs **email validation** and checks for **duplicate emails** during registration.

## Features 🚀

### 1. **User Registration**:
   - Users can create an account by entering their `username`, `email`, and `password`. 📝
   - **Email validation** ensures that the entered email is in the correct format. 📧✅
   - The system checks if the email already exists in the database before allowing registration. 🔒
   - Users have **3 attempts** to enter a valid email and **3 attempts** to provide a unique email if the one entered already exists. ⏳
   
### 2. **User Authentication (Login)**:
   - Registered users can log in using their **email** and **password**. 🔑
   - The password is securely **hashed** using **SHA256** before storing and checking it during login. 🔐
   - If the email or password is incorrect, the login attempt is denied. ❌

### 3. **Security**:
   - Passwords are hashed using **SHA256** for better security. 🔒
   - The system validates the format of the **email** during registration and login to prevent invalid inputs. ⚠️

## Technologies Used 🛠️

- **Backend**: C# (.NET)
- **Database**: SQL Server 🗃️
- **Password Hashing**: SHA256 🔐
- **Email Validation**: Regex 📧

---

# 2. Problem Solving 💡

### 1. **Increment and Decrement Challenge (C#)**

#### Problem Overview

This C# program accepts a list of operations, either `++` or `--`, and calculates the final result after applying each operation sequentially.

- **Input**: A list of operations (e.g., `["++", "++", "--", "++"]`)
- **Output**: The final result (e.g., `2`)

#### Example

- Starting with **0**:
  - `++` increases the number to **1**.
  - `++` increases the number to **2**.
  - `--` decreases the number to **1**.
  - `++` increases the number to **2**.

**Final Result**: `2`

---

# 3. **SQL Query Challenge**

#### Problem Overview

I wrote an SQL query to retrieve the `product_id` and `product_name` of all products that are **both recyclable** and **low-fat**. 🌱♻️

The problem involves selecting products from a database with the following schema:

| Column       | Data Type |
|--------------|-----------|
| product_id   | INT       |
| product_name | VARCHAR   |
| is_recyclable| BOOLEAN   |
| is_low_fat   | BOOLEAN   |

#### SQL Query

```sql
SELECT product_id, product_name
FROM products
WHERE is_recyclable = TRUE AND is_low_fat = TRUE;
```

#### Example Input:

| product_id | product_name | is_recyclable | is_low_fat |
|------------|--------------|---------------|------------|
| 1          | Product A    | TRUE          | TRUE       |
| 2          | Product B    | TRUE          | FALSE      |
| 3          | Product C    | FALSE         | TRUE       |
| 4          | Product D    | TRUE          | TRUE       |

#### Example Output:

| product_id | product_name |
|------------|--------------|
| 1          | Product A    |
| 4          | Product D    |

**Explanation**:
- Product A is both recyclable and low-fat. ✅
- Product D is both recyclable and low-fat. ✅
- Product B is recyclable but not low-fat. ❌
- Product C is low-fat but not recyclable. ❌

---

## How to Use 📂

1. **Clone the repository**:
   - Run the following command to clone the repository to your local machine:
     ```bash
     git clone https://github.com/saraanbih/Task-Solution.git
     ```

2. **Run the Authentication System**:
   - Open the solution in Visual Studio or any other C# IDE.
   - Build and run the project.
   - Follow the prompts to **register** a new user and **login** using your credentials.

3. **For the Increment/Decrement Problem**:
   - Clone the repository containing the C# solution.
   - Open the program in an IDE, enter a list of operations like `++ ++ -- ++`, and get the result.

4. **For SQL Query Challenge**:
   - Run the SQL query in your SQL Server Management Studio or any SQL-compatible environment.
   - Make sure you have a `products` table with the relevant fields to test the query.
