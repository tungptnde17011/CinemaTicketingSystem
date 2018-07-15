using System;
using CTS_Persistence;
using CTS_DAL;
using System.Text.RegularExpressions;

namespace CTS_BL
{
    public class CinemaBL
    {
        private CinemaDAL cdal = new CinemaDAL();
        public Cinema GetCinemaByCineId(int? cineId)
        {
            if (cineId == null)
            {
                return null;
            }
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(cineId.ToString());

            if (matchCollection.Count < cineId.ToString().Length)
            {
                return null;
            }
            return cdal.GetCinemaByCineId(cineId);
        }
    }
}