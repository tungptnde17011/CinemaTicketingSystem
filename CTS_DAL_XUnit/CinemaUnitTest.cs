using System;
using Xunit;
using CTS_DAL;
using CTS_Persistence;

namespace CTS_DAL_XUnit
{
    public class CinemaUnitTest
    {
        private CinemaDAL cinemaDAL = new CinemaDAL();

        [Fact]
        public void GetCinemaByCineIdTest1()
        {
            Cinema cine = cinemaDAL.GetCinemaByCineId(1);

            Assert.NotNull(cine);
            Assert.Equal(1, cine.CineId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(null)]
        public void GetCinemaByCineIdTest2(int? cineId)
        {
            Assert.Null(cinemaDAL.GetCinemaByCineId(cineId));
        }
    }
}