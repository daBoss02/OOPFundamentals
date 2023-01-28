using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class CarPark
    {
        private HashSet<ParkingSpot> _parkingSpots = new HashSet<ParkingSpot>();


        //Exposes the whole hashset and properties that come with it
        //public HashSet<ParkingSpot> ParkingSpots { get { return _parkingSpots; } }

        //only exposes adding to the hashset
        private void AddParkingSpot(ParkingSpot parkingSpot)
        {
            _parkingSpots.Add(parkingSpot);
            parkingSpot.SetCarPark(this);
        }

        public HashSet<ParkingSpot> GetParkingSpots()
        {
            HashSet<ParkingSpot> spotReferenceCopies = _parkingSpots.ToHashSet();
            return spotReferenceCopies;
        }

        private string _carParkName;
        public string CarParkName { get { return _carParkName;} }

        public void ParkVehicle(Vehicle vehicle)
        {
            foreach (ParkingSpot spot in _parkingSpots)
            {
                if (spot.Vehicle == null)
                {
                    spot.Vehicle = vehicle;
                    Console.WriteLine($"You have been granted spot {spot.Number} for {vehicle.LicenseNumber}");
                    vehicle.addSpot(spot);
                    break;
                }
            }
        }

        public void RemoveVehicle(string license)
        {
            Vehicle? vehicle = new Vehicle();
            foreach (ParkingSpot spot in _parkingSpots)
            {
                try
                {
                    vehicle = spot.Vehicle;
                    if (vehicle != null && license == vehicle.LicenseNumber)
                    {
                        spot.Vehicle = null;
                        vehicle.RemoveParkingSpot(this);
                        Console.WriteLine($"Your vehicle has been removed from " +
                            $"{spot.CarPark.CarParkName}'s spot {spot.Number}");
                    }
                } catch
                {
                    Console.WriteLine($"{vehicle.LicenseNumber} has been removed from all spots");
                    break;
                }
            }

        }

        public int Capacity { get { return _capacity; } }
        private int _capacity;

        private void _setCapacity(int newCapacity)
        {
            if (newCapacity > 0)
            {
                _capacity = newCapacity;
            } else
            {
                throw new Exception("Capacity must be greater than 0");
            }
        }
        private void _initializeEmptySpots()
        {
            for (int i = 1; i <= Capacity; i++)
            { 
                _parkingSpots.Add(new ParkingSpot(i, this));
            }
        }
        private static int _spotCount = 1;
        public CarPark(int capacity, string name)
        {
            _setCapacity(capacity);
            _initializeEmptySpots();
            _carParkName = name;
        }
    }
}
