// using System;
// using Xunit;
// using CTS_DAL;
// using System.Collections.Generic;
// using System.Linq;
// using CTS_Persistence;
// using Newtonsoft.Json;

// namespace CTS_DAL_XUnit
// {
//     public class RoomUnitTest
//     {
//         RoomDAL roomDAL =  new RoomDAL();

//         [Fact]
//         public void GetRoomsByCineIdTest1()
//         {
//             List<Room> rooms = new List<Room>();
//             // rooms.Add(new Room(1, 
//             //                 "Room 01", 
//             //                 "_________________________________________________________ n _________________________________________________________ n N:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10 n N:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10 n N:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10 n N:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10 n N:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10 n N:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10 n N:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10 n N:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10 n N:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10 n N:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10 n N:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10 n", 
//             //                 "3D"));
//             // rooms.Add(new Room(1, 
//             //                 "Room 02", 
//             //                 "_________________________________________________________ n _________________________________________________________ n N:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10 n N:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10 n N:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10 n N:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10 n N:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10 n N:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10 n N:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10 n N:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10 n N:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10 n N:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10 n N:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10 n",
//             //                 "IMAX2D"));
//             // rooms.Add(new Room(1, 
//             //                 "Room 03", 
//             //                 "_________________________________________________________ n _________________________________________________________ n N:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10 n N:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10 n N:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10 n N:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10 n N:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10 n N:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10 n N:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10 n N:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10 n N:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10 n N:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10 n N:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10 n",
//             //                 "2D"));
//             // rooms.Add(new Room(1, 
//             //                 "Room 04", 
//             //                 "_________________________________________________________ n _________________________________________________________ n N:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10 n N:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10 n N:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10 n N:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10 n N:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10 n N:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10 n N:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10 n N:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10 n N:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10 n N:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10 n N:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10 n",
//             //                 "Lamour"));
//             // rooms.Add(new Room(1, 
//             //                 "Room 05", 
//             //                 "_________________________________________________________ n _________________________________________________________ n N:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10 n N:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10 n N:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10 n N:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10 n N:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10 n N:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10 n N:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10 n N:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10 n N:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10 n N:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10 n N:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10 n",
//             //                 "4DX2D"));
//             rooms.Add(new Room(1, "1", "1", "1"));
//             rooms.Add(new Room(1, "1", "1", "1"));
//             rooms.Add(new Room(1, "3", "3", "3"));
//             rooms.Add(new Room(1, "4", "4", "4"));
//             // List<Room> rooms1 = roomDAL.GetRoomsByCineId(1);
//             List<Room> rooms1 = new List<Room>();
//             rooms1.Add(new Room(1, "1", "1", "1"));
//             rooms1.Add(new Room(1, "2", "2", "2"));
//             rooms1.Add(new Room(1, "3", "3", "3"));
//             rooms1.Add(new Room(1, "4", "4", "4"));

//             Console.WriteLine(JsonConvert.SerializeObject(rooms));
            
//             Assert.Equal(JsonConvert.SerializeObject(rooms), JsonConvert.SerializeObject(rooms1));

//             Assert.True(rooms.Contains(rooms1[0]));
            
//         }

//         [Fact]
//         public void GetRoomsByCineIdTest2()
//         {
//             Assert.Null(roomDAL.GetRoomsByCineId(0));
//         }

        
//     }
// }