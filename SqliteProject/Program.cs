using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SqliteProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection connection = CreateConnection();
            //CreateTable(connection);
            InsertTable(connection);
            ReadTable(connection);
        }

        private static SQLiteConnection CreateConnection()
        {
            //create a database file:
            //SQLiteConnection.CreateFile("MyDatabase.sqlite");
            //create a new database connection:
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=C:\Users\afba\source\repos\SqliteProject\SqliteProject\database.db; Version = 3; New = True; Compress = True; ");
            //open a connection:
            connection.Open();
            return connection;
        }
        private static void CreateTable(SQLiteConnection connection)
        {
            SQLiteCommand sql_cmd_create;
            string CreateTable1 = "CREATE TABLE Student(StudentId INT, StudentName VarChar(50) , StudentAge INT )";
            string CreateTable2 = "CREATE TABLE Class(ClassId INT, ClassName VarChar(50) , MaxClassSize INT , StudentId INT )";
            sql_cmd_create = connection.CreateCommand();

            // create table1
            sql_cmd_create.CommandText = CreateTable1;
            sql_cmd_create.ExecuteNonQuery();

            //create table2
            sql_cmd_create.CommandText = CreateTable2;
            sql_cmd_create.ExecuteNonQuery();

        }
        private static void InsertTable(SQLiteConnection connection)
        {
            SQLiteCommand sql_cmd_insert;
            sql_cmd_insert = connection.CreateCommand();
            sql_cmd_insert.CommandText = "INSERT INTO Student(StudentId , StudentName , StudentAge) VALUES  (1 , 'Allan' , 15 )";
            sql_cmd_insert.ExecuteNonQuery();
            sql_cmd_insert.CommandText = "INSERT INTO Student(StudentId , StudentName , StudentAge) VALUSE (1 , 'Adrian' , 14 )";
            sql_cmd_insert.ExecuteNonQuery();
            sql_cmd_insert.CommandText = "INSERT INTO Student(StudentId , StudentName , StudentAge) VALUSE (1 , 'Jen' , 12 )";
            sql_cmd_insert.ExecuteNonQuery();

            sql_cmd_insert.CommandText = "INSERT INTO Class(ClassId , ClassName , MaxClassSize , StudentId) VALUSE (1 , 'English' , 25 ,1 )";
            sql_cmd_insert.ExecuteNonQuery();
            sql_cmd_insert.CommandText = "INSERT INTO Class(ClassId , ClassName , MaxClassSize , StudentId) VALUSE (2 , 'English' , 25 ,2 )";
            sql_cmd_insert.ExecuteNonQuery();
            sql_cmd_insert.CommandText = "INSERT INTO Class(ClassId , ClassName , MaxClassSize , StudentId) VALUSE (3 , 'English' , 25 ,3 )";
            sql_cmd_insert.ExecuteNonQuery();
        }
        private static void ReadTable(SQLiteConnection connection)
        {
            SQLiteDataReader sql_dataReader;
            SQLiteCommand sql_cmd_reader;
            sql_cmd_reader = connection.CreateCommand();
            sql_cmd_reader.CommandText = "SELECT * FROM Student";
            sql_dataReader = sql_cmd_reader.ExecuteReader();
            while (sql_dataReader.Read())
            {
                string myReader = sql_dataReader.GetString(0);
                Console.WriteLine(myReader);

            }
            connection.Close();
        }

        

        

       
    }
}
