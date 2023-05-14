using hotel_project.Customers;
using hotel_project.Rooms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_project.Reservation
{
    public class RoomReservation : IRoomReservation
    {
        private string _fileName;
       
        public RoomReservation()
        {
            _fileName = "RoomReservation.txt";
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, _fileName)))
            {
                using (var temp = File.Create(Path.Combine(Environment.CurrentDirectory, _fileName))) { } 
            }
            _fileName = Path.Combine(Environment.CurrentDirectory, _fileName);
        }
        public bool ReserveRoom(IRoom room, Customer customer, int noOfDays)
        {
            if (!IsFreeRoom(room.RoomNumber)) return false;

            DateTime reserveDate = DateTime.Now;
            DateTime leaveDate = reserveDate.AddDays(noOfDays);

            string rowRecord = "";
            rowRecord += customer.SSN + "|"; // 0
            rowRecord += customer.Name + "|"; // 1
            rowRecord += customer.Phone + "|"; // 2
            rowRecord += customer.Nationality + "|"; // 3
            rowRecord += customer.Gender + "|"; //4 
            rowRecord += room.RoomNumber + "|"; //5
            rowRecord += reserveDate + "|"; // 6
            rowRecord += leaveDate + "|";  // 7 
            rowRecord += noOfDays + "|"; // 8
            rowRecord += ReservationPrice(room.CalcPrice(), noOfDays) + "\n"; // 9

            try
            {
                File.AppendAllText(_fileName, rowRecord);
            }
            catch (Exception ex)
            {
                return false;
            }
            room.Reserved = true;

            return true;
        }
        
        private double ReservationPrice(double roomPrice,int noOfDays)
        {
            return roomPrice * noOfDays;
        }
        private bool IsFreeRoom(int roomNumber)
        {
            string reservationContent = File.ReadAllText(_fileName);
            if (string.IsNullOrEmpty(reservationContent)) return true;
            string[] records = reservationContent.Split('\n');
            foreach(string record in records)
            {
                if (string.IsNullOrEmpty(record)) break;
                string[] values = record.Split('|');
                if (roomNumber == int.Parse(values[5]))
                {
                    DateTime leave = DateTime.Parse(values[7]);
                    if (DateTime.Now.Date < leave.Date) return false;
                }
            }
            return true;
        }
    }
}
