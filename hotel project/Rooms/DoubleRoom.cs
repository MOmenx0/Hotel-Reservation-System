using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_project.Rooms
{
    public class DoubleRoom :IRoom
    {
        public int RoomNumber { get; set; }
        public bool Reserved { get; set; }

        private int _noOfBeds;
        private double _pricePerBed;
        
        public DoubleRoom()
        {
            _noOfBeds = 2;
            _pricePerBed = 30.5;
        }

        public DoubleRoom(double price)
        {
            _noOfBeds = 2;
            _pricePerBed = price;
        }
        public DoubleRoom(int noOfBeds,double price)
        {
            _noOfBeds = noOfBeds;
            _pricePerBed = price;
        }

        public double CalcPrice()
        {
            return _pricePerBed * _noOfBeds;
        }
    }
}
