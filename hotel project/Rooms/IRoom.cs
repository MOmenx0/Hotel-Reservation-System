using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_project.Rooms
{
    public interface IRoom
    {
        int RoomNumber { get; set; }
        bool Reserved { get; set; }
        double CalcPrice();
    }
}
