using System;
using Xunit;
using CTS_DAL;
using System.Collections.Generic;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL_XUnit
{
    public class RoomUnitTest
    {
        private RoomDAL roomDAL = new RoomDAL();
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string query;

        [Fact]
        public void GetRoomByRoomIdTest1()
        {
            Room room = roomDAL.GetRoomByRoomId(1);

            Assert.NotNull(room);
            Assert.Equal(1, room.RoomId);
        }

        [Fact]
        public void GetRoomByRoomIdTest2()
        {
            Assert.Null(roomDAL.GetRoomByRoomId(0));
        }

        [Fact]
        public void GetRoomsByCineIdTest1()
        {
            List<Room> rooms = roomDAL.GetRoomsByCineId(1);

            query = $"select * from Rooms where cine_id = 1 order by rand() limit 1;";
            Room roomRand = GetRoomExecQuery(query);

            query = $"select * from Rooms where cine_id = 1 order by room_id asc limit 1;";
            Room roomTop = GetRoomExecQuery(query);

            query = $"select * from Rooms where cine_id = 1 order by room_id desc limit 1;";
            Room roomBottom = GetRoomExecQuery(query);

            Assert.NotNull(rooms);
            Assert.NotNull(roomRand);
            Assert.NotNull(roomTop);
            Assert.NotNull(roomBottom);

            Assert.Contains(roomRand, rooms);
            Assert.Contains(roomTop, rooms);
            Assert.Contains(roomBottom, rooms);
        }

        [Fact]
        public void GetRoomsByCineIdTest2()
        {
            Assert.Equal(new List<Room>(), roomDAL.GetRoomsByCineId(0));
        }

        private Room GetRoomExecQuery(string query)
        {
            Room room = null;
            using (connection = DBHelper.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        room = roomDAL.GetRoom(reader);
                    }
                }
            }

            return room;
        }
    }
}