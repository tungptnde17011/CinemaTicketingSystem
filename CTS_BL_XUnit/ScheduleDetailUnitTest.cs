using Xunit;
using System;
using CTS_BL;
using CTS_Persistence;
using System.Collections.Generic;

namespace CTS_BL_XUnit
{
    public class ScheduleDetailUnitTest
    {
        ScheduleDetailBL sdbl = new ScheduleDetailBL();
        [Fact]
        public void GetScheduleDetailBySchedIdTest1()
        {
            Assert.NotNull(sdbl.GetScheduleDetailBySchedId(1));
        }
        [Fact]
        public void GetScheduleDetailBySchedIdTest2()
        {
            Assert.Null(sdbl.GetScheduleDetailBySchedId(0));
        }
        [Fact]
        public void GetScheduleDetailBySchedIdTest3()
        {
            Assert.Null(sdbl.GetScheduleDetailBySchedId(null));
        }
        [Fact]
        public void GetScheduleDetailsByScheIdTest1()
        {
            Assert.NotNull(sdbl.GetScheduleDetailsByScheId(1));
        }
        [Fact]
        public void GetScheduleDetailsByScheIdTest2()
        {
            Assert.Equal(new List<ScheduleDetail>(), sdbl.GetScheduleDetailsByScheId(0));
        }
        [Fact]
        public void GetScheduleDetailsByScheIdTest3()
        {
            Assert.Null(sdbl.GetScheduleDetailsByScheId(null));
        }

        [Fact]
        public void GetScheduleDetailsBySchedIdAndTimeNowTest1()
        {
            Assert.Equal(new List<ScheduleDetail>(), sdbl.GetScheduleDetailsByScheIdAndTimeNow(0));
        }
        [Fact]
        public void GetScheduleDetailsBySchedIdAndTimeNowTest2()
        {
            Assert.Null(sdbl.GetScheduleDetailsByScheIdAndTimeNow(null));
        }
        [Fact]
        public void GetScheduleDetailsBySchedIdAndTimeNowTest3()
        {
            Assert.NotNull(sdbl.GetScheduleDetailsByScheIdAndTimeNow(1));
        }
    }
}