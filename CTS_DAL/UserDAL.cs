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
            query = @"select * from Accounts where acc_username = '"+ username +"' and acc_password= '"+ password +"';";
            DBHelper.OpenConnection();

            reader = DBHelper.ExecQuery(query);
            User user = null;
            if (reader.Read())
            {
                user = GetUser(reader);
            }
            DBHelper.CloseConnection();

            return user;
        }

        private User GetUser(MySqlDataReader reader)
        {
            User user = new User(reader.GetString("acc_username"), reader.GetString("acc_password"), reader.GetString("acc_type"), null);
            return user;
        }
    }
}
