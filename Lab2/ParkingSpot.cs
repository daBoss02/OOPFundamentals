using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class ParkingSpot
    {
        private int _number;
        private Vehicle? _vehicle;
        private CarPark _carPark;

        public int Number { get { return _number; } }
        public CarPark CarPark { get { return _carPark; } }

        public void SetCarPark(CarPark carpark)
        {
            _carPark = carpark;
        }
        public Vehicle? Vehicle
        {
            get { return _vehicle; }
            set
            {
                _vehicle = value;
            }
        }

        public ParkingSpot(int number, CarPark carpark)
        {
            _number = number;
            _carPark = carpark;
        }

        public ParkingSpot(int number)
        {
            _number = number;
        }
    }
}
