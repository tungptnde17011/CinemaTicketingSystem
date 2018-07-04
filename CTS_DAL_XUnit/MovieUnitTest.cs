using System;
using Xunit;
using CTS_DAL;
using System.Collections.Generic;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL_XUnit
{
    public class MovieUnitTest
    {
        private MovieDAL movieDAL = new MovieDAL();
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string query;

        [Fact]
        public void GetMovieByMovieIdTest1()
        {
            Movie movie = movieDAL.GetMovieByMovieId(1);

            Assert.NotNull(movie);
            Assert.Equal(1, movie.MovieId);
        }

        [Fact]
        public void GetMovieByMovieIdTest2()
        {
            Assert.Null(movieDAL.GetMovieByMovieId(0));
        }

        [Fact]
        public void GetMoviesByCineIdTest1()
        {
            int cineId = 1;
            List<Movie> movies = movieDAL.GetMoviesByCineId(cineId);

            query = $"select * from Shows inner join Movies on Shows.movie_id = Movies.movie_id where cine_id = " + cineId + " order by rand() limit 1;";
            Movie movieRand = GetMovieExecQuery(query);

            query = $"select * from Shows inner join Movies on Shows.movie_id = Movies.movie_id where cine_id = " + cineId + " order by Shows.movie_id asc limit 1;";
            Movie movieTop = GetMovieExecQuery(query);

            query = $"select * from Shows inner join Movies on Shows.movie_id = Movies.movie_id where cine_id = " + cineId + " order by Shows.movie_id desc limit 1;";
            Movie movieBottom = GetMovieExecQuery(query);

            Assert.NotNull(movies);
            Assert.NotNull(movieRand);
            Assert.NotNull(movieTop);
            Assert.NotNull(movieBottom);

            Assert.Contains(movieRand, movies);

            Assert.True(movies.IndexOf(movieTop) == 0);
            Assert.True(movies.IndexOf(movieBottom) == (movies.Count - 1));
        }

        [Fact]
        public void GetMoviesByCineIdTest2()
        {
            Assert.Equal(new List<Movie>(), movieDAL.GetMoviesByCineId(0));
        }

        private Movie GetMovieExecQuery(string query)
        {
            Movie movie = null;
            using (connection = DBHelper.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movie = movieDAL.GetMovie(reader);
                    }
                }
            }

            return movie;
        }
    }
}