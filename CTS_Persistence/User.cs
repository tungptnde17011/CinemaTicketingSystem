using System;

namespace CTS_Persistence
{
    public class User
    {
        public string Username{get;set;}
        public string Password{get;set;}
        public string Type{get;set;}
        public Cinema Cine{get;set;}
        public User() {}
        public User(string userName, string password, string type, Cinema cine)
        {
            this.Username = userName;
            this.Password = password;
            this.Type = type;
            this.Cine = cine;
        }
    }
}