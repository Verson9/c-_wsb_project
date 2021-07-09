using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ConsoleApp1.objects;

namespace ConsoleApp1.services
{
    public class VehicleService
    {
        public static List<Vehicle> GetVehicles()
        {
            var vehiclesListAsStrings = FileService.ReadVehiclesFile();
            var vehiclesList = new List<Vehicle>();
            try
            {
                foreach (var vehicleDataAsString in vehiclesListAsStrings)
                {
                    var vehicleDataAsArray = vehicleDataAsString.Split("_");
                    var type = vehicleDataAsArray[0];
                    var brand = vehicleDataAsArray[1];
                    var model = vehicleDataAsArray[2];
                    var productionDate = vehicleDataAsArray[3];
                    var value = vehicleDataAsArray[4];
                    var depreciation = vehicleDataAsArray[5];
                    var odometer = vehicleDataAsArray[6];
                    var available = vehicleDataAsArray[7];
                    Vehicle vehicle = type switch
                    {
                        "Normal" => new Normal(productionDate, double.Parse(odometer), Boolean.Parse(available)),
                        "Muscle" => new Muscle(productionDate, double.Parse(odometer), Boolean.Parse(available)),
                        "PickUp" => new PickUp(productionDate, double.Parse(odometer), Boolean.Parse(available)),
                        _ => null
                    };
                    vehiclesList.Add(vehicle);
                }
            }
            catch (IndexOutOfRangeException)
            {
                return new List<Vehicle>();
            }
            return vehiclesList;
        }

        public static List<Vehicle> GetAvailableVehicles(List<Vehicle> vehiclesList)
        {
            var availableVehicles = new List<Vehicle>();
            foreach (var vehicle in vehiclesList)
            {
                if (vehicle.GetAvailable())
                {
                    availableVehicles.Add(vehicle);
                }
            }
            return availableVehicles;
        }

        public static List<Vehicle> GetAvailableVehiclesOfChoosenType(string type, List<Vehicle> vehiclesList)
        {
            var availableVehicles = GetAvailableVehicles(vehiclesList);
            var availableVehiclesOfChoosenType = new List<Vehicle>();
            foreach (var availableVehicle in availableVehicles)
            {
                if (availableVehicle.GetType().Name == type)
                {
                    availableVehiclesOfChoosenType.Add(availableVehicle);
                }
            }
            return availableVehiclesOfChoosenType;
        }

        public static void ReturnOutdatedRentsVehicle(List<Vehicle> vehiclesList, List<Renting> rentings)
        {
            foreach (var renting in rentings)
            {
                foreach (var vehicle in vehiclesList)
                {
                    var vehicleFromRenting = renting._vehicle;
                    if (vehicle.ToString().Equals(vehicleFromRenting.ToString()) & renting._returnDate <= DateTime.Today)
                    {
                        vehicle.SetAvailable(true);
                    }
                }
            }
        }
        public static void CreateVehicle(string type, string productionYear, double odometer, List<Vehicle> vehiclesList)
        {
            Vehicle newVehicle = type switch
            {
                "Normal" => new Normal(productionYear, odometer),
                "Muscle" => new Muscle(productionYear, odometer),
                "PickUp" => new PickUp(productionYear, odometer),
                _ => null
            };
            vehiclesList.Add(newVehicle);
        }

        public static void SaveVehicles(List<Vehicle>vehiclesList)
        {
            string vehiclesAsString = "";
            foreach (var vehicle in vehiclesList)
            {
                vehiclesAsString += vehicle.ToString() + "\n";
            }
            FileService.WriteToVehiclesFile(vehiclesAsString);
        }
    }
}