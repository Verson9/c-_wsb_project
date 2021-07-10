using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.services
{
    public static class FileService
    {
        private static string path = AppContext.BaseDirectory.ToString();
        private static string RentingFilepath =
            path +"files/renting_data.txt";

        private static string VehiclesFilepath =
            path + "files/vehicle_list.txt";

        public static List<string> ReadRentingsFile()
        {
            var fileLines = File.ReadAllLines("files/renting_data.txt").ToList();
            return fileLines;
        }

        public static void WriteToRentingsFile(string rentingsAsString)
        {
            File.WriteAllText(RentingFilepath, rentingsAsString);
        }

        public static List<string> ReadVehiclesFile()
        {
            var fileLines = File.ReadAllLines("files/vehicle_list.txt").ToList();
            return fileLines;
        }

        public static void WriteToVehiclesFile(string vehiclesAsString)
        {
            File.WriteAllText(VehiclesFilepath, vehiclesAsString);
        }
    }
}