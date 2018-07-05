using System;
using System.Text;
using System.Security;
using CTS_BL;
using System.Text.RegularExpressions;
namespace CTS_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuChoice();
        }
        private static void MenuChoice()
        {
            Console.Clear();
            string[] choice = { "Đăng nhập", "Thoát chương trình" };
            int choose = Menu("Chào mừng bạn", choice);
            switch (choose)
            {
                case 1:
                    MenuLogin();
                    break;
                case 2:
                    return;
            }
        }
        private static void MenuLogin()
        {
            Console.Clear();
            string row1 = "========================================";
            string row2 = "----------------------------------------";
            Console.WriteLine(row1); Console.WriteLine(" ĐĂNG NHẬP");
            Console.WriteLine(row2); Console.Write("Nhập Username: ");
            string un = Console.ReadLine();
            while (validate(un) == false)
            {
                Console.Clear();
                Console.WriteLine("Username không được chứa ký tự đặc biệt! ");
                Console.WriteLine(row1);
                Console.WriteLine(" ĐĂNG NHẬP");
                Console.WriteLine(row2);
                Console.Write("Nhập lại Username: ");
                un = Console.ReadLine();
            }
            Console.Write("Nhập Password: ");
            string pw = Password();
            while (validate(pw) == false)
            {
                Console.WriteLine("Password không được chứa ký tự đặc biệt!");
                Console.WriteLine("Bạn có muốn trở về màn hình chính?(Y/N)");
                char choice = Convert.ToChar(Console.ReadLine());
                switch (choice)
                {
                    case 'y':
                        MenuChoice();
                        break;
                    case 'Y':
                        MenuChoice();
                        break;
                    case 'n':
                        Console.Write("Nhập lại Password: ");
                        pw = Password();
                        break;
                    case 'N':
                        Console.Write("Nhập lại Password: ");
                        pw = Password();
                        break;
                    default:
                        continue;
                }
                return;
            }
            UserBL ubl = new UserBL();
            while (ubl.Login(un, pw) == null)
            {
                Console.Clear();
                Console.WriteLine("Sai Username, Password!");
                Console.WriteLine(row1);
                Console.WriteLine(" ĐĂNG NHẬP");
                Console.WriteLine(row2);
                Console.Write("Nhập lại Username: ");
                un = Console.ReadLine();
                while (validate(un) == false)
                {
                    Console.Clear();
                    Console.WriteLine("Username không được chứa ký tự đặc biệt! ");
                    Console.WriteLine(row1);
                    Console.WriteLine(" ĐĂNG NHẬP");
                    Console.WriteLine(row2);
                    Console.Write("Nhập lại Username: ");
                    un = Console.ReadLine();
                }
                Console.Write("Nhập lại Password: ");
                pw = Password();
                while (validate(pw) == false)
                {
                    Console.WriteLine("Password không được chứa ký tự đặc biệt!");
                    Console.WriteLine("Bạn có muốn trở về màn hình chính?(Y/N)");
                    char choice = Convert.ToChar(Console.ReadLine());
                    switch (choice)
                    {
                        case 'y':
                            MenuChoice();
                            break;
                        case 'Y':
                            MenuChoice();
                            break;
                        case 'n':
                            break;
                        case 'N':
                            break;
                        default:
                            continue;
                    }
                    Console.Write("Nhập lại Password: ");
                    pw = Password();
                }
            }
            if (ubl.Login(un, pw).Type == "m")
            {
                Console.Clear();
                string[] managermenu = { "Tạo lịch chiếu phim", "Đăng xuất" };
                int mana = Menu("Chào mừng bạn đến với DHB Cineplex", managermenu);
                switch (mana)
                {
                    case 2:
                        Console.Clear();
                        MenuChoice();
                        break;
                }
            }
            else if (ubl.Login(un, pw).Type == "s")
            {
                Console.Clear();
                string[] staffmenu = { "Đặt vé.", "Đăng xuất." };
                int staff = Menu("Chào mừng bạn đến với BHD Cineplex", staffmenu);
                switch (staff)
                {
                    case 2:
                        Console.Clear();
                        MenuChoice();
                        break;
                }
            }
        }
        private static bool validate(string str)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionstr = regex.Matches(str);
            MatchCollection matchCollectionPassword = regex.Matches(str);
            if (matchCollectionstr.Count <= 0)
            {
                return false;
            }
            return true;
        }
        private static string Password()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }
                    continue;
                }
                Console.Write('*');
                sb.Append(cki.KeyChar);
            }
            return sb.ToString();
        }
        private static short Menu(string title, string[] menuItems)
        {
            short choose = 0;
            string line1 = "========================================";
            string line2 = "----------------------------------------";
            Console.WriteLine(line1);
            Console.WriteLine(" " + title);
            Console.WriteLine(line2);
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + menuItems[i]);
            }
            Console.WriteLine(line2);
            do
            {
                Console.Write("Bạn chọn: ");
                try
                {
                    choose = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Bạn chọn không đúng!");
                    continue;
                }
            }
            while (choose <= 0 || choose > menuItems.Length);
            return choose;
        }
    }
}