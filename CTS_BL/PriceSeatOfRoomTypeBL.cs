using System;
using CTS_Persistence;
using CTS_DAL;
using System.Collections.Generic;

namespace CTS_BL
{
    public class PriceSeatOfRoomTypeBL
    {
        PriceSeatOfRoomTypeDAL psortdal = new PriceSeatOfRoomTypeDAL();
        public List<PriceSeatOfRoomType> GetPriceSeatsOfRoomTypeByRTName(string rtName)
        {
            return psortdal.GetPriceSeatsOfRoomTypeByRTName(rtName);
        }
    }
}