using System;

namespace CTS_Persistence
{
    public class PriceSeatOfRoomType
    {
        public string RTName { get; set; }
        public string STType { get; set; }
        public double Price { get; set; }

        public PriceSeatOfRoomType() { }
        public PriceSeatOfRoomType(string rtName, string stType, double price)
        {
            this.RTName = rtName;
            this.STType = stType;
            this.Price = price;
        }

        public override bool Equals(object obj)
        {
            PriceSeatOfRoomType priceSeatOfRoomType = (PriceSeatOfRoomType)obj;

            return RTName == priceSeatOfRoomType.RTName && STType == priceSeatOfRoomType.STType;
        }

        public override int GetHashCode()
        {
            return (RTName + STType + Price).GetHashCode();
        }
    }
}