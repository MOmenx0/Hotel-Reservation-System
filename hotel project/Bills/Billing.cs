using hotel_project.Customers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hotel_project.Bills
{
    public class Billing : IBilling
    {
        private string _fileName;
        public Billing()
        {
            _fileName = "RoomReservation.txt";
            _fileName = Path.Combine(Environment.CurrentDirectory, _fileName);
        }
        public List<BillModel> BillHistory()
        {
            List<BillModel> result = new List<BillModel>();

            string reservationContent = File.ReadAllText(_fileName);
            if (string.IsNullOrEmpty(reservationContent)) return new List<BillModel>();
            
            string[] records = reservationContent.Split('\n');

            foreach (var record in records)
            {

                if (string.IsNullOrEmpty(record)) break;
                string[] values = record.Split('|');
                BillModel billModel = new BillModel();
                DateTime curr = DateTime.Parse(values[9]);
                billModel.CustomerSSN = values[0];
                billModel.CustomerName = values[1];
                billModel.Date = curr;
                billModel.Price = double.Parse(values[9]);
                result.Add(billModel);

            }
            return result;
        }
        public BillModel CutomerBill(Customer customer)
        {
            BillModel billModel = new BillModel();

            string reservationContent = File.ReadAllText(_fileName);
            if (string.IsNullOrEmpty(reservationContent)) return new BillModel();
            string[] records = reservationContent.Split('\n');
       
            DateTime leave = DateTime.MinValue;
            foreach (var record in records)
            {
                if (string.IsNullOrEmpty(record)) break;
                string[] values = record.Split('|');
                if (customer.SSN == values[0]||values[1].ToLower().StartsWith(customer.Name.ToLower()))
                {
                    billModel.CustomerName = values[1];
                    billModel.CustomerSSN = values[0];
                    DateTime curr = DateTime.Parse(values[7]);
                    if (curr > leave)
                    {
                        billModel.Date = curr;
                        billModel.Price = double.Parse(values[9]);
                        leave = curr;
                    }
                }
            }
            return billModel;
        }
    }
}
