using System;
using CTS_Persistence;
using CTS_DAL;

namespace CTS_BL
{
    public class TicketBL
    {
        TicketDAL tdal = new TicketDAL();
        public bool SellTicket(ScheduleDetail SchedDeltail)
        {
            return tdal.SellTicket(SchedDeltail);
        }
    }
}