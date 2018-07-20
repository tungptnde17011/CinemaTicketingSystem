using System;
using System.Collections.Generic;
using CTS_DAL;
using CTS_Persistence;
using MySql.Data.MySqlClient;
using Xunit;

namespace CTS_DAL_XUnit
{
    public class ScheduleUnitTest
    {
        private ScheduleDAL scheDAL = new ScheduleDAL();
        private MySqlConnection connection = DBHelper.OpenConnection();
        private MySqlDataReader reader;
        private string query;

        [Fact]
        public void CreateScheduleTest1()
        {
            List<ScheduleDetail> schedDetails = new List<ScheduleDetail>();
            DateTime timeStart = new DateTime(2018, 8, 2, 7, 0, 0);
            DateTime timeEnd = new DateTime(2018, 8, 2, 9, 12, 0);
            schedDetails.Add(new ScheduleDetail(null, null, timeStart, timeEnd, "Room Seat"));
            schedDetails.Add(new ScheduleDetail(null, null, timeStart, timeEnd, "Room Seat"));
            Schedule sche = new Schedule(null, 0, null, "07:00, 08:00", 1, 3, schedDetails);

            Assert.True(scheDAL.CreateSchedule(sche));
        }

        [Fact]
        public void CreateScheduleTest2()
        {
            List<ScheduleDetail> schedDetails = new List<ScheduleDetail>();
            DateTime timeStart = new DateTime(2018, 8, 2, 7, 0, 0);
            DateTime timeEnd = new DateTime(2018, 8, 2, 9, 12, 0);
            schedDetails.Add(new ScheduleDetail(null, null, null, null, "Room Seat"));
            schedDetails.Add(new ScheduleDetail(null, null, null, null, "Room Seat"));
            Schedule sche = new Schedule(null, 0, null, "07:00, 07:50", 1, 4, schedDetails);

            Assert.False(scheDAL.CreateSchedule(sche));
        }

        [Fact]
        public void CreateScheduleTest3()
        {
            List<ScheduleDetail> schedDetails = new List<ScheduleDetail>();
            // DateTime timeStart = new DateTime(2018, 8, 2, 7, 0, 0);
            // DateTime timeEnd = new DateTime(2018, 8, 2, 9, 12, 0);
            // schedDetails.Add(new ScheduleDetail(null, null, null, null, "Room Seat"));
            // schedDetails.Add(new ScheduleDetail(null, null, null, null, "Room Seat"));
            Schedule sche = new Schedule(null, 0, null, "08:00, 08:50", 1, 2, null);

            Assert.False(scheDAL.CreateSchedule(sche));
        }

        [Fact]
        public void GetSchedulesByMovieIdTest1()
        {
            int movieId = 3;
            List<Schedule> sches = scheDAL.GetSchedulesByMovieId(movieId);

            query = $"select * from Schedules where movie_id = " + movieId + " order by rand() limit 1;";
            Schedule scheRand = GetScheduleExecQuery(query);

            query = $"select * from Schedules where movie_id = " + movieId + " order by sche_id asc limit 1;";
            Schedule scheTop = GetScheduleExecQuery(query);

            query = $"select * from Schedules where movie_id = " + movieId + " order by sche_id desc limit 1;";
            Schedule scheBottom = GetScheduleExecQuery(query);

            Assert.NotNull(sches);
            Assert.NotNull(scheRand);
            Assert.NotNull(scheTop);
            Assert.NotNull(scheBottom);

            Assert.Contains(scheRand, sches);

            Assert.True(sches.IndexOf(scheTop) == 0);
            Assert.True(sches.IndexOf(scheBottom) == (sches.Count - 1));
        }
        [Fact]
        public void GetSchedulesByMovieIdTest2()
        {
            Assert.Equal(new List<Schedule>(), scheDAL.GetSchedulesByMovieId(0));
        }
        [Fact]
        public void GetSchedulesByMovieIdTest3()
        {
            Assert.Null(scheDAL.GetSchedulesByMovieId(null));
        }

        [Fact]
        public void GetScheduleByMovieIdAndRoomIdTest1()
        {
            Assert.NotNull(scheDAL.GetScheduleByMovieIdAndRoomId(1, 1));
        }

        [Theory]
        [InlineData(1,null)]
        [InlineData(null,1)]
        [InlineData(0,1)]
        [InlineData(1,0)]
        public void GetScheduleByMovieIdAndRoomIdTest2(int? movieId, int? roomId)
        {
            Assert.Null(scheDAL.GetScheduleByMovieIdAndRoomId(movieId, roomId));
        }
        

        [Fact]
        public void GetScheduleBySchedIdTest1()
        {
            Assert.NotNull(scheDAL.GetSchedulesByMovieId(1));
        }
        [Fact]
        public void GetScheduleBySchedIdTest2()
        {
            Assert.Equal(new List<Schedule>(), scheDAL.GetSchedulesByMovieId(0));
        }
        [Fact]
        public void GetScheduleBySchedIdTest3()
        {
            Assert.Null(scheDAL.GetSchedulesByMovieId(null));
        }

        private Schedule GetScheduleExecQuery(string query)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            Schedule sche = null;
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    sche = scheDAL.GetSchedule(reader);
                }
            }

            connection.Close();

            return sche;
        }
    }
}