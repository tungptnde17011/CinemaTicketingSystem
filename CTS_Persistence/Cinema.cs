using System;

namespace CTS_Persistence
{
    public class Cinema
    {
        public int? CineId {get;set;}
        public string CineAddress {get;set;}
        public string CineName{get;set;}
        public string CinePhone{get;set;}
        public Cinema(){}
        public Cinema(string cineAddress, string cineName, string cinePhone)
        {
            this.CineAddress = cineAddress;
            this.CineName = cineName;
            this.CinePhone = cinePhone;
        }
    }
}
