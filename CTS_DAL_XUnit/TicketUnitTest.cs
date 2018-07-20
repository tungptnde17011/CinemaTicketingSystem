using System;
using CTS_Persistence;
using Xunit;

namespace CTS_DAL
{
    public class TicketUnitTest
    {
        TicketDAL ticketDAL = new TicketDAL();

        [Fact]
        public void BuyTicketTest1()
        {
            ScheduleDetail schedDetail = new ScheduleDetail(3, null, null, null, "RoomSeat");

            Assert.True(ticketDAL.BuyTicket(schedDetail));
        }

        [Fact]
        public void BuyTicketTest2()
        {
            ScheduleDetail schedDetail = new ScheduleDetail(null, null, null, null, "RoomSeat");

            Assert.False(ticketDAL.BuyTicket(schedDetail));
        }

        [Fact]
        public void BuyTicketTest3()
        {
            ScheduleDetail schedDetail = new ScheduleDetail(0, null, null, null, "RoomSeat");

            Assert.False(ticketDAL.BuyTicket(schedDetail));
        }

        [Fact]
        public void BuyTicketTest4()
        {
            ScheduleDetail schedDetail = new ScheduleDetail(3, null, null, null, null);

            Assert.False(ticketDAL.BuyTicket(schedDetail));
        }

        [Fact]
        public void BuyTicketTest5()
        {
            Assert.False(ticketDAL.BuyTicket(null));
        }
    }
}