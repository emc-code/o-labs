using Npgsql;
using System.Diagnostics;

namespace Lab1_DB;

public static class CreateDB
{
    public static void Create(string connectionString)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string sql = string.Empty;
        sql += @"
        CREATE TABLE Products
        (
            ProductId SERIAL PRIMARY KEY,
            ProductName VARCHAR(255) NOT NULL,
            Description TEXT,
            Price NUMERIC(10, 2) NOT NULL,
            QuantityInStock INT NOT NULL CHECK (QuantityInStock >= 0)
        );
        ";

        sql += @"
        CREATE TABLE Users
        (
            UserId SERIAL PRIMARY KEY,
            UserName VARCHAR(100) NOT NULL,
            Email VARCHAR(255) NOT NULL UNIQUE,
            RegistrationDate DATE NOT NULL DEFAULT CURRENT_DATE
        );
        ";

        sql += @"
        CREATE TABLE Orders 
        (
            OrderId SERIAL PRIMARY KEY,
            UserId INT NOT NULL,
            OrderDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
            Status VARCHAR(50) NOT NULL,
            FOREIGN KEY (UserId) REFERENCES Users(UserId)
        );
        ";

        sql += @"
        CREATE TABLE OrderDetails 
        (
            OrderDetailId SERIAL PRIMARY KEY,
            OrderId INT NOT NULL,
            ProductId INT NOT NULL,
            Quantity INT NOT NULL CHECK (Quantity > 0),
            TotalCost NUMERIC(10, 2) NOT NULL CHECK (TotalCost >= 0),
            FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
            FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
        );
        ";

        using var cmd = new NpgsqlCommand(sql, connection);
        Debug.WriteLine(cmd.ExecuteNonQuery().ToString());
    }
}
