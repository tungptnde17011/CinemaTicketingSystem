using System;
using CTS_Persistence;
using CTS_DAL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CTS_BL
{
    public class ScheduleDetailBL
    {
        private ScheduleDetailDAL sddal = new ScheduleDetailDAL();
        // public bool CreateScheduleDetails(List<ScheduleDetail> schedDetails)
        // {
        //     return sddal.CreateScheduleDetails(schedDetails);
        // }
        public ScheduleDetail GetScheduleDetailBySchedId(int? schedId)
        {
            if (schedId == null)
            {
                return null;
            }

            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(schedId.ToString());
            if (matchCollection.Count < schedId.ToString().Length)
            {
                return null;
            }
            return sddal.GetScheduleDetailBySchedId(schedId);
        }
        public List<ScheduleDetail> GetScheduleDetailsByScheId(int? scheId)
        {
            if (scheId == null)
            {
                return null;
            }

            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(scheId.ToString());
            if (matchCollection.Count < scheId.ToString().Length)
            {
                return null;
            }
            return sddal.GetScheduleDetailsByScheId(scheId);
        }
        public List<ScheduleDetail> GetScheduleDetailsByScheIdAndTimeNow(int? scheId)
        {
            if (scheId == null)
            {
                return null;
            }
            return sddal.GetScheduleDetailsByScheIdAndDateNow(scheId);
        }
    }
}