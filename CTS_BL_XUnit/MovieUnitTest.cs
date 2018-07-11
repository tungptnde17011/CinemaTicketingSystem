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
            Assert.NotNull(mbl.GetMovieByCineId(1));
        }
        [Fact]
        public void GetMovieByCineIdTest2()
        {
            Assert.Equal(new List<Movie>(), mbl.GetMovieByCineId(0));
        }
        [Fact]
        public void GetMovieByCineIdTest3()
        {
            Assert.Null(mbl.GetMovieByCineId(null));
        }
        
    }
}