using System;
using Xunit;
using CTS_DAL;
using MySql.Data.MySqlClient;

namespace CTS_DAL_XUnit
{
    public class UserUnitTest
    {
        [Fact]
        public void testGetConnectionTest()
        {
            UserDAL userDAL =  new UserDAL();
            Assert.NotNull(userDAL.Login("manager_01", "staff_01"));
        }
    }
}