using System;
using Xunit;
using CTS_DAL;
using System.Collections.Generic;
using System.Linq;
using CTS_Persistence;
using Newtonsoft.Json;

namespace CTS_DAL_XUnit
{
    public class RoomUnitTest
    {
        RoomDAL roomDAL =  new RoomDAL();

        [Fact]
        public void GetRoomByRoomIdTest1()
        {
            Room room = roomDAL.GetRoomByRoomId(1);

            Assert.NotNull(room);
            Assert.Equal(1, room.RoomId);
        }
        
        [Fact]
        public void GetRoomByRoomIdTest2()
        {
            Assert.Null(roomDAL.GetRoomByRoomId(0));
        }
    }
}