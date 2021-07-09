using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ConsoleApp1.objects;

namespace ConsoleApp1.services
{
    public static class RentingService
    {
        public static List<Renting> GetRentings()
        {
            var rentingsListAsStrings = FileService.ReadRentingsFile();
            var rentingsList = new List<Renting>();
            try
            {
                foreach (var rentAsArray in rentingsListAsStrings.Select(rent => rent.Split("_")))
                {
                    var client = new Client(rentAsArray[0], rentAsArray[1]);
                    var productionDate = rentAsArray[5];
                    var odometer = double.Parse(rentAsArray[8]);
                    var isAvailable = bool.Parse(rentAsArray[9]);
                    var rentingDate = DateTime.ParseExact(rentAsArray[10]!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    var returnDate = DateTime.ParseExact(rentAsArray[11]!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    var rentingCost = double.Parse(rentAsArray[12]);
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
            }
            catch (IndexOutOfRangeException)
            {
                return new List<Renting>();
            }

            return rentingsList;
        }

        public static Renting CreateRenting(Client client, Vehicle vehicle, DateTime rentingDate, DateTime returnDate,
            List<Renting> rentings)
        {
            var rentingCost = CalculateRentingCost(vehicle, rentingDate, returnDate);
            var newRent = new Renting(client, vehicle, rentingDate, returnDate, rentingCost);
            rentings.Add(newRent);
            return newRent;
        }

        private static double CalculateRentingCost(Vehicle vehicle, DateTime rentingDate, DateTime returnDate)
        {
            var cost = CalculateDiscount(vehicle.GetValue(), rentingDate, returnDate);
            return cost;
        }

        private static double CalculateDiscount(double dayCost, DateTime rentingDate, DateTime returnDate)
        {
            var startOfDiscount = DateTime.ParseExact("01.03.2021", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var endOfDiscount = DateTime.ParseExact("26.06.2021", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var rentingDays = returnDate.Subtract(rentingDate).TotalDays;
            var discount = 0.75;
            //Gdy wynajem następuje przed okresem lub po okresie
            if ((rentingDate < startOfDiscount) &
                (returnDate > endOfDiscount) ||
                (rentingDate > endOfDiscount) &
                (returnDate > endOfDiscount))
            {
                var cost = rentingDays * dayCost;
                return cost;
            }

            // Gdy wynajem następuje przed okresem i kończy się w okresie
            if ((rentingDate < startOfDiscount) &
                (returnDate <= endOfDiscount) &
                (returnDate >= startOfDiscount))
            {
                var rentingDaysBeforeDiscount = startOfDiscount.Subtract(rentingDate).TotalDays;
                var rentingDaysInDiscount = returnDate.Subtract(startOfDiscount).TotalDays;
                var beforeDiscountCost = rentingDaysBeforeDiscount * dayCost;
                var inDiscountCost = rentingDaysInDiscount * dayCost * discount;
                var totalCost = beforeDiscountCost + inDiscountCost;
                return totalCost;
            }

            // Gdy wynajem następuje w trakcie okresu okresu i kończy po okresie
            if ((rentingDate >= startOfDiscount) &
                (rentingDate <= endOfDiscount) &
                (returnDate > endOfDiscount))
            {
                var rentingDaysInDiscount = endOfDiscount.Subtract(startOfDiscount).TotalDays;
                var rentingDaysAfterDiscount = returnDate.Subtract(endOfDiscount).TotalDays;
                var inDiscountCost = rentingDaysInDiscount * dayCost * discount;
                var afterDiscountCost = rentingDaysAfterDiscount * dayCost;
                var totalCost = inDiscountCost + afterDiscountCost;
                return totalCost;
            }

            // Gdy wynajem następuje  w trakcie okresu i kończy w trakcie okresu
            if ((rentingDate >= startOfDiscount) &
                (rentingDate <= endOfDiscount) &
                (returnDate >= startOfDiscount) &
                (returnDate <= endOfDiscount))
            {
                var totalCost = rentingDays * dayCost * discount;
                return totalCost;
            }

            // Gdy wynajem następuje w przed okresem okresu i kończy po okresie
            if ((rentingDate < startOfDiscount) &
                (returnDate > endOfDiscount))
            {
                var rentingDaysBeforeDiscount = startOfDiscount.Subtract(rentingDate).TotalDays;
                var rentingDaysInDiscount = endOfDiscount.Subtract(startOfDiscount).TotalDays;
                var rentingDaysAfterDiscount = returnDate.Subtract(endOfDiscount).TotalDays;
                var beforeDiscountCost = rentingDaysBeforeDiscount * dayCost;
                var inDiscountCost = rentingDaysInDiscount * dayCost * discount;
                var afterDiscountCost = rentingDaysAfterDiscount * dayCost;
                var totalCost = beforeDiscountCost + inDiscountCost + afterDiscountCost;
                return totalCost;
            }

            return 0;
        }

        public static void SaveRentings(List<Renting> rentingsList)
        {
            var rentingsAsString = "";
            foreach (var renting in rentingsList) rentingsAsString = renting + "\n";
            FileService.WriteToRentingsFile(rentingsAsString);
        }
    }
}