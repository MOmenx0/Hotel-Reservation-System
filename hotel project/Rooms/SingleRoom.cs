using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_project.Rooms
{
    public class SingleRoom :  IRoom
    {
        public int RoomNumber { get; set; }
        public bool Reserved { get; set; }

        private double _roomPrice;
        public SingleRoom()
        {
            _roomPrice = 40.5;
        }

        public double CalcPrice()
        {
            return _roomPrice;
        }
    }
}
