using System;
using Xunit;
using CTS_BL;
using CTS_Persistence;

namespace CTS_BL_XUnit
{
    public class  CinemaUnitTest
    {
        CinemaBL cbl = new CinemaBL();
        [Fact]
        public void CinemaTest1()
        {
            Cinema ci = cbl.GetCinemaByCineId(1);
            Assert.NotNull(ci);
        }
        [Fact]
        public void CinemaTest2()
        {
            Assert.Null(cbl.GetCinemaByCineId(null));
        }
        [Fact]
        public void CinemaTest3()
        {
            Assert.Null(cbl.GetCinemaByCineId(-4));
        }
    }
}