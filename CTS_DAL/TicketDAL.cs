using System;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class TicketDAL
    {
        private MySqlConnection connection;
        private string query;

        public TicketDAL()
        {
            connection = DBHelper.OpenConnection();
        }

        public bool BuyTicket(ScheduleDetail schedDetail)
        {
            bool result = false;
            if(schedDetail == null || schedDetail.SchedId == null || schedDetail.SchedId == 0 || 
                schedDetail.SchedRoomSeats == null || schedDetail.SchedRoomSeats.Equals(""))
            {
                return result;
            }

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            query = @"update SchedulesDetails set sched_roomSeats = '"+ schedDetail.SchedRoomSeats +"' where sched_id = "+ schedDetail.SchedId +";";
            MySqlCommand command = new MySqlCommand(query, connection);
            if(command.ExecuteNonQuery() > 0)
            {
                result = true;
            }

            connection.Close();

            return result;
        }
    }
}