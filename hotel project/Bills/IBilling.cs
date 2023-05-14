using hotel_project.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_project.Bills
{
    public interface IBilling
    {
        BillModel CutomerBill(Customer customer);
        List<BillModel> BillHistory();

    }
}
