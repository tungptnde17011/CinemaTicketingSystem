using System;
using Xunit;
using CTS_BL;

namespace CTS_BL_XUnit
{
    public class UserUnitTest
    {
        [Fact]
        public void LoginTest1()
        {
            UserBL userBL = new UserBL();
            Assert.NotNull(userBL.Login("manager_01", "123456"));
        }

        [Fact]
        public void LoginTest2()
        {
            UserBL userBL = new UserBL();
            Assert.NotNull(userBL.Login("staff_01", "123456"));
        }
        [Fact]
        public void LoginTest3()
        {
            UserBL userBL = new UserBL();
            Assert.Null(userBL.Login("customer_01", "123456789"));
        }

        [Fact]
        public void LoginTest4()
        {
            UserBL userBL = new UserBL();
            Assert.Null(userBL.Login("'#!@#!@'", "'><?<>'"));
        }
        [Fact]
        public void LoginTest5()
        {
            UserBL userBL = new UserBL();
            Assert.Null(userBL.Login("dasdsa",null));
        }
        [Fact]
        public void LoginTest6()
        {
            UserBL userBL = new UserBL();
            Assert.Null(userBL.Login(null, "><?<>"));
        }
    }
}
