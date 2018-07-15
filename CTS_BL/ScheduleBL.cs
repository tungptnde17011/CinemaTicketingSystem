using System;
using CTS_Persistence;
using CTS_DAL;
using System.Collections.Generic;

namespace CTS_BL
{
    public class ScheduleBL
    {
        ScheduleDAL sdal = new ScheduleDAL();
        public bool CreateSchedule(Schedule sche)
        {
            return sdal.CreateSchedule(sche);
        }
        public List<Schedule> GetSchedulesByMovieId(int? movieId)
        {
            if (movieId == null)
            {
                return null;
            }
            return sdal.GetSchedulesByMovieId(movieId);
        }
        public Schedule GetScheduleByMovieIdAndRoomId(int? movieId, int? roomId)
        {
            if ((movieId == null) || (roomId == null))
            {
                return null;
            }
            return sdal.GetScheduleByMovieIdAndRoomId(movieId, roomId);
        }
        public Schedule GetScheduleByScheId(int? scheId)
        {
            if (scheId == null)
            {
                return null;
            }
            return sdal.GetScheduleByScheId(scheId);
        }
    }
}