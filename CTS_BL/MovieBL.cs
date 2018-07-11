


using System;
using CTS_Persistence;
using CTS_DAL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CTS_BL
{
    public class MovieBL
    {
        private MovieDAL mdal = new MovieDAL();
        public Movie GetMovieByMovieId(int? movieId)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(movieId.ToString());
            if (movieId == null)
            {
                return null;
            }
            else if (matchCollection.Count < movieId.ToString().Length)
            {
                return null;
            }
            return mdal.GetMovieByMovieId(movieId);
        }
        public List<Movie> GetMovieByCineId(int? cineId)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(cineId.ToString());
            if (cineId == null)
            {
                return null;
            }
            else if (matchCollection.Count < cineId.ToString().Length)
            {
                return null;
            }
            return mdal.GetMoviesByCineId(cineId);
        }
        public List<Movie> GetMoviesByCineIdAndDateNow(int? cineId)
        {
            return mdal.GetMoviesByCineIdAndDateNow(cineId);
        }
    }
}



