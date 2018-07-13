using Xunit;
using CTS_BL;
using CTS_Persistence;
using System.Collections.Generic;

namespace CTS_BL_XUnit
{
    public class PriceSeatOfRoomTypeUnitTest
    {
        PriceSeatOfRoomTypeBL psortbl = new PriceSeatOfRoomTypeBL();
        [Fact]
        public void GetPriceSeatsOfRoomTypeByRTNameTest1()
        {
            Assert.NotNull(psortbl.GetPriceSeatsOfRoomTypeByRTName("3D"));
        }
        [Fact]
        public void GetPriceSeatsOfRoomTypeByRTNameTest2()
        {
            Assert.Equal(new List<PriceSeatOfRoomType>() , psortbl.GetPriceSeatsOfRoomTypeByRTName("no"));
        }
        [Fact]
        public void GetPriceSeatsOfRoomTypeByRTNameTest3()
        {
            Assert.Null(psortbl.GetPriceSeatsOfRoomTypeByRTName(null));
        }
    }
}