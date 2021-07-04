using System;
using ConsoleApp1.objects;

namespace ConsoleApp1.services
{
    public class RentingService
    {
        public static void CreateRenting(Client client, Vehicle vehicle, DateTime rentingDate, DateTime returnDate)
        {
            var rentingCost = CalculateRentingCost(vehicle, rentingDate, returnDate);
            var newRent = new Renting(client, vehicle, rentingDate, returnDate, rentingCost);
            FileService.WriteToRentingsFile(newRent.ToString());
        }
        
        private static double CalculateRentingCost(Vehicle vehicle, DateTime rentingDate, DateTime returnDate)
        {
            var rentingDays = returnDate.Subtract(rentingDate).TotalDays;
            var cost = rentingDays * vehicle.GetValue();
            return cost;
        }
    }
}