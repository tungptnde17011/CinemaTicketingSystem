using System;
using Xunit;
using CTS_DAL;
using MySql.Data.MySqlClient;

namespace CTS_DAL_XUnit
{
    public class UserUnitTest
    {
        [Fact]
        public void LoginTest1()
        {
            UserDAL userDAL =  new UserDAL();
            Assert.NotNull(userDAL.Login("manager_01", "123456"));
        }

        [Fact]
        public void LoginTest2()
        {
            UserDAL userDAL =  new UserDAL();
            Assert.NotNull(userDAL.Login("staff_01", "123456"));
        }

        [Fact]
        public void LoginTest3()
        {
            UserDAL userDAL =  new UserDAL();
            Assert.Null(userDAL.Login("customer_01","123456789"));
        }
    }
}