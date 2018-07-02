using System;

namespace CTS_Persistence
{
    public class ScheduleDetail
    {
        public int? SchedId {get;set;}
        public DateTime SchedDateShow{get;set;}
        public DateTime SchedTimeStart{get;set;}
        public DateTime SchedTimeEnd{get;set;}
        public string SchedRoomSeats{get;set;}
        public int ScheId{get;set;}
        public ScheduleDetail() {}
        public ScheduleDetail(int scheId, DateTime schedDateShow, DateTime schedTimeStart, DateTime schedTimeEnd, string schedRoomSeats)
        {
            this.ScheId = scheId;
            this.SchedDateShow = schedDateShow;
            this.SchedTimeStart = schedTimeStart;
            this.SchedTimeEnd = schedTimeEnd;
            this.SchedRoomSeats = schedRoomSeats;
        }
    }
    
}