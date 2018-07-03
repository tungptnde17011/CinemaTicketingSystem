using System;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class UserDAL
    {
        public User Login(string username, string password)
        {
            DBHelper.OpenConnection();
            

            return null;
        }
    }
}
