// See https://aka.ms/new-console-template for more information
using Lab1_DB;

string connectionString = "Host=localhost;Port=5432;username=user;password=1;database=otus";

CreateDB.Create(connectionString);
//Requests.Run(connectionString);