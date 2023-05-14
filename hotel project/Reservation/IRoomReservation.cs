using hotel_project.Customers;
using hotel_project.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_project.Reservation
{
    public interface IRoomReservation
    {
        bool ReserveRoom(IRoom room, Customer customer, int noOfDays);

    }
}
