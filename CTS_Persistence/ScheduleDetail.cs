using System;

namespace CTS_Persistence
{
    public class ScheduleDetail
    {
        public int? SchedId { get; set; }
        public DateTime SchedTimeStart { get; set; }
        public DateTime SchedTimeEnd { get; set; }
        public string SchedRoomSeats { get; set; }
        public int? ScheId { get; set; }

        public ScheduleDetail() { }
        public ScheduleDetail(int? schedId, int? scheId, DateTime schedTimeStart, DateTime schedTimeEnd, string schedRoomSeats)
        {
            this.SchedId = schedId;
            this.ScheId = scheId;
            this.SchedTimeStart = schedTimeStart;
            this.SchedTimeEnd = schedTimeEnd;
            this.SchedRoomSeats = schedRoomSeats;
        }

        public override bool Equals(object obj)
        {
            ScheduleDetail schedDetail = (ScheduleDetail)obj;

            return SchedId == schedDetail.SchedId;
        }

        public override int GetHashCode()
        {
            return ("" + SchedId + ScheId + SchedTimeStart + SchedTimeEnd + SchedRoomSeats).GetHashCode();
        }
    }

}