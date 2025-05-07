using Npgsql;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Lab1_DB;

public static class Requests
{
    public static void Run(string connectionString)
    {
        var conection = new NpgsqlConnection(connectionString);
        conection.Open();

        string sql = string.Empty;
        sql += @"INSERT INTO Products (ProductName, Description, Price, QuantityInStock) VALUES ('soloma', 'rzanaya soloma', 1000, 3);";
        sql += @"UPDATE Products SET Price = Price + 500 WHERE ProductName = 'soloma';";
        sql += @"SELECT * FROM Orders WHERE UserId = 1;";
        sql += @"SELECT SUM(TotalCost) FROM OrderDetails WHERE OrderId = 3;";
        sql += @"SELECT SUM(QuantityInStock) FROM Products;";
        sql += @"SELECT * FROM Products ORDER BY Price DESC LIMIT 5;";
        sql += @"SELECT * FROM Products WHERE QuantityInStock < 5;";

        using var cmd = new NpgsqlCommand(sql, conection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
                Debug.Write($"{reader.GetName(i)}: {reader.GetValue(i)}\t");
            Debug.WriteLine(" ");
        }
    }
}
