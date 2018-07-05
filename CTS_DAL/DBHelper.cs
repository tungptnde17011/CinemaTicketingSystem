using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    // Using Singleton Design Pattern
    public class DBHelper
    {
        private static string CONNECTION_STRING = "server=localhost;user id=CTSUser;password=123456;port=3306;database=CinemaTicketingSystemDB;SslMode=None;";

        public static MySqlConnection OpenDefaultConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = CONNECTION_STRING
                };
                connection.Open();

                return connection;
            }
            catch
            {
                return null;
            }
        }

        public static MySqlConnection OpenConnection()
        {
            try
            {
                string connectionString;

                FileStream fileStream = new FileStream("ConnectionString.txt", FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    connectionString = reader.ReadLine();
                }

                return OpenConnection(connectionString);
            }
            catch
            {
                return null;
            }
        }

        public static MySqlConnection OpenConnection(string connectionString)
        {
            try{
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();
                return connection;
            }catch{
                return null;
            }
        }
    }
}