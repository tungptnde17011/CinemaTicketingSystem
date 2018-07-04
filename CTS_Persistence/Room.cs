using System;

namespace CTS_Persistence
{
    public class Room
    {
        public int? RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomSeats { get; set; }
        public string RTName { get; set; }

        public Room() { }
        public Room(int? roomId, string roomName, string roomSeats, string rtName)
        {
            this.RoomId = roomId;
            this.RoomName = roomName;
            this.RoomSeats = roomSeats;
            this.RTName = rtName;
        }

        public override bool Equals(object obj)
        {
            Room room = (Room)obj;

            return RoomId == room.RoomId;
        }

        public override int GetHashCode()
        {
            return (RoomId + RoomName + RoomSeats + RTName).GetHashCode();
        }
    }
}