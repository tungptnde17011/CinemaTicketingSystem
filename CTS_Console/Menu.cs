using System;
using System.Text;
using System.Text.RegularExpressions;
using CTS_BL;
using CTS_Persistence;

namespace CTS_Console
{
    public class Menus
    {
        public void MenuChoice()
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
        public void MenuLogin()
        {
            Console.Clear();
            string row1 = "========================================";
            string row2 = "----------------------------------------";
            Console.WriteLine(row1);
            Console.WriteLine(" ĐĂNG NHẬP");
            Console.WriteLine(row2);
            Console.Write("Tên đăng nhập: ");
            string un = Console.ReadLine();
            Console.Write("Mật khẩu: ");
            string pw = Password();
            string choice;
            while ((validate(un) == false) || (validate(pw) == false))
            {
                Console.Write("Tên đăng nhập và mật khẩu không được chứa kí tự đặc biệt, bạn có muốn tiếp tục đăng nhập không? (C/K)");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "C":
                        break;
                    case "c":
                        break;
                    case "K":
                        MenuChoice();
                        break;
                    case "k":
                        MenuChoice();
                        break;
                    default:

                        continue;
                        // break;
                }
                Console.Clear();
                // Console.WriteLine("Username và Password không được chứa ký tự đặc biệt! ");
                Console.WriteLine(row1);
                Console.WriteLine(" ĐĂNG NHẬP");
                Console.WriteLine(row2);
                Console.Write("Tên đăng nhập: ");
                un = Console.ReadLine();
                Console.Write("Mật khẩu: ");
                pw = Password();
            }


            UserBL ubl = new UserBL();
            while (ubl.Login(un, pw) == null)
            {

                Console.Write("Tên đăng nhập hoặc mật khẩu không đúng, bạn có muốn tiếp tục đăng nhập không? (C/K)");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "C":
                        break;
                    case "c":
                        break;
                    case "K":
                        MenuChoice();
                        break;
                    case "k":
                        MenuChoice();
                        break;
                    default:
                        // Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                        continue;
                        // break;
                }
                Console.Clear();
                // Console.WriteLine("Sai Username, Password!");
                Console.WriteLine(row1);
                Console.WriteLine(" ĐĂNG NHẬP");
                Console.WriteLine(row2);
                Console.Write("Tên đăng nhập: ");
                un = Console.ReadLine();
                Console.Write("Mật khẩu: ");
                pw = Password();
                while ((validate(un) == false) || (validate(pw) == false))
                {
                    Console.Write("Tên đăng nhập và mật khẩu không được chứa kí tự đặc biệt, bạn có muốn tiếp tục đăng nhập không? (C/K)");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "C":
                            break;
                        case "c":
                            break;
                        case "K":
                            MenuChoice();
                            break;
                        case "k":
                            MenuChoice();
                            break;
                        default:
                            // Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                            continue;
                            // break;
                    }
                    Console.Clear();
                    // Console.WriteLine("Username và Password không được chứa ký tự đặc biệt! ");
                    Console.WriteLine(row1);
                    Console.WriteLine(" ĐĂNG NHẬP");
                    Console.WriteLine(row2);
                    Console.Write("Tên đăng nhập: ");
                    un = Console.ReadLine();
                    Console.Write("Mật khẩu: ");
                    pw = Password();
                }

            }
            if (ubl.Login(un, pw).Type == "m")
            {
                menuManager(ubl.Login(un, pw));
            }
            else if (ubl.Login(un, pw).Type == "s")
            {
                menuStaff(ubl.Login(un, pw));
            }
        }
        public bool validate(string str)
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
        public void menuManager(User us)
        {
            Console.Clear();
            string[] managermenu = { "Tạo lịch chiếu phim", "Đăng xuất" };
            int mana = Menu("Chào mừng bạn đến với DHB Cineplex", managermenu);
            switch (mana)
            {
                case 1:
                    Console.Clear();
                    ConsoleManager cm = new ConsoleManager();
                    cm.CreateSchedule(us);
                    break;
                case 2:
                    Console.Clear();
                    MenuChoice();
                    break;
                default:
                    menuManager(us);
                    return;
            }
        }
        public void menuStaff(User us)
        {
            Console.Clear();
            string[] staffmenu = { "Đặt vé.", "Đăng xuất." };
            int staff = Menu("Chào mừng bạn đến với BHD Cineplex", staffmenu);
            switch (staff)
            {
                case 1:
                    Console.Clear();
                    ConsoleStaff cs = new ConsoleStaff();
                    cs.Ticket(us);
                    break;
                case 2:
                    Console.Clear();
                    MenuChoice();
                    break;
                default:
                    menuStaff(us);
                    return;
            }
        }
        public string Password()
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
        public short Menu(string title, string[] menuItems)
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