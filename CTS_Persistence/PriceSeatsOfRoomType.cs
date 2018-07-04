using System;

namespace CTS_Persistence
{
    public class PriceSeatsOfRoomType
    {
        public string RTName { get; set; }
        public string STType { get; set; }
        public double Price { get; set; }

        public PriceSeatsOfRoomType() { }
        public PriceSeatsOfRoomType(string rtName, string stType, double price)
        {
            this.RTName = rtName;
            this.STType = stType;
            this.Price = price;
        }
    }
}