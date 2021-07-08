using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using ConsoleApp1.objects;
using ConsoleApp1.services;

namespace ConsoleApp1
{
    internal class Views
    {
        private List<Vehicle> _vehiclesList = new List<Vehicle>();
        private List<Renting> _rentingsList = new List<Renting>();
         

         public void Start()
         {
             _vehiclesList = VehicleService.GetVehicles();
             _rentingsList = RentingService.GetRentings();
             Console.WriteLine("---------------Program Starting--------------");
             VehicleService.ReturnOutdatedRentsVehicle(_vehiclesList, _rentingsList);
             MainMenu();
         }

        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu:\n" +
                              "1.Rent a Vehicle\n" +
                              "2.Show available vehicles\n" +
                              "3.Admin Profile\n" +
                              "4.Quit\n" +
                              "Select your choice by typing a number");
            switch (Console.ReadLine())
            {
                case "1":
                    RentMenu();
                    break;
                case "2":
                    DisplayAvailableVehicles();
                    break;
                case "3":
                    AdminMenu();
                    break;
                case "4":
                    Quit();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
//-----------------RENTING MENU
        private void RentMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------Renting Process--------------");
            Client client = CreateClient();
            string clientVehicleTypeChoice = ChoseVehicleType();
            Vehicle clientVehicleOfChoice = GetAvailableVehicleOfTypeChoice(clientVehicleTypeChoice);
            DateTime clientVehicleRentingDate = ClientVehicleRentingDateInput();
            DateTime clientVehicleReturnDate = ClientVehicleReturnDateInput(clientVehicleRentingDate);
            clientVehicleOfChoice.SetAvailable(false);
            Renting renting = RentingService.CreateRenting(client, clientVehicleOfChoice,clientVehicleRentingDate, clientVehicleReturnDate, _rentingsList);
            Console.WriteLine("You borrowed a Vehicle:" + renting + "\n" +
                              "This will cost you: " + renting._rentingCost);
            FileService.WriteToRentingsFile(_rentingsList);
            FileService.WriteToVehiclesFile(_vehiclesList);
            Console.WriteLine("Click ENTER");
            Console.ReadLine();
            MainMenu();
        }

        private Client CreateClient()
        {
            Console.Clear();
            Console.WriteLine("Input your name:");
            var clientName = Console.ReadLine();
            Console.WriteLine("Input your surname:");
            var clientSurname = Console.ReadLine();
            return ClientService.CreateClient(clientName, clientSurname);
        }

        private string ChoseVehicleType()
        {
            Console.Clear();
            Console.WriteLine("Choose type of vehicle you want to rent\n" +
                              "1.Normal Car\n" +
                              "2.Muscle Car\n" +
                              "3.Pick-Up Truck");
            switch (Console.ReadLine())
            {
                case "1":
                    return "Normal";
                case "2":
                    return "Muscle";
                case "3":
                    return "PickUp";
                default:
                    return ChoseVehicleType();
            }
        }
        private Vehicle GetAvailableVehicleOfTypeChoice(string clientVehicleTypeChoice)
        {
            List<Vehicle> availableVehiclesOfChoosenTypeList = VehicleService.GetAvailableVehiclesOfChoosenType(clientVehicleTypeChoice, _vehiclesList);

            if (!availableVehiclesOfChoosenTypeList.Any())
            {
                Console.WriteLine("We are truly Sorry but we dont have available vehicles of your choice right now.\n" +
                                  "Now you will be moved to the main menu.");
                Console.ReadLine();
                MainMenu();
            }
            Console.Clear();
            Console.WriteLine("------Vehicles of chosen type:");
            for (int i = 1; i < availableVehiclesOfChoosenTypeList.Count + 1; i++)
            {
                Console.WriteLine(i+ ". " + availableVehiclesOfChoosenTypeList[i-1].ToString());
            }
            Console.WriteLine("Choose the car by typing its number");
            var clientVehicleChoice = int.Parse(Console.ReadLine());
            var choosenVehicle = availableVehiclesOfChoosenTypeList[clientVehicleChoice - 1];
            return choosenVehicle;
        }

