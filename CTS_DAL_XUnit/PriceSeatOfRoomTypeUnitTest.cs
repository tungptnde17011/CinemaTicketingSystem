using System;
using Xunit;
using CTS_DAL;
using System.Collections.Generic;
using CTS_Persistence;
using MySql.Data.MySqlClient;

namespace CTS_DAL_XUnit
{
    public class PriceSeatOfRoomTypeUnitTest
    {
        private PriceSeatOfRoomTypeDAL priceSeatOfRoomTypeDAL = new PriceSeatOfRoomTypeDAL();
        private MySqlConnection connection = DBHelper.OpenConnection();
        private MySqlDataReader reader;
        private string query;

        [Fact]
        public void GetPriceSeatsOfRoomTypeByRTNameTest1()
        {
            string rtName = "3D";
            List<PriceSeatOfRoomType> priceSeatsOfRoomType = priceSeatOfRoomTypeDAL.GetPriceSeatsOfRoomTypeByRTName(rtName);

            query = $"select * from PriceSeatsOfRoomTypes where rt_name = '" + rtName + "' order by rand() limit 1;";
            PriceSeatOfRoomType priceSeatOfRoomTypeRand = GetPriceSeatOfRoomTypeExecQuery(query);

            query = $"select * from PriceSeatsOfRoomTypes where rt_name = '" + rtName + "' order by st_type asc limit 1;";
            PriceSeatOfRoomType priceSeatOfRoomTypeTop = GetPriceSeatOfRoomTypeExecQuery(query);

            query = $"select * from PriceSeatsOfRoomTypes where rt_name = '" + rtName + "' order by st_type desc limit 1;";
            PriceSeatOfRoomType priceSeatOfRoomTypeBottom = GetPriceSeatOfRoomTypeExecQuery(query);

            Assert.NotNull(priceSeatsOfRoomType);
            Assert.NotNull(priceSeatOfRoomTypeRand);
            Assert.NotNull(priceSeatOfRoomTypeTop);
            Assert.NotNull(priceSeatOfRoomTypeBottom);

            Assert.Contains(priceSeatOfRoomTypeRand, priceSeatsOfRoomType);

            Assert.True(priceSeatsOfRoomType.IndexOf(priceSeatOfRoomTypeTop) == 0);
            Assert.True(priceSeatsOfRoomType.IndexOf(priceSeatOfRoomTypeBottom) == (priceSeatsOfRoomType.Count - 1));
        }

        [Fact]
        public void GetPriceSeatsOfRoomTypeByRTNameTest2()
        {
            Assert.Equal(new List<PriceSeatOfRoomType>(), priceSeatOfRoomTypeDAL.GetPriceSeatsOfRoomTypeByRTName("0"));
        }

        [Fact]
        public void GetPriceSeatsOfRoomTypeByRTNameTest3()
        {
            Assert.Null(priceSeatOfRoomTypeDAL.GetPriceSeatsOfRoomTypeByRTName(null));
        }

        private PriceSeatOfRoomType GetPriceSeatOfRoomTypeExecQuery(string query)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            PriceSeatOfRoomType priceSeatOfRoomType = null;
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    priceSeatOfRoomType = priceSeatOfRoomTypeDAL.GetPriceSeatOfRoomType(reader);
                }
            }

            connection.Close();

            return priceSeatOfRoomType;
        }
    }
}