using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_project.Rooms
{
    public class SweetRoom : IRoom
    {
        public int RoomNumber { get; set; }
        public bool Reserved { get; set; }
       
        private double _sweetPrice;
        public SweetRoom()
        {
            _sweetPrice = 50;
        }

        public double CalcPrice()
        {
            return _sweetPrice;
        }
    }
}
