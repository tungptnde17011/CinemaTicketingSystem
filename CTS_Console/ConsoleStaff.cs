using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CTS_BL;
using CTS_Persistence;

namespace CTS_Console
{

    public class ConsoleStaff
    {
        private int input(string str)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(str);
            while ((matchCollection.Count < str.Length) || (str == ""))
            {
                Console.Write("Dữ liệu nhập vào phải là số tự nhiên, mời nhập lại: "); str = Console.ReadLine();
                matchCollection = regex.Matches(str);
            }
            return Convert.ToInt32(str);
        }
        TicketBL tbl = new TicketBL();
        Schedule sche = new Schedule();
        ScheduleDetail sched = new ScheduleDetail();
        ScheduleBL sbl = new ScheduleBL();
        ScheduleDetailBL sdbl = new ScheduleDetailBL();
        Menus mn = new Menus();
        public void Ticket(User us)
        {
            Console.Clear();
            string row1 = "========================================";
            string row2 = "----------------------------------------";
            Console.WriteLine(row1);
            Console.WriteLine("Đặt vé.");
            Console.WriteLine(row2);
            Console.WriteLine("[Danh sách Phim]\n");
            MovieBL mbl = new MovieBL();
            string[] properties = { "MovieId", "MovieName", "MovieCategory", "MovieTime", "MovieDateStart", "MovieDateEnd" };
            string[] cols = { "ID", "Tên phim", "Thể loại", "Thời lượng", "Ngày bắt đầu", "Ngày kết thúc" };
            List<Movie> movies = mbl.GetMoviesByCineIdAndDateNow(us.Cine.CineId);
            DisplayTableData(movies, properties, cols, "dd/MM/yyyy");
            Console.WriteLine(row1);
            Console.Write("\nChọn phim(Theo ID): "); sche.MovieId = input(Console.ReadLine());
            while (mbl.GetMovieByMovieId(sche.MovieId) == null)
            {
                Console.Write("Không có ID này, mời nhập lại: "); sche.MovieId = input(Console.ReadLine());
            }
            
            List<Schedule> ls = sbl.GetSchedulesByMovieId(sche.MovieId);
            List<ScheduleDetail> lsd = new List<ScheduleDetail>();
            foreach (var itemListSchedule in ls)
            {
                List<ScheduleDetail> newlsd = sdbl.GetScheduleDetailsBySchedIdAndTimeNow(itemListSchedule.ScheId);
                foreach (var itemListScheduleDetail in newlsd)
                {
                    lsd.Add(itemListScheduleDetail);
                }
            }
            if (lsd.Count <= 0)
            {
                while (true)
                {
                    Console.Write("Không còn lịch chiếu cho phim bạn chọn trong ngày hôm nay. Bạn có muốn chọn phim khác?(Y/N)");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "Y":
                            Ticket(us);
                            return;
                        case "y":
                            Ticket(us);
                            return;
                        case "n":
                            mn.menuStaff(us);
                            return;
                        case "N":
                            mn.menuStaff(us);
                            return;
                        default:

                            continue;
                            // break;
                    }
                }


            }
            Console.Clear();
            Console.WriteLine(row1);
            Console.WriteLine("Đặt vé.");
            Console.WriteLine(row2);
            Console.WriteLine("[Danh sách lịch chiếu]");
            int count = 0;
            foreach (var itemlsd in lsd)
            {
                count++;
                Console.WriteLine(count+". Giờ bắt đầu: "+itemlsd.SchedTimeStart?.ToString("dd/MM/yyyy HH:mm:ss"));
                
            }
            Console.WriteLine(row1);
            Console.Write("Chọn lịch chiếu: ");
            int scheno = input(Console.ReadLine());
            Console.WriteLine(lsd[0].SchedId);
            while (scheno > lsd.Count)
            {
                Console.Write("Chọn sai lịch chiếu, mời nhập lại: ");
                scheno = input(Console.ReadLine());
            }
            sched.SchedId = lsd[scheno-1].SchedId;
             
            string[] seat = ChoiceSeats(sched);
        }
        public string[] ChoiceSeats(ScheduleDetail sched)
        {
            // Console.Clear();
            string roomSeats = sched.SchedRoomSeats;
           Console.WriteLine(roomSeats);
            string[] seats = roomSeats.Split(" ");

            DrawRoomSeats(seats);

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            string[] choiced = choice.Split(",");
            int count = 0;

            for (int i = 0; i < choiced.Length; i++)
            {
                for (int j = 0; j < seats.Length; j++)
                {
                    if (seats[j] != "." && seats[j] != "n")
                    {
                        if (choiced[i].Trim() == seats[j].Substring(2))
                        {
                            choiced[i] = seats[j];
                            seats[j] = new String('X', seats[j].Length);
                            count++;
                            break;
                        }
                    }
                }
            }

            if (count == choiced.Length && count > 0)
            {
                roomSeats = "";
                for (int i = 0; i < seats.Length; i++)
                {
                    roomSeats += seats[i] + " ";
                }
                sched.SchedRoomSeats = roomSeats.Trim();
                return choiced;
            }

            return null;
        }

        private void DrawRoomSeats(string[] seats)
        {
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == "n")
                {
                    Console.WriteLine();
                }
                else if (seats[i] == ".")
                {
                    Console.Write(" | ");
                }
                else
                {
                    Console.Write(" " + seats[i] + " ");
                }
            }
        }
        /* Remove unicode */
        // Start RemoveUnicode(string text)
        public string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
        //End RemoveUnicode(string text)

        /* Auto render table */
        // Start DisplayTableData<T>(List<T> list, string[] properties, string[] cols, string formatDate)
        public bool DisplayTableData<T>(List<T> list, string[] properties, string[] cols, string formatDate)
        {
            if (list == null)
            {
                return false;
            }

            int[] widthCols = new int[cols.Length];
            int width = 0;
            string row = null;

            for (int i = 0; i < cols.Length; i++)
            {
                widthCols[i] = RemoveUnicode(cols[i]).Length;
            }

            foreach (var item in list)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    if (item.GetType().GetProperty(properties[i]).GetValue(item) != null)
                    {
                        int l = RemoveUnicode(item.GetType().GetProperty(properties[i]).GetValue(item).ToString()).Length;

                        if (l > widthCols[i])
                        {
                            widthCols[i] = l;
                        }
                    }
                }
            }

            for (int i = 0; i < cols.Length; i++)
            {
                row += String.Format("| {0," + -widthCols[i] + "} |", cols[i]);
                width += (widthCols[i] + 4);
            }

            Console.WriteLine(row);
            row = String.Format("{0}", new String('-', width));
            Console.WriteLine(row);

            foreach (var item in list)
            {
                row = null;
                for (int i = 0; i < properties.Length; i++)
                {
                    if (item.GetType().GetProperty(properties[i]).GetValue(item) != null)
                    {
                        if (item.GetType().GetProperty(properties[i]).GetValue(item).GetType() == typeof(DateTime))
                        {
                            DateTime date = DateTime.Parse(item.GetType().GetProperty(properties[i]).GetValue(item).ToString());
                            row += String.Format("| {0," + -widthCols[i] + "} |", date.ToString(formatDate));
                        }
                        else
                        {
                            row += String.Format("| {0," + -widthCols[i] + "} |", item.GetType().GetProperty(properties[i]).GetValue(item).ToString());
                        }
                    }
                    else
                    {
                        row += String.Format("| {0," + -widthCols[i] + "} |", "");
                    }

                }
                Console.WriteLine(row);
            }

            return true;
        }
        // End DisplayTableData<T>(List<T> list, string[] properties, string[] cols, string formatDate)
    }
}