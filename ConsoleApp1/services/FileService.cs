using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.services
{
    public static class FileService
    {
        private const string RentingFilepath =
            @"C:\Users\przem\Desktop\C#\ConsoleApp1\ConsoleApp1\files\renting_data.txt";

        private const string VehiclesFilepath =
            @"C:\Users\przem\Desktop\C#\ConsoleApp1\ConsoleApp1\files\vehicle_list.txt";

        public static List<string> ReadRentingsFile()
        {
            var fileLines = File.ReadAllLines(RentingFilepath).ToList();
            return fileLines;
        }

        public static void WriteToRentingsFile(string rentingsAsString)
        {
            File.WriteAllText(RentingFilepath, rentingsAsString);
        }

        public static List<string> ReadVehiclesFile()
        {
            var fileLines = File.ReadAllLines(VehiclesFilepath).ToList();
            return fileLines;
        }

        public static void WriteToVehiclesFile(string vehiclesAsString)
        {
            File.WriteAllText(VehiclesFilepath, vehiclesAsString);
        }
    }
}