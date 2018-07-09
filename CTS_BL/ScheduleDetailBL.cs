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
            
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(schedId.ToString());
            if (schedId == null)
            {
                return null;
            }
            else if (matchCollection.Count < schedId.ToString().Length)
            {
                return null;
            }
            return sddal.GetScheduleDetailBySchedId(schedId);
        }
        public List<ScheduleDetail> GetScheduleDetailsByScheId(int? scheId)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(scheId.ToString());
            if (scheId == null)
            {
                return null;
            }
            else if (matchCollection.Count < scheId.ToString().Length)
            {
                return null;
            }
            return sddal.GetScheduleDetailsByScheId(scheId);
        }
    }
}