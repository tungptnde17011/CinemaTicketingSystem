using System;
using Xunit;
using CTS_DAL;
using MySql.Data.MySqlClient;

namespace CTS_DAL_XUnit
{
    public class DBHelperUnitTest
    {
        [Fact]
        public void GetConnectionTest()
        {
            Assert.NotNull(DBHelper.GetConnection());
            // DBHelper.CloseConnection();
        }

        [Fact]
        public void OpenConnectionTest()
        {
            Assert.NotNull(DBHelper.OpenConnection());
            // DBHelper.CloseConnection();
        }
    }
}
