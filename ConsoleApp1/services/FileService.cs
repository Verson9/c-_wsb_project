using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.services
{
    public static class FileService
    {
        private const string RentingFilepath = @"C:\Users\przem\RiderProjects\ConsoleApp1\ConsoleApp1\files\renting_data.txt";
        private const string VehiclesFilepath = @"C:\Users\przem\RiderProjects\ConsoleApp1\ConsoleApp1\files\vehicle_list.txt";

        public static List<string> ReadRentingsFile()
        {
            var fileLines = File.ReadAllLines(RentingFilepath).ToList();
            return fileLines;
        }

        public static void WriteToRentingsFile(string line)
        {
            File.AppendAllText(RentingFilepath, "\n"+line);
        }
        
        public static List<string> ReadVehiclesFile()
        {
            var fileLines = File.ReadAllLines(VehiclesFilepath).ToList();
            return fileLines;
        }

        public static void WriteToVehiclesFile(string line)
        {
            File.AppendAllText(VehiclesFilepath, "\n"+line);
        }

        public static void ReWriteVehiclesFile(List<string> vehiclesList)
        {
            var vehiclesListString = vehiclesList.Aggregate("", (current, vehicle) => current + (vehicle + '\n'));
            File.WriteAllText(VehiclesFilepath, vehiclesListString);
        }
    }
}