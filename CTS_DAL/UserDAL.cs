using System;
using System.Text.RegularExpressions;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class UserDAL
    {
        private string query;
        private MySqlDataReader reader;
        private MySqlConnection connection;

        public User Login(string username, string password)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionUsername = regex.Matches(username);
            MatchCollection matchCollectionPassword = regex.Matches(password);
            if (matchCollectionUsername.Count <= 0 || matchCollectionPassword.Count <= 0)
            {
                return null;
            }

            query = @"select * from Accounts where acc_username = '" + username + "' and acc_password= '" + password + "';";

            User user = null;
            using (connection = DBHelper.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = GetUser(reader);
                    }   
                }
            }

            if (user != null)
            {
                CinemaDAL cinemaDAL = new CinemaDAL();
                Cinema cine = cinemaDAL.GetCinemaByCineId(user.Cine.CineId);
            }

            return user;
        }

        private User GetUser(MySqlDataReader reader)
        {
            string username = reader.GetString("acc_username");
            string password = reader.GetString("acc_password");
            string type = reader.GetString("acc_type");
            Cinema cine = new Cinema(reader.GetInt32("cine_id"), null, null, null);

            User user = new User(username, password, type, cine);

            return user;
        }
    }
}
