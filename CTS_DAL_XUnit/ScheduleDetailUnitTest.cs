using System;
using System.Collections.Generic;
using CTS_DAL;
using CTS_Persistence;
using MySql.Data.MySqlClient;
using Xunit;

namespace CTS_DAL_XUnit
{
    public class ScheduleDetailUnitTest
    {
        private ScheduleDetailDAL schedDetailDAL = new ScheduleDetailDAL();
        private MySqlConnection connection = DBHelper.OpenConnection();
        private MySqlDataReader reader;
        private string query;

        // [Fact]
        // public void CreateScheduleDetailsTest1()
        // {
        //     List<ScheduleDetail> schedDetails = new List<ScheduleDetail>();
        //     DateTime timeStart = new DateTime(2018, 8, 2, 7, 0, 0);
        //     DateTime timeEnd = new DateTime(2018, 8, 2, 9, 12, 0);
        //     schedDetails.Add(new ScheduleDetail(null, 1, timeStart, timeEnd, "Room Seat"));
        //     schedDetails.Add(new ScheduleDetail(null, 2, timeStart, timeEnd, "Room Seat"));

        //     Assert.True(schedDetailDAL.CreateScheduleDetails(schedDetails));
        // }

        [Fact]
        public void GetScheduleDetailBySchedIdTest1()
        {
            ScheduleDetail schedDetail = schedDetailDAL.GetScheduleDetailBySchedId(1);

            Assert.NotNull(schedDetail);
            Assert.Equal(1, schedDetail.ScheId);
        }

        [Fact]
        public void GetMovieByMovieIdTest2()
        {
            Assert.Null(schedDetailDAL.GetScheduleDetailBySchedId(0));
        }

        [Fact]
        public void GetScheduleDetailsByScheIdTest1()
        {
            int schedId = 1;
            List<ScheduleDetail> schedDetails = schedDetailDAL.GetScheduleDetailsByScheId(schedId);

            query = $"select * from SchedulesDetails where sche_id = " + schedId + " order by rand() limit 1;";
            ScheduleDetail schedDetailRand = GetScheduleDetailExecQuery(query);

            query = $"select * from SchedulesDetails where sche_id = " + schedId + " order by sched_id asc limit 1;";
            ScheduleDetail schedDetailTop = GetScheduleDetailExecQuery(query);

            query = $"select * from SchedulesDetails where sche_id = " + schedId + " order by sched_id desc limit 1;";
            ScheduleDetail schedDetailBottom = GetScheduleDetailExecQuery(query);

            Assert.NotNull(schedDetails);
            Assert.NotNull(schedDetailRand);
            Assert.NotNull(schedDetailTop);
            Assert.NotNull(schedDetailBottom);

            Assert.Contains(schedDetailRand, schedDetails);

            Assert.True(schedDetails.IndexOf(schedDetailTop) == 0);
            Assert.True(schedDetails.IndexOf(schedDetailBottom) == (schedDetails.Count - 1));
        }

        [Fact]
        public void GetScheduleDetailsByScheIdTest2()
        {
            Assert.Equal(new List<ScheduleDetail>(), schedDetailDAL.GetScheduleDetailsByScheId(0));
        }

        private ScheduleDetail GetScheduleDetailExecQuery(string query)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            ScheduleDetail schedDetail = null;
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    schedDetail = schedDetailDAL.GetScheduleDetail(reader);
                }
            }

            connection.Close();

            return schedDetail;
        }
    }
}