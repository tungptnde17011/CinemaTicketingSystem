using System;
using CTS_Persistence;
using CTS_DAL;

namespace CTS_BL
{
    public class TicketBL
    {
        TicketDAL tdal = new TicketDAL();
        public bool BuyTicket(ScheduleDetail SchedDeltail)
        {
            return tdal.BuyTicket(SchedDeltail);
        }
    }
}