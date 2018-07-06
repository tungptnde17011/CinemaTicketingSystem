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
    }
}