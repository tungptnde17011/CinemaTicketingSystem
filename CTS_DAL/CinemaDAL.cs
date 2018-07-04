using System;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class CinemaDAL
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string query;

        public Cinema GetCinemaByCineId(int? cineId)
        {
            query = $"select * from Cinemas where cine_id = " + cineId + ";";

            Cinema cinema = null;
            using (connection = DBHelper.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cinema = GetCinema(reader);
                    }
                }
            }

            return cinema;
        }

        private Cinema GetCinema(MySqlDataReader reader)
        {
            int cineId = reader.GetInt32("cine_id");
            string cineAddress = reader.GetString("cine_address");
            string cineName = reader.GetString("cine_name");
            string cinePhone = reader.GetString("cine_phone");

            Cinema cinema = new Cinema(cineId, cineAddress, cineName, cinePhone);

            return cinema;
        }
    }
}