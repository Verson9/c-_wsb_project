using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApp1.objects;

namespace ConsoleApp1.services
{
    public static class FileService
    {
        private const string RentingFilepath = @"C:\Users\przem\Desktop\C#\ConsoleApp1\ConsoleApp1\files\renting_data.txt";
        private const string VehiclesFilepath = @"C:\Users\przem\Desktop\C#\ConsoleApp1\ConsoleApp1\files\vehicle_list.txt";

        public static List<string> ReadRentingsFile()
        {
            var fileLines = File.ReadAllLines(RentingFilepath).ToList();
            return fileLines;
        }

        public static void WriteToRentingsFile(List<Renting> rentingsList)
        {
            string rentingsAsString = null;
            foreach (var renting in rentingsList)
            {
                rentingsAsString = renting.ToString() + "\n";
            }
            File.AppendAllText(RentingFilepath, rentingsAsString);
        }
        
        public static List<string> ReadVehiclesFile()
        {
            var fileLines = File.ReadAllLines(VehiclesFilepath).ToList();
            return fileLines;
        }

        public static void WriteToVehiclesFile(List<Vehicle> vehiclesList)
        {
            string vehiclesAsString = null;
            foreach (var vehicle in vehiclesList)
            {
                vehiclesAsString = vehicle.ToString() + "\n";
            }
            File.WriteAllText(VehiclesFilepath, vehiclesAsString);
        }
    }
}