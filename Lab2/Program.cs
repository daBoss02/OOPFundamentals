
using Lab2;
using System.Security.Authentication;
/// Create an OOP "Carpark" System
/// At its most basic, the static CarPark class will have a private HashSet of Vehicles, and a method: public static void Park (Vehicle vehicle) method.
/// Vehicles have a string LicenseNumber, and a string ParkingSpot
/// Both should be private and validated with public properties
/// 
/// When the Park method is invoked, it adds the vehicle to the CarPark HashSet,  counts the vehicles in the HashSet, and uses that number to assign a spot.
/// If 20 vehicles are parked, then the 21st vehicle parked is given spot 21.
/// 
/// It should prevent a vehicle from parking in more than one spot (if it already has a spot) or if the spots are over capacity.
/// 


// spot doesn't have vehicle, no 
CarPark newPark1 = new CarPark(10, "Hospital");

Vehicle newVehicle = new Vehicle("A1A1A1");

newPark1.ParkVehicle(newVehicle);

Console.WriteLine(newVehicle.ParkingSpots.Count);

newPark1.RemoveVehicle("A1A1A1");

Console.WriteLine(newVehicle.ParkingSpots.Count);

bool wantToPark = true;

Console.WriteLine("What size and location of parking spot would you like to initialize:");
Console.Write("Size: ");

//Getting the capacity
bool validSize = false;
int size = 0;
while (!validSize)
{
    try
    {
        size = Int32.Parse(Console.ReadLine());
        validSize = true;
    } catch
    {
        Console.WriteLine("Invalid Size: must be a number:");
    }
}

// Getting the carpark name
Console.Write("Location: ");
bool validName = false;
string name = Console.ReadLine();

while (!validName)
{
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Please input a location");
        name = Console.ReadLine();
    } else
    {
        validName = true;
    }
}

CarPark park = new CarPark(size, name);
Console.WriteLine($"{park.CarParkName} has {park.GetParkingSpots().Count} spots");

// parking or removing

while (wantToPark)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1: Park a Vehicle");
    Console.WriteLine("2: Remove a Vehicle from parking");

    string input = Console.ReadLine();
    if (input?.ToLower() == "cancel") { break; }
    bool validInput = false;
    int selection = 0;
    while (!validInput)
    {
        try
        {
            selection = Int32.Parse(input);
            if (selection == 1 || selection == 2)
            {
                validInput = true;
            } else
            {
                Console.WriteLine("Please select a valid option");
            }
        } catch
        {
            Console.WriteLine("Please select a valid option");
            input = Console.ReadLine();
            if (input?.ToLower() == "cancel") 
            { 
                wantToPark = false;
                break;
            }
        }
    }
    if (!wantToPark)
    {
        break;
    }


    if (selection == 1)
    {
        Console.WriteLine("To park the car please input license plate with no spaces");
        bool validLicense = false;
        Vehicle car = new Vehicle();

        while (!validLicense)
        {
            try
            {
                car = new Vehicle(Console.ReadLine());
                validLicense = true;
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        park.ParkVehicle(car);
    }

    else if (selection == 2)
    {
        Console.WriteLine("Please input the license of the car you with to remove with no spaces");
        string license = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(license))
        {
            Console.WriteLine("Please input a license plate");
            license = Console.ReadLine();
        }

        park.RemoveVehicle(license);
    }
}