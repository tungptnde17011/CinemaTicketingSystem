using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CTS_BL;
using CTS_Persistence;

namespace CTS_Console
{

    public class ConsoleStaff
    {
        public int input(string str)
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
        // Room r = new Room();

        ScheduleDetail sched = new ScheduleDetail();
        ScheduleBL sbl = new ScheduleBL();
        RoomBL rbl = new RoomBL();
        Cinema cine = new Cinema();

        Movie movie = new Movie();
        ScheduleDetailBL sdbl = new ScheduleDetailBL();
        CinemaBL cbl = new CinemaBL();
        Menus mn = new Menus();
        PriceSeatOfRoomTypeBL psortbl = new PriceSeatOfRoomTypeBL();
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
            cine = cbl.GetCinemaByCineId(us.Cine.CineId);
            DisplayTableData(movies, properties, cols, "dd/MM/yyyy");
            Console.WriteLine(row1);
            Console.Write("\nChọn phim(Theo ID): "); sche.MovieId = input(Console.ReadLine());
            while (mbl.GetMovieByMovieId(sche.MovieId) == null)
            {
                Console.Write("Không có ID này, mời nhập lại: "); sche.MovieId = input(Console.ReadLine());
            }
            movie = mbl.GetMovieByMovieId(sche.MovieId);

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
                    Console.Write("Không còn lịch chiếu cho phim bạn chọn trong ngày hôm nay. Bạn có muốn chọn phim khác?(C/K)");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "C":
                            Ticket(us);
                            return;
                        case "c":
                            Ticket(us);
                            return;
                        case "K":
                            mn.menuStaff(us);
                            return;
                        case "k":
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
                Schedule schez = new Schedule();
                schez = sbl.GetScheduleByScheId(itemlsd.ScheId);
                Room rooms = rbl.GetRoomByRoomId(schez.RoomId);
                Console.WriteLine(count + ". Bắt đầu từ: " + itemlsd.SchedTimeStart?.ToString()+" -> "+itemlsd.SchedTimeStart?.ToString("HH:mm")+" Tại phòng: "+rooms.RoomName);
                
            }
            Console.WriteLine(row1);
            Console.Write("Chọn lịch chiếu (theo số thứ tự): ");
            int scheno = input(Console.ReadLine());
            while (scheno > lsd.Count)
            {
                Console.Write("Chọn sai lịch chiếu, mời nhập lại: ");
                scheno = input(Console.ReadLine());
            }
            int? schedId = lsd[scheno - 1].SchedId;
            sched = sdbl.GetScheduleDetailBySchedId(schedId);

