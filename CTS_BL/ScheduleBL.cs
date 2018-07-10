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
            foreach (var item in GetSchedulesByMovieId(sche.RoomId))
            {
                if(sche.ScheTimeline == item.ScheTimeline && sche.RoomId == item.RoomId )
                {
                    return false;
                }
            }
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
    }
}