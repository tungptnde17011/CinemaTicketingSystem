using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    // Using Singleton Design Pattern
    public class DBHelper
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection
            {
                ConnectionString = "server=localhost;user id=CTSUser;password=123456;port=3306;database=CinemaTicketingSystemDB;SslMode=None;"
            };

            return connection;
        }

        public static MySqlConnection OpenConnection()
        {

            MySqlConnection connection = GetConnection();

            connection.Open();

            return connection;
        }


    }
}