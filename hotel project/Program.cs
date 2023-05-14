using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using hotel_project.Customers;
using hotel_project.Rooms;
using hotel_project.Reservation;
using hotel_project.Bills;

namespace hotel_project
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IRoomReservation _roomReservation = new RoomReservation();
                IBilling _billing = new Billing();
                int choice = GetChoice();
                switch (choice)
                {
                    case 1:
                        BookRoom(_roomReservation);
                        break;
                    case 2:
                        ShowCustomerBill(_billing);
                        break;
                    case 3:
                        ShowBillHistory(_billing);
                        break;
                    default:
                    case 4:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();
            }
        }

        private static int GetChoice()
        {
            int cho;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine(" Enter 1 -> Book a room");
            Console.WriteLine("================================");
            Console.WriteLine(" Enter 2 -> View Customer Bill");
            Console.WriteLine("================================");
            Console.WriteLine("Enter 3 -> Billing History");
            Console.WriteLine("================================");
            Console.WriteLine("Enter 4 -> Exit the application");
            Console.WriteLine("================================");
            Console.Write("Please enter your choice from menu : ");
            cho = int.Parse(Console.ReadLine());
            return cho;
        }
        private static Customer GetCustomerInfo()
        {
            Console.Clear();
            Customer cust = new Customer();
            Console.Write("Cutomer Name : ");
            cust.Name = Console.ReadLine();
            Console.Write("Cutomer Phone : ");
            cust.Phone = Console.ReadLine();
            Console.Write("Cutomer Gender : ");
            cust.Gender = Console.ReadLine();
            Console.Write("Cutomer SSN : ");
            cust.SSN = Console.ReadLine();
            Console.Write("Cutomer Nationality : ");
            cust.Nationality = Console.ReadLine();

            return cust;
        }
        private static IRoom GetRoomInfo()
        {
           
            IRoom room;
            Console.Clear();
            Console.WriteLine("1- Single Room");
            Console.WriteLine("2- Double Room");
            Console.WriteLine("3- Sweet Room");
            Console.Write("Room Types: ");
            int roomType = int.Parse(Console.ReadLine());
            switch (roomType)
            {
                case 1:
                    room = new SingleRoom();
                    break;
                case 2:
                    room = new DoubleRoom();
                    break;
                case 3:
                    room = new SweetRoom();
                    break;
                default:
                    Console.WriteLine("Your Choice was not a room Type");
                    return null;
            }
            Console.Write("Room Number : ");
            room.RoomNumber = int.Parse(Console.ReadLine());
            return room;
        }
        private static int GetNoOfDays()
        {
            Console.Write("Enter Number of Days : ");
            int days = int.Parse(Console.ReadLine());
            return days;
        }
        private static void BookRoom(IRoomReservation roomReservation)
        {
            var customer = GetCustomerInfo();
            var room = GetRoomInfo();
            int noOfDays = GetNoOfDays();
            bool reserved = roomReservation.ReserveRoom(room, customer, noOfDays);
            Console.Clear();
            if (!reserved)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"This room {room.RoomNumber} is already Reserved choose another room");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Room number {room.RoomNumber} was successfully reserved");
            }
        }
        private static void ShowCustomerBill(IBilling billing)
        {
            Console.Clear();
            Customer customer = new Customer();
            Console.Write("Enter Customer name : ");
            customer.Name = Console.ReadLine();

            var customerBill = billing.CutomerBill(customer);

            if (string.IsNullOrEmpty(customerBill.CustomerName))
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"This Customer {customer.Name} has no bills");
            }else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Customer Name : {customerBill.CustomerName}");
                Console.WriteLine($"Customer SSN : {customerBill.CustomerSSN}");
                Console.WriteLine($"Bill Price : {customerBill.Price}");
                Console.WriteLine($"Bill Date : {customerBill.Date}");
            }

        }
        private static void ShowBillHistory(IBilling billing)
        {
            var billHistory = billing.BillHistory();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Customer SSN              ");
            Console.Write("Customer Name             ");
            Console.Write("Bill Price                ");
            Console.Write("Bill Date                 ");
            Console.WriteLine();
            foreach (var bill in billHistory)
            {

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(bill.CustomerSSN + "                 ");
                Console.Write(bill.CustomerName + "                 ");
                Console.Write(bill.Price + "              ");
                Console.Write(bill.Date + "                 ");
                Console.WriteLine();

            }
        }
    }
}
