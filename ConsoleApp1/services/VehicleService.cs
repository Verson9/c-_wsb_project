using System;
using System.Collections.Generic;
using ConsoleApp1.objects;

namespace ConsoleApp1.services
{
    public class VehicleService
    {
        public List<Vehicle> getVehicles()
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
                Vehicle vehicle;
                switch (type)
                {
                    case "normal":
                        vehicle = new Normal(productionDate, double.Parse(odometer), Boolean.Parse(available));
                        break;
                    case "muscle":
                        vehicle = new Muscle(productionDate, double.Parse(odometer), Boolean.Parse(available));
                        break;
                    case "pickup":
                        vehicle = new PickUp(productionDate, double.Parse(odometer), Boolean.Parse(available));
                        break;
                    default:
                        vehicle = null;
                        break;
                }

                vehiclesList.Add(vehicle);
            }
            return vehiclesList;
        }

        public List<Vehicle> getAvailableVehicles()
        {
            List<Vehicle> vehiclesList = getVehicles();
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
    }
}