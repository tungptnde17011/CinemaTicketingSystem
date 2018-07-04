using System;
using System.Collections.Generic;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class RoomDAL
    {
        private string query;
        private MySqlDataReader reader;
        MySqlConnection connection;

        public Room GetRoomByRoomId(int? roomId)
        {
            query = $"select * from Rooms where room_id = " + roomId + ";";

            Room room = null;
            using (connection = DBHelper.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        room = GetRoom(reader);
                    }
                }
            }

            return room;
        }

        // public List<Room> GetRoomsByCineId(int? cineId)
        // {
        //     query = $"select * from Rooms where cine_id = "+ cineId +";";
        //     DBHelper.OpenConnection();

        //     List<Room> rooms = null;
        //     reader = DBHelper.ExecQuery(query);
        //     while (reader.Read())
        //     {
        //         rooms.Add(GetRoom(reader));
        //     }
        //     reader.Close();
        //     DBHelper.CloseConnection();

        //     return rooms;
        // }

        private Room GetRoom(MySqlDataReader reader)
        {
            int roomId = reader.GetInt32("room_id");
            string roomName = reader.GetString("room_name");
            string roomSeats = reader.GetString("room_seats");
            string rtName = reader.GetString("rt_name");

            Room room = new Room(roomId, roomName, roomSeats, rtName);

            return room;
        }
    }
}