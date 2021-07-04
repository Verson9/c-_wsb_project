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
            return vehiclesList;
        }

        public static List<Vehicle> GetAvailableVehicles()
        {
            List<Vehicle> vehiclesList = GetVehicles();
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

        public static List<Vehicle> GetAvailableVehiclesOfChoosenType(string type)
        {
            var availableVehicles = GetAvailableVehicles();
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

        public static void CreateVehicle(string type, string productionYear, double odometer)
        {
            Vehicle newVehicle = null;
            switch (type)
            {
                case "Normal":
                    newVehicle = new Normal(productionYear, odometer);
                    break;
                case "Muscle":
                    newVehicle = new Muscle(productionYear, odometer);
                    break;
                case "PickUp":
                    newVehicle = new PickUp(productionYear, odometer);
                    break;
            }
            FileService.WriteToVehiclesFile(newVehicle.ToString());
        }
    }
}