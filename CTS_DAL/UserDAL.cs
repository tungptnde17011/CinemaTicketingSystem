using System;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class UserDAL
    {
        private string query;
        private MySqlDataReader reader;

        public User Login(string username, string password)
        {
            string query = @"select * from Accounts where acc_username = "+ username +" and acc_password="+ password +";";
            DBHelper.OpenConnection();
            return null;
        }
    }
}
