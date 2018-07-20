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

        [Theory]
        [InlineData(null, null, null, null, "RoomSeat")]
        [InlineData(0, null, null, null, "RoomSeat")]
        [InlineData(3, null, null, null, null)]
        [InlineData(3, null, null, null, "")]
        public void BuyTicketTest2(int? schedId, int? scheId, DateTime? schedTimeStart, DateTime? schedTimeEnd, string schedRoomSeats)
        {
            ScheduleDetail schedDetail = new ScheduleDetail(schedId, scheId, schedTimeStart, schedTimeEnd, schedRoomSeats);

            Assert.False(ticketDAL.BuyTicket(schedDetail));
        }

        [Fact]
        public void BuyTicketTest6()
        {
            Assert.False(ticketDAL.BuyTicket(null));
        }
    }
}