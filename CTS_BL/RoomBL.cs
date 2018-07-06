

using System;
using CTS_Persistence;
using CTS_DAL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CTS_BL
{
    public class RoomBL
    {
        private RoomDAL rdal = new RoomDAL();
        public Room GetRoomByRoomId(int? roomId)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(roomId.ToString());
            if (matchCollection.Count < roomId.ToString().Length)
            {
                return null;
            }
            return rdal.GetRoomByRoomId(roomId);
        }
        public List<Room> GetRoomByCineId(int? cineId)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(cineId.ToString());
            if (matchCollection.Count < cineId.ToString().Length)
            {
                return null;
            }
            return rdal.GetRoomsByCineId(cineId);
        }
    }
}