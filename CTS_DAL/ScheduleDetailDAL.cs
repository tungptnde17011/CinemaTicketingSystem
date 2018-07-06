using System;
using System.Collections.Generic;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class ScheduleDetailDAL
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string query;

        public ScheduleDetailDAL()
        {
            connection = DBHelper.OpenConnection();
        }

        // public bool CreateScheduleDetails(List<ScheduleDetail> schedDetails, MySqlConnection conn, MySqlCommand command)
        // {
        //     bool result = false;
        //     if(schedDetails == null || schedDetails.Count == 0)
        //     {
        //         return result;
        //     }

        //     // if(connection.State == System.Data.ConnectionState.Closed)
        //     // {
        //     //     connection.Open();
        //     // }
        //     connection = conn;

        //     query = "insert into SchedulesDetails(sche_id, sched_timeStart, sched_timeEnd, sched_roomSeats) values";
        //     string schedDetailValue;
        //     string timeStart;
        //     string timeEnd;
        //     foreach (ScheduleDetail schedDetail in schedDetails)
        //     {
        //         timeStart = schedDetail.SchedTimeStart.ToString("yyyy/MM/dd HH:mm:ss");
        //         timeEnd = schedDetail.SchedTimeEnd.ToString("yyyy/MM/dd HH:mm:ss");
        //         schedDetailValue = "("+ schedDetail.ScheId +",'"+ timeStart +"','"+ timeEnd +"','"+ schedDetail.SchedRoomSeats +"'),";

        //         query = query + schedDetailValue;
        //     }

        //     query = query.Substring(0, query.Length - 1) + ";";
        //     command.CommandText = query;
        //     if(command.ExecuteNonQuery() > 0)
        //     {
        //         result = true;
        //     }

        //     connection.Close();

        //     return result;
        // }

        public ScheduleDetail GetScheduleDetailBySchedId(int? schedId)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            query = $"select * from SchedulesDetails where sched_id = " + schedId + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            ScheduleDetail schedDetail = null;
            using (reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    schedDetail = GetScheduleDetail(reader);
                }
            }

            connection.Close();

            return schedDetail;
        }

        public List<ScheduleDetail> GetScheduleDetailsByScheId(int? scheId)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            query = $"select * from SchedulesDetails where sche_id = " + scheId + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            List<ScheduleDetail> schedDetails = null;
            using (reader = command.ExecuteReader())
            {
                schedDetails = new List<ScheduleDetail>();
                while (reader.Read())
                {
                    schedDetails.Add(GetScheduleDetail(reader));
                }
            }

            connection.Close();

            return schedDetails;
        }

        public ScheduleDetail GetScheduleDetail(MySqlDataReader reader)
        {
            int schedId = reader.GetInt32("sched_id");
            int scheId = reader.GetInt32("sche_id");
            DateTime schedTimeStart = reader.GetDateTime("sched_timeStart");
            DateTime schedTimeEnd = reader.GetDateTime("sched_timeEnd");
            string schedRoomSeats = reader.GetString("sched_roomSeats");

            ScheduleDetail scheduleDetail = new ScheduleDetail(schedId, scheId, schedTimeStart, schedTimeEnd, schedRoomSeats);

            return scheduleDetail;
        }
    }
}