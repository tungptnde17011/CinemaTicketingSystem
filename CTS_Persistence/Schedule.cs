using System;
using System.Collections.Generic;

namespace CTS_Persistence
{
    public class Schedule
    {
        public int? ScheId { get; set; }
        public int ScheStatus { get; set; }
        public string ScheWeekdays { get; set; }
        public string ScheTimeline { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
        public List<ScheduleDetail> ScheduleDetails { get; set; }

        public Schedule() { }
        public Schedule(int? scheId, int scheStatus, string scheWeekdays, string scheTimeline, int roomId, int movieId, List<ScheduleDetail> scheduleDetails)
        {
            this.ScheId = scheId;
            this.ScheStatus = scheStatus;
            this.ScheWeekdays = scheWeekdays;
            this.ScheTimeline = scheTimeline;
            this.RoomId = roomId;
            this.MovieId = movieId;
            this.ScheduleDetails = scheduleDetails;
        }
        public override bool Equals(object obj)
        {
            Schedule sche = (Schedule)obj;

            return ScheId == sche.ScheId;
        }

        public override int GetHashCode()
        {
            return (ScheId + ScheStatus + ScheWeekdays + ScheTimeline + RoomId + MovieId + ScheduleDetails).GetHashCode();
        }
    }
}