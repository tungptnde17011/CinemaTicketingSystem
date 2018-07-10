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
                    Environment.Exit(0);
                    break;
            }
        }
        private static void MenuLogin()
        {
            Console.Clear();
            string row1 = "========================================";
            string row2 = "----------------------------------------";
            Console.WriteLine(row1);
            Console.WriteLine(" ĐĂNG NHẬP");
            Console.WriteLine(row2);
            Console.Write("Nhập Username: ");
            string un = Console.ReadLine();
            Console.Write("Nhập Password: ");
            string pw = Password();
            string choice;
            while ((validate(un, 0) == false) || (validate(pw, 0) == false))
            {
                Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "Y":
                        break;
                    case "y":
                        break;
                    case "n":
                        MenuChoice();
                        break;
                    case "N":
                        MenuChoice();
                        break;
                    default:

                        continue;
                        // break;
                }
                Console.Clear();
                Console.WriteLine("Username và Password không được chứa ký tự đặc biệt! ");
                Console.WriteLine(row1);
                Console.WriteLine(" ĐĂNG NHẬP");
                Console.WriteLine(row2);
                Console.Write("Nhập lại Username: ");
                un = Console.ReadLine();
                Console.Write("Nhập lại Password: ");
                pw = Password();
            }


            UserBL ubl = new UserBL();
            while (ubl.Login(un, pw) == null)
            {

                Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "Y":
                        break;
                    case "y":
                        break;
                    case "n":
                        MenuChoice();
                        break;
                    case "N":
                        MenuChoice();
                        break;
                    default:
                        // Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                        continue;
                        // break;
                }
                Console.Clear();
                Console.WriteLine("Sai Username, Password!");
                Console.WriteLine(row1);
                Console.WriteLine(" ĐĂNG NHẬP");
                Console.WriteLine(row2);
                Console.Write("Nhập lại Username: ");
                un = Console.ReadLine();
                Console.Write("Nhập lại Password: ");
                pw = Password();
                while ((validate(un, 0) == false) || (validate(pw, 0) == false))
                {
                    Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "Y":
                            break;
                        case "y":
                            break;
                        case "n":
                            MenuChoice();
                            break;
                        case "N":
                            MenuChoice();
                            break;
                        default:
                            // Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                            continue;
                            // break;
                    }
                    Console.Clear();
                    Console.WriteLine("Username và Password không được chứa ký tự đặc biệt! ");
                    Console.WriteLine(row1);
                    Console.WriteLine(" ĐĂNG NHẬP");
                    Console.WriteLine(row2);
                    Console.Write("Nhập lại Username: ");
                    un = Console.ReadLine();
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
        private static bool validate(string str, int status)
        {
            if (status == 0)
            {
                Regex regex = new Regex("[a-zA-Z0-9_]");
                MatchCollection matchCollectionstr = regex.Matches(str);
                // Console.WriteLine(matchCollectionstr.Count);
                if (matchCollectionstr.Count < str.Length)
                {
                    return false;
                }
                return true;
            }
            else if (status == 1)
            {
                Regex regex = new Regex("[0-9]");
                MatchCollection matchCollectionstr = regex.Matches(str);
                if ((str.Length < 1) || (str.Length > 2) || (matchCollectionstr.Count < str.Length) || (Int16.Parse(str)) > 23 || (Int16.Parse(str) < 0))
                {
                    return false;
                }
                return true;
            }
            else if (status == 2)
            {
                Regex regex = new Regex("[0-9]");
                MatchCollection matchCollectionstr = regex.Matches(str);
                if ((str.Length < 1) || (str.Length > 2) || (matchCollectionstr.Count < str.Length) || (Int16.Parse(str)) > 60 || (Int16.Parse(str) < 0))
                {
                    return false;
                }
                return true;
            }
            return false;
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