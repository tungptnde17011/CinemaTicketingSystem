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
            if (sche == null)
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
            command.CommandText = @"lock tables Schedules write;";
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
                query = @"insert into Schedules(room_id, movie_id, sche_status, sche_weekdays, sche_timeline) values"+
                    "(" + roomId + ", " + movieId + ", " + scheStatus + ", '" + scheWeekdays + "', '" + scheTimeline + "');";
                command.CommandText = query;
                command.ExecuteNonQuery();

                //Insert ScheduleDetails
                command.CommandText = "select LAST_INSERT_ID() as sche_id";
                using (reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        foreach (ScheduleDetail schedDetail in sche.ScheduleDetails)
                        {
                            schedDetail.ScheId = reader.GetInt32("sche_id");
                        }
                    }
                }

                query = "insert into SchedulesDetails(sche_id, sched_timeStart, sched_timeEnd, sched_roomSeats) values";
                string schedDetailValue;
                string timeStart;
                string timeEnd;
                foreach (ScheduleDetail schedDetail in sche.ScheduleDetails)
                {
                    timeStart = schedDetail.SchedTimeStart.ToString("yyyy/MM/dd HH:mm:ss");
                    timeEnd = schedDetail.SchedTimeEnd.ToString("yyyy/MM/dd HH:mm:ss");
                    schedDetailValue = "("+ schedDetail.ScheId +",'"+ timeStart +"','"+ timeEnd +"','"+ schedDetail.SchedRoomSeats +"'),";

                    query = query + schedDetailValue;
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
                command.CommandText = "unlock tables";
                command.ExecuteNonQuery();
                connection.Close();
            }

            return result;
        }
    }
}