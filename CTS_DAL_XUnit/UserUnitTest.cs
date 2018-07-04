using System;
using Xunit;
using CTS_DAL;

namespace CTS_DAL_XUnit
{
    public class UserUnitTest
    {
        UserDAL userDAL =  new UserDAL();

        [Fact]
        public void LoginTest1()
        {
            Assert.NotNull(userDAL.Login("manager_01", "123456"));
        }

        [Fact]
        public void LoginTest2()
        {
            Assert.NotNull(userDAL.Login("staff_01", "123456"));
        }

        [Fact]
        public void LoginTest3()
        {
            Assert.Null(userDAL.Login("customer_01","123456789"));
        }

        [Fact]
        public void LoginTest4()
        {
            Assert.Null(userDAL.Login("?^%",".:=="));
        }
    }
}