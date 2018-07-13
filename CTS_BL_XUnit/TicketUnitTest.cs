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
        public void BuyTicketTest1()
        {
            ScheduleDetail sd = new ScheduleDetail(1, null, null, null, "RoomSeat");
            Assert.True(tbl.BuyTicket(sd));
        }
        [Fact]
        public void BuyTicketTest2()
        {
            ScheduleDetail sd = new ScheduleDetail(null, null, null, null, "RoomSeat");
            Assert.False(tbl.BuyTicket(sd));
        }
        [Fact]
        public void BuyTicketTest3()
        {
            ScheduleDetail sd = new ScheduleDetail(0,null,null,null,"roomseat");
            Assert.False(tbl.BuyTicket(sd));
        }
        [Fact]
        public void BuyTicketTest4()
        {
            Assert.False(tbl.BuyTicket(new ScheduleDetail(null, null, null, null, "")));
        }
        [Fact]
        public void BuyTicketTest5()
        {
            Assert.False(tbl.BuyTicket(null));
        }
    }
}