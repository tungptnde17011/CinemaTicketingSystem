using System;
using System.Collections.Generic;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class ScheduleDAL
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string query;
        ScheduleDetailDAL schedDetailDAL = new ScheduleDetailDAL();

        public ScheduleDAL()
        {
            connection = DBHelper.OpenConnection();
        }

        public bool CreateSchedule(Schedule sche)
        {
            bool result = false;
            if (sche == null || sche.ScheduleDetails == null || sche.ScheduleDetails.Count == 0)
            {
                return result;
            }

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;

            // Lock Tables
            command.CommandText = @"lock tables Schedules write, SchedulesDetails write;";
            command.ExecuteNonQuery();

            // Transaction
            MySqlTransaction trans = connection.BeginTransaction();
            command.Transaction = trans;

            try
            {
                // Insert Schedule
                int roomId = sche.RoomId;
                int movieId = sche.MovieId;
                int scheStatus = sche.ScheStatus;
                string scheWeekdays = sche.ScheWeekdays;
                string scheTimeline = sche.ScheTimeline;
                query = @"insert into Schedules(room_id, movie_id, sche_status, sche_weekdays, sche_timeline) values" +
                    "(" + roomId + ", " + movieId + ", " + scheStatus + ", '" + scheWeekdays + "', '" + scheTimeline + "');";
                command.CommandText = query;
                command.ExecuteNonQuery();

                //Insert ScheduleDetails
                command.CommandText = "select LAST_INSERT_ID() as sche_id";
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        query = "insert into SchedulesDetails(sche_id, sched_timeStart, sched_timeEnd, sched_roomSeats) values";
                        string schedDetailValue;
                        string timeStart;
                        string timeEnd;
                        foreach (ScheduleDetail schedDetail in sche.ScheduleDetails)
                        {
                            schedDetail.ScheId = reader.GetInt32("sche_id");
                            timeStart = schedDetail.SchedTimeStart?.ToString("yyyy/MM/dd HH:mm:ss");
                            timeEnd = schedDetail.SchedTimeEnd?.ToString("yyyy/MM/dd HH:mm:ss");
                            schedDetailValue = "(" + schedDetail.ScheId + ",'" + timeStart + "','" + timeEnd + "','" + schedDetail.SchedRoomSeats + "'),";

                            query = query + schedDetailValue;
                        }
                    }
                }

                query = query.Substring(0, query.Length - 1) + ";";
                command.CommandText = query;
                command.ExecuteNonQuery();

                trans.Commit();
                result = true;
            }
            catch (System.Exception e)
            {
                string m = e.Message;
                trans.Rollback();
            }
            finally
            {
                // Unlock Tables
                command.CommandText = "unlock tables";
                command.ExecuteNonQuery();
                connection.Close();
            }

            return result;
        }

        public List<Schedule> GetSchedulesByMovieId(int? movieId)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            query = $"select * from Schedules where movie_id = " + movieId + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            List<Schedule> sches = null;
            using (reader = command.ExecuteReader())
            {
                sches = new List<Schedule>();
                while (reader.Read())
                {
                    sches.Add(GetSchedule(reader));
                }
            }

            connection.Close();

            return sches;
        }

        public Schedule GetScheduleByScheId(int? scheId)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            query = $"select * from Schedules where sche_id = " + scheId + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            Schedule sche = null;
            using (reader = command.ExecuteReader())
            {
                sche = new Schedule();
                while (reader.Read())
                {
                    sche = GetSchedule(reader);
                }
            }

            connection.Close();

            return sche;
        }

        public Schedule GetScheduleByMovieIdAndRoomId(int? movieId, int? roomId)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            query = $"select * from Schedules where movie_id = " + movieId + " and room_id = "+ roomId +";";
            MySqlCommand command = new MySqlCommand(query, connection);
            Schedule sche = null;
            using (reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    sche = GetSchedule(reader);
                }
            }

            connection.Close();

            return sche;
        }

        public Schedule GetSchedule(MySqlDataReader reader)
        {
            int scheId = reader.GetInt32("sche_id");
            int roomId = reader.GetInt32("room_id");
            int movieId = reader.GetInt32("movie_id");
            int scheStatus = reader.GetInt32("sche_status");
            string scheWeekdays = reader.GetString("sche_weekdays");
            string scheTimeline = reader.GetString("sche_timeline");

            Schedule sche = new Schedule(scheId, scheStatus, scheWeekdays, scheTimeline, roomId, movieId, null);

            return sche;
        }
    }
}