using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Vehicle
    {
        private string? _licenseNumber = "0000000";
        public string? LicenseNumber
        {
            get { return _licenseNumber; }
            set
            {
                if (value.Length < 3 || value.Length > 7 || value.Contains(" "))
                {
                    throw new Exception("Plate must be alphanumeric between 3 and 7 characters");
                }
                else
                {
                    _licenseNumber = value;
                }
            }
        }

        private void UpdateLicenseNumber()
        {

        }

        private HashSet<ParkingSpot> _parkingSpots = new HashSet<ParkingSpot>();

        public HashSet<ParkingSpot> ParkingSpots { get { return _parkingSpots; } }
        public void RemoveParkingSpot(CarPark carpark)
        {
            foreach (ParkingSpot spot in _parkingSpots)
            {
                if (spot.CarPark == carpark)
                {
                    _parkingSpots.Remove(spot);
                }
            }
        }

        public void addSpot(ParkingSpot parkingSpot)
        {
            _parkingSpots.Add(parkingSpot);
        }

        public Vehicle(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
        }
        public Vehicle()
        {

        }

    }
}
