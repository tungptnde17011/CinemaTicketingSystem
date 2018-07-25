using Xunit;
using CTS_BL;
using CTS_Persistence;
using System;

namespace CTS_BL_XUnit
{
    public class TicketUnitTest
    {
        TicketBL tbl = new TicketBL();
        [Fact]
        public void SellTicketTest1()
        {
            ScheduleDetail sd = new ScheduleDetail(1, null, null, null, "RoomSeat");
            Assert.True(tbl.SellTicket(sd));
        }
        [Fact]
        public void SellTicketTest2()
        {
            ScheduleDetail sd = new ScheduleDetail(null, null, null, null, "RoomSeat");
            Assert.False(tbl.SellTicket(sd));
        }
    }
}