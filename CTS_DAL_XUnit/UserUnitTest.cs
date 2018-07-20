using System;
using Xunit;
using CTS_DAL;
using CTS_Persistence;

namespace CTS_DAL_XUnit
{
    public class UserUnitTest
    {
        private UserDAL userDAL = new UserDAL();

        [Theory]
        [InlineData("manager_01", "123456")]
        [InlineData("staff_01", "123456")]
        public void LoginTest1(string username, string password)
        {
            User user = userDAL.Login(username, password);

            Assert.NotNull(user);
            Assert.Equal(username, user.Username);
        }

        [Theory]
        [InlineData("customer_01", "123456789")]
        [InlineData("'?^%'", "'.:=='")]
        [InlineData("'?^%'",null)]
        [InlineData(null, "'.:=='")]
        public void LoginTest3(string username, string password)
        {
            Assert.Null(userDAL.Login(username, password));
        }
    }
}