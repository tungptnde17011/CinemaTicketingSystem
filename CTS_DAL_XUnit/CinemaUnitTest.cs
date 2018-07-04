using System;
using Xunit;
using CTS_DAL;

namespace CTS_DAL_XUnit
{
    public class CinemaUnitTest
    {
        CinemaDAL cinemaDAL =  new CinemaDAL();

        [Fact]
        public void GetCinemaByCineIdTest1()
        {
            Assert.NotNull(cinemaDAL.GetCinemaByCineId(1));
        }

        [Fact]
        public void GetCinemaByCineIdTest2()
        {
            Assert.Null(cinemaDAL.GetCinemaByCineId(0));
        }
    }
}