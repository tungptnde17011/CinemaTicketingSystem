using System;
using System.Text;
using System.Security;
using CTS_BL;
using System.Text.RegularExpressions;
using CTS_Persistence;
namespace CTS_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menus m = new Menus();
            m.MenuChoice(null);
        }

    }
}