            string[] seat = ChoiceSeats(sched);
            while (seat == null)
            {

                Console.Write("Ghế đã được mua hoặc ghế không tồn tại, có muốn đặt lại?(C/K)");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "c":
                        seat = ChoiceSeats(sched);
                        break;
                    case "C":
                        seat = ChoiceSeats(sched);
                        break;
                    case "k":
                        mn.menuStaff(us);
                        return;
                    case "K":
                        mn.menuStaff(us);
                        return;
                    default:
                        continue;
                        // break;
                }
            }
            foreach (var itemls in ls)
            {
                if (itemls.ScheId == sched.ScheId)
                {
                    sche = itemls;
                }
            }
            Room room = new Room();
            room = rbl.GetRoomByRoomId(sche.RoomId);
            // Console.WriteLine(room.RTName);
            List<PriceSeatOfRoomType> lpsort = psortbl.GetPriceSeatsOfRoomTypeByRTName(room.RTName);
            PriceSeatOfRoomType psort = null;
            List<PriceSeatOfRoomType> lpsort1 = new List<PriceSeatOfRoomType>();
            // Console.Write(seat[0].ToString());
            foreach (var itemlpsort in lpsort)
            {
                foreach (var item in seat)
                {
                    if (itemlpsort.STType == item[0].ToString())
                    {   psort = new PriceSeatOfRoomType();
                        psort.STType = itemlpsort.STType;
                        psort.RTName = itemlpsort.RTName;
                        psort.Price = itemlpsort.Price;
                        lpsort1.Add(psort);
                    }
                }
            }
            Console.Clear();
            Console.WriteLine(row1);
            Console.WriteLine("Đặt vé");
            Console.WriteLine(row2);
            for (int i = 0; i < lpsort1.Count; i++)
            {
                PrintTicket(sched, sche, room, movie, lpsort1[i], us, cine, seat[i]);
            }
            Console.WriteLine(row1);
            while (true)
            {
                Console.Write("Xác nhận in vé hiển thị trên màn hình?(C/K)");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "C":
                        tbl.BuyTicket(sched);
                        break;
                    case "c":
                        tbl.BuyTicket(sched);
                        break;
                    case "K":
                        break;
                    case "k":
                        break;
                    default:
                        continue;
                        // break;
                }
                break;
            }
            Console.Clear();
            while (true)
            {
                Console.Write("Tiếp tục đặt vé?(C/K)");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "C":
                        Ticket(us);
                        return;
                    case "c":
                        Ticket(us);
                        return;
                    case "K":
                        mn.menuStaff(us);
                        return;
                    case "k":
                        mn.menuStaff(us);
                        return;
                    default:
                        continue;
                        // break;
                }
            }

        }
        public void PrintTicket(ScheduleDetail sched, Schedule sche, Room room, Movie movie, PriceSeatOfRoomType psort, User user, Cinema cine, string seat)
        {
            string a = "";
            string b = "";
            int inde = (cine.CineAddress.Length) / 2;
            for (int j = inde; j > 0; j--)
            {
                if (cine.CineAddress[j - 1] == ',')
                {
                    a = cine.CineAddress.Substring(0, j);
                    b = cine.CineAddress.Substring(j + 1, cine.CineAddress.Length - inde);
                    break;
                }

            }


            string[] left = {cine.CineName,a,b,cine.CinePhone,
            DateTime.Now.ToString("dd/MM/yyyy")+"     "+sched.SchedTimeStart?.ToString("HH:mm")+
            " - "+sched.SchedTimeEnd?.ToString("HH:mm"),movie.MovieName,
            psort.STType+" Ghế"+" Rạp",psort.Price+" "+seat+" "+room.RoomName,
            "Gồm"+" Seat"+" Cinema","5% VAT",DateTime.Now.ToString("HH:mm dd/MM/yyyy")+"      "+user.Username};
            string[] right = {cine.CineName,a,b,movie.MovieName,"Time: "+sched.SchedTimeStart?.ToString("HH:mm")+
            " - "+sched.SchedTimeEnd?.ToString("HH:mm"),"Date: "+DateTime.Now.ToString("dd/MM/yyyy"),
            "Hall: "+room.RoomName,"Seat: "+seat,psort.STType,"Price: "+psort.Price,DateTime.Now.ToString("HH:mm dd/MM/yyyy")};
            int length = 0;
            int length1 = 0;
            int length2 = 0;
            for (int i = 0; i < left.Length; i++)
            {
                if ((left[i] + right[i]).Length > length)
                {
                    length = (left[i] + right[i]).Length;
                    length1 = left[i].Length;
                    length2 = right[i].Length;
                }
            }
            for (int i = 0; i < length + 7; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            for (int i = 0; i < left.Length; i++) 
            {
                string lefti;
                if (i > 5 && i < 9)
                {
                    string[] arr = left[i].Split(" ");
                    Console.Write("| " + arr[0]);
                    for (int l = 0; l < 12 - arr[0].ToString().Length; l++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(arr[1]);
                    for (int j = 0; j < 7 - arr[1].ToString().Length; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(arr[2]);
                    for (int o = 0; o < length1 - 12 - 7 - arr[2].Length; o++)
                    {
                        Console.Write(" ");
                    }

                }
                else
                {
                    lefti = "| " + left[i];
                    Console.Write(lefti);
                    for (int j = 0; j < length1 - lefti.Length + 2; j++)
                    {
                        Console.Write(" ");
                    }
                }


                string righti = " | " + right[i];
                Console.Write(righti);
                for (int k = 0; k < length2 - righti.Length + 3; k++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(" |");

            }
            for (int i = 0; i < length + 7; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();

        }

        public string[] ChoiceSeats(ScheduleDetail sched)
        {
            Console.Clear();
            string roomSeats = sched.SchedRoomSeats;
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
                        if (choiced[i].Trim().ToUpper() == seats[j].Substring(2))
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
            else
            {
                return null;
            }
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