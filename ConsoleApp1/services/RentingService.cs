using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using ConsoleApp1.objects;

namespace ConsoleApp1.services
{
    public static class RentingService
    {
        public static List<Renting> GetRentings()
        {
            var rentingsListAsStrings = FileService.ReadRentingsFile();
            var rentingsList = new List<Renting>();
            foreach (var rentAsArray in rentingsListAsStrings.Select(rent => rent.Split("_")))
            {
                Client client = new Client(rentAsArray[0], rentAsArray[1]);
                string productionDate = rentAsArray[7];
                double odometer = double.Parse(rentAsArray[8]);
                Boolean isAvailable = bool.Parse(rentAsArray[9]);
                DateTime rentingDate = DateTime.ParseExact(rentAsArray[10]!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime returnDate = DateTime.ParseExact(rentAsArray[11]!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                double rentingCost = double.Parse(rentAsArray[12]);
                Vehicle vehicle;
                
                switch (rentAsArray[2])
                {
                    case "Normal":
                        vehicle = new Normal(productionDate, odometer, isAvailable);
                        rentingsList.Add(new Renting(client, vehicle, rentingDate, returnDate, rentingCost));
                        break;
                    case "Muscle":
                        vehicle = new Muscle(productionDate, odometer, isAvailable);
                        rentingsList.Add(new Renting(client, vehicle, rentingDate, returnDate, rentingCost));
                        break;
                    case "PickUp":
                        vehicle = new PickUp(productionDate, odometer, isAvailable);
                        rentingsList.Add(new Renting(client, vehicle, rentingDate, returnDate, rentingCost));
                        break;
                }
            }
            return rentingsList;
        }
        public static Renting CreateRenting(Client client, Vehicle vehicle, DateTime rentingDate, DateTime returnDate, List<Renting> rentings)
        {
            var rentingCost = CalculateRentingCost(vehicle, rentingDate, returnDate);
            var newRent = new Renting(client, vehicle, rentingDate, returnDate, rentingCost);
            rentings.Add(newRent);
            return newRent;
        }
        
        private static double CalculateRentingCost(Vehicle vehicle, DateTime rentingDate, DateTime returnDate)
        {
            var rentingDays = returnDate.Subtract(rentingDate).TotalDays;
            var cost = rentingDays * vehicle.GetValue();
            if (returnDate<DateTime.ParseExact("2021-06-26","yyyy-MM-dd", CultureInfo.InvariantCulture))
            {
                cost = cost * 0.75;
            }
            return cost;
        }
    }
}