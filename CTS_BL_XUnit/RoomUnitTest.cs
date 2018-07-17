using Xunit;
using System.Collections.Generic;
using CTS_BL;
using CTS_Persistence;

namespace CTS_BL_XUnit
{
    public class RoomUnitTest
    {
        RoomBL rbl = new RoomBL();
        [Fact]
        public void GetRoomByRoomIdTest1()
        {
            Assert.NotNull(rbl.GetRoomByRoomId(1));
        }
        [Fact]
        public void GetRoomByRoomIdTest2()
        {
            Assert.Null(rbl.GetRoomByRoomId(0));
        }
        [Fact]
        public void GetRoomByRoomIdTest3()
        {
            Assert.Null(rbl.GetRoomByRoomId(null));
        }
        [Fact]
        public void GetRoomByCineIdTest1()
        {
            Assert.NotNull(rbl.GetRoomsByCineId(1));
        }
        [Fact]
        public void GetRoomByCineIdTest2()
        {
            Assert.Equal(new List<Room>(), rbl.GetRoomsByCineId(0));
        }
        [Fact]
        public void GetRoomByCineIdTest3()
        {
            Assert.Null(rbl.GetRoomsByCineId(null));
        }
    }
}