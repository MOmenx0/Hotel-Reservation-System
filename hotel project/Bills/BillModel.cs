using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_project.Bills
{
    public class BillModel
    {
        public string CustomerName { get; set;}
        public string CustomerSSN { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

    }
}
