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
            Schedule sche = new Schedule(null, 0, null, "07:00, 07:00", 1, 3, schedDetails);

            Assert.True(scheDAL.CreateSchedule(sche));
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