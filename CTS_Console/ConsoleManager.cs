using System;
using CTS_Persistence;
using CTS_BL;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CTS_Console
{
    public class ConsoleManager
    {
        Schedule sche = new Schedule();
        Movie movie = new Movie();
        List<Room> lr = new List<Room>();
        Cinema cine = new Cinema();
        RoomBL rbl = new RoomBL();
        Room room = new Room();
        ConsoleStaff cs = new ConsoleStaff();
        CinemaBL cbl = new CinemaBL();
        Menus mn = new Menus();
        public void CreateSchedule(User us)
        {
            Console.Clear();
            string row1 = "=====================================================================";
            string row2 = "---------------------------------------------------------------------";
            Console.WriteLine(row1);
            Console.WriteLine("Tạo lịch chiếu phim.");
            Console.WriteLine(row2);
            Console.WriteLine("[Danh sách Phim]\n");
            MovieBL mbl = new MovieBL();
            string[] properties = { "MovieId", "MovieName", "MovieCategory", "MovieTime", "MovieDateStart", "MovieDateEnd" };
            string[] cols = { "Mã phim", "Tên phim", "Thể loại", "Thời lượng(Phút)", "Ngày bắt đầu", "Ngày kết thúc" };
            List<Movie> movies = mbl.GetMoviesByCineId(us.Cine.CineId);
            // cine = cbl.GetCinemaByCineId(us.Cine.CineId);
            cs.DisplayTableData(movies, properties, cols, "dd/MM/yyyy");
            Console.WriteLine(row1);
            Console.Write("\nChọn phim(theo mã): "); sche.MovieId = cs.input(Console.ReadLine());
            while (mbl.GetMovieByMovieId(sche.MovieId) == null)
            {
                Console.Write("Không có mã này, mời bạn nhập lại: "); sche.MovieId = cs.input(Console.ReadLine());
            }
            cine = us.Cine;
            // Console.Clear();
            // row1 = "========================================";
            // row2 = "----------------------------------------";
            Console.WriteLine(row1);
            Console.WriteLine("Tạo lịch chiếu phim.");
            Console.WriteLine(row2);
            Console.WriteLine("[Danh sách phòng]\n");
            string[] proper = { "RoomId", "RoomName", "RTName" };
            string[] col = { "Mã phòng", "Tên phòng", "Loại phòng" };
            lr = rbl.GetRoomsByCineId(us.Cine.CineId);
            cs.DisplayTableData(lr, proper, col, null);
            Console.WriteLine(row1);
            Console.Write("\nChọn phòng(theo mã): "); sche.RoomId = cs.input(Console.ReadLine());
            while (rbl.GetRoomByRoomId(sche.RoomId) == null)
            {
                Console.Write("Không có mã này, mời bạn nhập lại: "); sche.RoomId = cs.input(Console.ReadLine());
            }
            ScheduleBL sbl = new ScheduleBL();
            while (sbl.GetScheduleByMovieIdAndRoomId(sche.MovieId, sche.RoomId) != null)
            {
                Console.Write("Trùng lịch chiếu, mời bạn nhập lại: ");
                sche.RoomId = cs.input(Console.ReadLine());
                while (rbl.GetRoomByRoomId(sche.RoomId) == null)
                {
                    Console.Write("Không có mã này, mời bạn nhập lại: "); sche.RoomId = cs.input(Console.ReadLine());
                }
            }
            movie = mbl.GetMovieByMovieId(sche.MovieId);
            room = rbl.GetRoomByRoomId(sche.RoomId);
            List<ScheduleDetail> lsd = DisplayTime(movie, room);
            while (lsd == null)
            {
                Console.Write("Không tìm thấy khung giờ hoặc trùng, bạn có muốn chọn lại?(C/K)");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "C":
                        lsd = DisplayTime(movie, room);
                        break;
                    case "c":
                        lsd = DisplayTime(movie, room);
                        break;
                    case "K":
                        mn.menuManager(us);
                        return;
                    case "k":
                        mn.menuManager(us);
                        return;
                    default:
                        continue;
                        // break;
                }
            }

            Console.Clear();
            Console.WriteLine(row1);
            Console.WriteLine("Tạo lịch chiếu phim.");
            Console.WriteLine(row2);
            Console.WriteLine("[Chi tiết lịch chiếu]\n");
            Console.WriteLine("Bộ phim: " + movie.MovieName);
            Console.WriteLine("Chiếu tại rạp: " + cine.CineName);
            Console.WriteLine("Chiếu tại phòng: " + room.RoomName);
            Console.WriteLine("Trong các khung giờ lặp mỗi ngày từ ngày {0} - {1} cụ thể như sau: ", movie.MovieDateStart.ToString("dd/MM/yyyy"), movie.MovieDateEnd.ToString("dd/MM/yyyy"));
            int count = 1;
            string timeline = "";

            for (int i = 1; i < lsd.Count - 1; i++)
            {
                if (lsd[0].SchedTimeStart?.ToString("HH:mm") == lsd[i].SchedTimeStart?.ToString("HH:mm"))
                {
                    break;
                }
                count++;
            }
            for (int i = 0; i < count; i++)
            {
                try
                {
                    Console.WriteLine("{0}.{1} -> {2}", i + 1, lsd[i].SchedTimeStart?.ToString("HH:mm"), lsd[i].SchedTimeEnd?.ToString("HH:mm"));
                    if (timeline == "")
                    {
                        timeline = timeline + lsd[i].SchedTimeStart?.ToString("HH:mm");
                    }
                    else
                    {
                        timeline = timeline + ", " + lsd[i].SchedTimeStart?.ToString("HH:mm");
                    }
                }
                catch (System.Exception)
                {

                }


            }
            // foreach (var item in lsd)
            // {
            //     if (Schedule)
            //     {

            //     }
            //     {
            //         Console.WriteLine("{0}.{1} {2} -> {3}", count, item.SchedTimeEnd?.ToString("dd/MM/yyyy"), item.SchedTimeStart?.ToString("HH:mm"), item.SchedTimeEnd?.ToString("HH:mm"));
            //     }
            //     if (timeline == "")
            //     {
            //         timeline = timeline + item.SchedTimeStart?.ToString("HH:mm");
            //     }
            //     else
            //     {
            //         timeline = timeline + ", " + item.SchedTimeStart?.ToString("HH:mm");
            //     }
            //     count++;
            // }
            sche = new Schedule(null, 0, null, timeline, sche.RoomId, sche.MovieId, lsd);
            Console.WriteLine(row1);
            while (true)
            {
                Console.Write("Xác nhận tạo lịch chiếu?(C/K)");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "C":
                        sbl.CreateSchedule(sche);
                        break;
                    case "c":
                        sbl.CreateSchedule(sche);
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
                Console.Write("Tiếp tục tạo lịch?(C/K)");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "C":
                        CreateSchedule(us);
                        return;
                    case "c":
                        CreateSchedule(us);
                        return;
                    case "K":
                        mn.menuManager(us);
                        return;
                    case "k":
                        mn.menuManager(us);
                        return;
                    default:
                        continue;
                        // break;
                }
            }

        }
        public List<ScheduleDetail> DisplayTime(Movie movie, Room room)
        {
            List<ScheduleDetail> lsd = new List<ScheduleDetail>();
            ScheduleDetail sched = null;
            Console.Clear();
            string row1 = "=====================================================================";
            string row2 = "---------------------------------------------------------------------";
            Console.WriteLine(row1);
            Console.WriteLine("Tạo lịch chiếu phim.");
            Console.WriteLine(row2);
            Console.WriteLine("[Danh sách khung giờ có thể chiếu]\n");
            // Console
            List<string> start = new List<string>();
            List<string> end = new List<string>();
            start.Add("07:00");
            int i = 0;
            int? convert = TimeToInt(start[0]);
            end.Add(IntToTime(convert + movie.MovieTime));
            while (TimeToInt(start[i]) < 23 * 60)
            {
                convert = TimeToInt(start[i]);
                start.Add(IntToTime(convert + movie.MovieTime + 10));
                i++;
                convert = TimeToInt(start[i]);
                end.Add(IntToTime(convert + movie.MovieTime));
            }
            start.RemoveAt(i);
            end.RemoveAt(i);
            for (int k = 0; k < start.Count; k++)
            {
                Console.WriteLine("{0}: {1} -> {2}", k + 1, start[k], end[k]);
            }
            Console.WriteLine(row1);

            Console.Write("Chọn các khung giờ (theo các số thứ tự): ");
            string time = Console.ReadLine();

            time = time.Replace(" ", "");
            // Console.WriteLine(time);
            Regex regex = new Regex("[0-9,]");
            // Regex regex1 = new Regex("[1-9][0-9]");
            
            // MatchCollection matchcollection1 = regex1.Matches(time);
            string[] timeArr;

            while (true)
            {
                MatchCollection matchcollection = regex.Matches(time);
                timeArr = time.Split(",");
                if (matchcollection.Count != time.Length)
                {
                    Console.Write("Nhập các khung giờ sai định dạng, mời bạn nhập lại (ví dụ: 1,2...): ");
                    time = Console.ReadLine();
                    matchcollection = regex.Matches(time);
                    continue;
                }

                int check = 0;
                for (i = 0; i < timeArr.Length - 1; i++)
                {
                    for (int j = i + 1; j < timeArr.Length; j++)
                    {
                        if (timeArr[i] == timeArr[j])
                        {
                            check = 1;
                            break;
                        }
                    }
                    if (check == 1)
                    {
                        break;
                    }
                }
                if (check == 1)
                {
                    Console.Write("Nhập trùng khung giờ, mời bạn nhập lại: ");
                    time = Console.ReadLine();
                    continue;
                }

                int count = 0;
                for (i = 0; i < timeArr.Length; i++)
                {
                    // Console.WriteLine(timeArr[i]);
                    for (int k = 0; k < start.Count; k++)
                    {
                        if (Convert.ToInt32(timeArr[i].Trim()) == k + 1)
                        {
                            count++;
                            break;
                        }
                    }
                }

                DateTime daystart = movie.MovieDateStart;
                DateTime dayend = movie.MovieDateEnd;
                int dem = 0;
                if (count == timeArr.Length && count > 0)
                {
                    while (DateTime.Compare(daystart, dayend) <= 0)
                    {
                        dem++;
                        for (i = 0; i < timeArr.Length; i++)
                        {
                            sched = new ScheduleDetail();
                            int index = Convert.ToInt32(timeArr[i]);
                            int[] hours = { TimeToInt(start[index - 1]) / 60, TimeToInt(end[index - 1]) / 60 };
                            int[] minutes = { TimeToInt(start[index - 1]) % 60, TimeToInt(end[index - 1]) % 60 };
                            sched.SchedRoomSeats = room.RoomSeats;
                            sched.SchedTimeStart = new DateTime(daystart.Year, daystart.Month, daystart.Day, hours[0], minutes[0], 0);
                            sched.SchedTimeEnd = new DateTime(daystart.Year, daystart.Month, daystart.Day, hours[1], minutes[1], 0);
                            // Console.WriteLine("{0}. {1} -> {2}", dem, sched.SchedTimeStart.ToString(), sched.SchedTimeEnd.ToString());
                            sched.SchedId = null;
                            sched.ScheId = null;
                            // Console.WriteLine(sched.SchedTimeStart.ToString());
                            lsd.Add(sched);

                        }
                        daystart = daystart.AddDays(1);
                        // if (daystart.Year % 4 == 0 && daystart.Month == 2 && daystart.Day == 29)
                        // {
                        //     daystart = new DateTime(daystart.Year, 3, 1);
                        // }
                        // else if (daystart.Year % 4 != 0 && daystart.Month == 2 && daystart.Day == 28)
                        // {
                        //     daystart = new DateTime(daystart.Year, 3, 1);
                        // }
                        // else if (daystart.Month == 12 && daystart.Day == 31)
                        // {
                        //     daystart = new DateTime(daystart.Year + 1, 1, 1);
                        // }
                        // else if (daystart.Day == 31 && ((daystart.Month == 1) || (daystart.Month == 3) || (daystart.Month == 5) || (daystart.Month == 7) || (daystart.Month == 8) || (daystart.Month == 10)))
                        // {
                        //     daystart = new DateTime(daystart.Year, daystart.Month + 1, 1);
                        // }
                        // else if (daystart.Day == 30 && ((daystart.Month == 4) || (daystart.Month == 6) || (daystart.Month == 9) || (daystart.Month == 11)))
                        // {
                        //     daystart = new DateTime(daystart.Year, daystart.Month + 1, 1);
                        // }
                        // else
                        // {
                        //     daystart = new DateTime(daystart.Year, daystart.Month, daystart.Day + 1);
                        // }
                    }
                    break;
                }else{
                    Console.Write("Không có khung giờ, mời bạn nhập lại: ");
                    time = Console.ReadLine();
                    continue;
                }
            }

            // for (int k = 0; k < lsd.Count; k++)
            // {
            //     Console.WriteLine("{0}. {1}->{2}", k+1, lsd[k].SchedTimeStart?.ToString(),lsd[k].SchedTimeEnd?.ToString());
            // }
            return lsd;
        }
        public int TimeToInt(string timeStr)
        {
            // timestr

            string[] timeStrA = timeStr.Split(":");
            int time = 0;
            if (timeStrA.Length == 2)
            {
                int h = Convert.ToInt32(timeStrA[0]);
                int m = Convert.ToInt32(timeStrA[1]);
                time = h * 60 + m;
            }
            return time;
        }
        public string IntToTime(int? timeInt)
        {
            string strH = (timeInt / 60).ToString();
            if (strH.Length == 1)
            {
                strH = "0" + strH;
            }
            string strM = (timeInt % 60).ToString();
            if (strM.Length == 1)
            {
                strM = "0" + strM;
            }
            string timeStr = strH + ":" + strM;

            return timeStr;
        }
        public int RoomDisplay(User us)
        {
            Console.Clear();
            string row1 = "=====================================================================";
            string row2 = "---------------------------------------------------------------------";
            Console.WriteLine(row1);
            Console.WriteLine("Tạo lịch chiếu phim.");
            Console.WriteLine(row2);
            Console.WriteLine("[Danh sách phòng]\n");
            string[] proper = { "RoomId", "RoomName", "RTName" };
            string[] col = { "ID", "Tên phòng", "Loại phòng" };
            lr = rbl.GetRoomsByCineId(us.Cine.CineId);
            cs.DisplayTableData(lr, proper, col, null);
            Console.WriteLine(row1);
            Console.Write("\nChọn phòng(Theo ID): "); sche.RoomId = cs.input(Console.ReadLine());
            while (rbl.GetRoomByRoomId(sche.RoomId) == null)
            {
                Console.Write("Không có ID này, mời nhập lại: "); sche.RoomId = cs.input(Console.ReadLine());
            }
            return sche.RoomId;
        }
    }
}