        private DateTime ClientVehicleRentingDateInput()
        {
            Console.WriteLine("When do you want to borrow the car\n" +
                              "USE YYYY-MM-DD Format");
            var dateAsString = Console.ReadLine();
            DateTime rentingDate;
            try
            {
                rentingDate = DateTime.ParseExact(dateAsString!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert your input");
                return ClientVehicleRentingDateInput();
            }
            return rentingDate;
        }

        private DateTime ClientVehicleReturnDateInput(DateTime clientVehicleRentingDate)
        {
            Console.WriteLine("When do you want to return the car\n" +
                              "USE YYYY-MM-DD Format");
            var dateAsString = Console.ReadLine();
            DateTime returnDate;
            try
            {
                returnDate = DateTime.ParseExact(dateAsString!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (clientVehicleRentingDate > returnDate)
                {
                    Console.WriteLine("Return date is earlier than renting date!");
                    return ClientVehicleReturnDateInput(clientVehicleRentingDate);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert your input");
                return ClientVehicleReturnDateInput(clientVehicleRentingDate);
            }
            return returnDate;
        }

//-----------------RENTING LIST DISPLAYING
        private void DisplayAvailableVehicles()
        {
            Console.Clear();
            Console.WriteLine("---------------Renting List Downloading--------------");
            var availableVehicles = VehicleService.GetAvailableVehicles(_vehiclesList);
            foreach (var line in availableVehicles) Console.WriteLine(line.ToString());
            Console.WriteLine("CLICK ENTER");
            Console.ReadLine();
            MainMenu();
        }
//-----------------ADMIN MENU

        private void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome in ADMIN MENU\n" +
                              "Make a choice by typing a number below.\n" +
                              "1.Display rentings\n" +
                              "2.Add a Car\n");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    DisplayRentings();
                    break;
                case "2":
                    Console.Clear();
                    CreateVehicle();
                    break;
            }
        }

        private void DisplayRentings()
        {
            Console.Clear();
            if (!_rentingsList.Any())
            {
                Console.WriteLine("NO ITEMS TO DISPLAY");
                Console.ReadLine();
                AdminMenu();
            }
            foreach (var renting in _rentingsList)
            {
                Console.WriteLine(renting.ToString());
            }
            Console.WriteLine("CLICK ENTER");
            Console.ReadLine();
            MainMenu();
        }
        private void CreateVehicle()
        {
            var vehicleTypeChoice = ChoseVehicleType();
            var productionYear = ProductionYearInput();
            var odometer = OdometerInput();
            VehicleService.CreateVehicle(vehicleTypeChoice, productionYear, odometer, _vehiclesList);
            FileService.WriteToVehiclesFile(_vehiclesList);
            MainMenu();
        }

        private string ProductionYearInput()
        {
            Console.Clear();
            Console.WriteLine("Input production year:");
            var productionYearAsString =Console.ReadLine();
            double productionYear;
            try
            {
                productionYear =double.Parse(productionYearAsString);
                if (productionYear < 2019 || productionYear > DateTime.Now.Year)
                {
                    Console.WriteLine("Bad input!");
                    return ProductionYearInput();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Bad input!");
                return ProductionYearInput();
            }

            return productionYear.ToString(CultureInfo.InvariantCulture);
        }
        
        private double OdometerInput()
        {
            Console.Clear();
            Console.WriteLine("Input actual value of odometer:");
            var odometerAsString =Console.ReadLine();
            double odometer;
            try
            {
                odometer =double.Parse(odometerAsString);
                if (odometer < 0 )
                {
                    Console.WriteLine("Bad input!");
                    return OdometerInput();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Bad input!");
                return OdometerInput();
            }

            return odometer;
        }

//-----------------QUIT
        private void Quit()
        {
            Console.Clear();
            Console.WriteLine("---------------Quiting Process--------------");
            FileService.WriteToVehiclesFile(_vehiclesList);
            FileService.WriteToRentingsFile(_rentingsList);
            Environment.Exit(0);
        }
    }
}