using Xunit;
using CTS_BL;
using System.Collections.Generic;
using CTS_Persistence;
using System;

namespace CTS_BL_XUnit
{
    public class ScheduleUnitTest
    {
        ScheduleBL sbl = new ScheduleBL();
        ScheduleDetailBL sdbl = new ScheduleDetailBL();
        Schedule sche = new Schedule();
        [Fact]
        public void CreateScheduleTest1()
        {
            List<ScheduleDetail> schedDetails = new List<ScheduleDetail>();
            DateTime timeStart = new DateTime(2018, 8, 2, 7, 0, 0);
            DateTime timeEnd = new DateTime(2018, 8, 2, 9, 12, 0);
            schedDetails.Add(new ScheduleDetail(null, null, timeStart, timeEnd, "Room Seat"));
            schedDetails.Add(new ScheduleDetail(null, null, timeStart, timeEnd, "Room Seat"));
            Schedule sche = new Schedule(null, 0, null, "07:00, 08:00", 3, 1, schedDetails);
            Assert.True(sbl.CreateSchedule(sche));
        }
        [Fact]
        public void CreateScheduleTest2()
        {
            List<ScheduleDetail> schedDetails = new List<ScheduleDetail>();
            DateTime timeStart = new DateTime(2018, 8, 2, 7, 0, 0);
            DateTime timeEnd = new DateTime(2018, 8, 2, 9, 12, 0);
            schedDetails.Add(new ScheduleDetail(null, null, timeStart, timeEnd, "Room Seat"));
            schedDetails.Add(new ScheduleDetail(null, null, timeStart, timeEnd, "Room Seat"));
            Schedule sche = new Schedule(null, 0, null, "11:00", 3, 3, schedDetails);
            Assert.False(sbl.CreateSchedule(sche));
        }
        [Fact]
        public void GetSchedulesByMovieIdTest1()
        {
            Assert.NotNull(sbl.GetSchedulesByMovieId(1));
        }
        [Fact]
        public void GetSchedulesByMovieIdTest2()
        {
            Assert.Equal(new List<Schedule>(), sbl.GetSchedulesByMovieId(0));
        }
        [Fact]
        public void GetSchedulesByMovieIdTest3()
        {
            Assert.Null(sbl.GetSchedulesByMovieId(null));
        }
    }   
}