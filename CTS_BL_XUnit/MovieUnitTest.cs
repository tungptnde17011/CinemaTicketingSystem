using Xunit;
using System.Collections.Generic;
using CTS_BL;
using CTS_Persistence;

namespace CTS_BL_XUnit
{
    public class MovieUnitTest
    {
        MovieBL mbl = new MovieBL();
        [Fact]
        public void GetMovieByMovieIdTest1()
        {
            Assert.NotNull(mbl.GetMovieByMovieId(1));
        }
        [Fact]
        public void GetMovieByMovieIdTest2()
        {
            Assert.Null(mbl.GetMovieByMovieId(0));
        }
        [Fact]
        public void GetMovieByMovieIdTest3()
        {
            Assert.Null(mbl.GetMovieByMovieId(null));
        }
        [Fact]
        public void GetMovieByCineIdTest1()
        {
            Assert.NotNull(mbl.GetMoviesByCineId(1));
        }
        [Fact]
        public void GetMovieByCineIdTest2()
        {
            Assert.Equal(new List<Movie>(), mbl.GetMoviesByCineId(0));
        }
        [Fact]
        public void GetMovieByCineIdTest3()
        {
            Assert.Null(mbl.GetMoviesByCineId(null));
        }
        [Fact]
        public void GetMovieByMovieIdAndDateNowTest1()
        {
            Assert.NotNull(mbl.GetMoviesByCineIdAndDateNow(1));
        }
        [Fact]
        public void GetMovieByMovieIdAndDateNowTest2()
        {
            Assert.Equal(new List<Movie>(),mbl.GetMoviesByCineIdAndDateNow(0));
        }
        [Fact]
        public void GetMovieByMovieIdAndDateNowTest3()
        {
            Assert.Null(mbl.GetMoviesByCineIdAndDateNow(null));
        }
    }
}