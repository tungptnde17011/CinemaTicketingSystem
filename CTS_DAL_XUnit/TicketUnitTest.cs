using System;
using CTS_Persistence;
using Xunit;

namespace CTS_DAL
{
    public class TicketUnitTest
    {
        TicketDAL ticketDAL = new TicketDAL();

        [Fact]
        public void SellTicketTest1()
        {
            ScheduleDetail schedDetail = new ScheduleDetail(3, null, null, null, "RoomSeat");

            Assert.True(ticketDAL.SellTicket(schedDetail));
        }

        [Theory]
        [InlineData(null, null, null, null, "RoomSeat")]
        [InlineData(0, null, null, null, "RoomSeat")]
        [InlineData(3, null, null, null, null)]
        [InlineData(3, null, null, null, "")]
        public void SellTicketTest2(int? schedId, int? scheId, DateTime? schedTimeStart, DateTime? schedTimeEnd, string schedRoomSeats)
        {
            ScheduleDetail schedDetail = new ScheduleDetail(schedId, scheId, schedTimeStart, schedTimeEnd, schedRoomSeats);

            Assert.False(ticketDAL.SellTicket(schedDetail));
        }

        [Fact]
        public void SellTicketTest6()
        {
            Assert.False(ticketDAL.SellTicket(null));
        }
    }
}