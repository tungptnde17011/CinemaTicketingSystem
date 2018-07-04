using System;
using Xunit;
using CTS_DAL;
using CTS_Persistence;

namespace CTS_DAL_XUnit
{
    public class CinemaUnitTest
    {
        CinemaDAL cinemaDAL =  new CinemaDAL();

        [Fact]
        public void GetCinemaByCineIdTest1()
        {
            Cinema cine = cinemaDAL.GetCinemaByCineId(1);

            Assert.NotNull(cine);
            Assert.Equal(1, cine.CineId);
        }

        [Fact]
        public void GetCinemaByCineIdTest2()
        {
            Assert.Null(cinemaDAL.GetCinemaByCineId(0));
        }
    }
}