using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using ConsoleApp1.objects;
using ConsoleApp1.services;

namespace ConsoleApp1
{
    class Views
    {
        public void MainMenu()
        {
            Console.WriteLine("Main Menu:\n" +
                              "1.Rent a Car\n" +
                              "2.Show Renting List\n" +
                              "3.Admin Profile\n" +
                              "4.Quit\n" +
                              "Select your choice by typing a number");
            switch (Console.ReadLine())
            {
                case "1":
                    RentMenu();
                    break;
                case "2":
                    RentingList();
                    break;
                case "3":
                    AdminMenu();
                    break;
                case "4":
                    Quit();
                    break;
            }
        }
//-----------------RENTING MENU
        private void RentMenu()
        {
            Console.WriteLine("---------------Renting Process--------------");
            var client = InputClientData();
            var clientVehicleTypeChoice = VehicleTypeChoice();
            var clientVehicleChoice = GetAvailableVehicleOfTypeChoice(clientVehicleTypeChoice);
            var clientVehicleRentingDate = ClientVehicleRentingDateInput();
            var clientVehicleReturnDate = ClientVehicleReturnDateInput();
            RentingService.CreateRenting(client, clientVehicleChoice,clientVehicleRentingDate, clientVehicleReturnDate);
            Console.Clear();
            MainMenu();
        }

        private Client InputClientData()
        {
            Console.WriteLine("Input your name:");
            var clientName = Console.ReadLine();
            Console.WriteLine("Input your surname:");
            var clientSurname = Console.ReadLine();
            return ClientService.CreateClient(clientName, clientSurname);
            
        }

        private string VehicleTypeChoice()
        {
            Console.WriteLine("Choose type of ca you want to rent\n" +
                              "1.Normal Car\n" +
                              "2.Muscle Car\n" +
                              "3.Pick-Up Truck");
            return Console.ReadLine() switch
            {
                "1" => "Normal",
                "2" => "Muscle",
                "3" => "PickUp",
                _ => VehicleTypeChoice()
            };
        }

        private DateTime ClientVehicleRentingDateInput()
        {
            Console.WriteLine("When do you want to borrow the car\n" +
                              "USE YYYY-MM-DD Format");
            var dateAsString = Console.ReadLine();
            DateTime rentingDate;
            try
            {
                rentingDate = DateTime.Parse(dateAsString!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert your input");
                return ClientVehicleRentingDateInput();
            }
            return rentingDate;
        }

        private DateTime ClientVehicleReturnDateInput()
        {
            Console.WriteLine("When do you want to return the car\n" +
                              "USE YYYY-MM-DD Format");
            var dateAsString = Console.ReadLine();
            DateTime returnDate;
            try
            {
                returnDate = DateTime.Parse(dateAsString!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert your input");
                return ClientVehicleReturnDateInput();
            }
            return returnDate;
        }
        private Vehicle GetAvailableVehicleOfTypeChoice(string clientVehicleTypeChoice)
        {
            List<Vehicle> availableVehiclesOfChoosenTypeList = VehicleService.GetAvailableVehiclesOfChoosenType(clientVehicleTypeChoice);

            if (availableVehiclesOfChoosenTypeList.Any())
            {
                Console.WriteLine("We are truly Sorry but we dont have available vehicles of your choice right now.\n" +
                                  "Now you will be moved to the main menu.");
                MainMenu();
            }
            Console.WriteLine("Choose the car by typing its number");
            for (int i = 1; i < availableVehiclesOfChoosenTypeList.Count + 1; i++)
            {
                Console.WriteLine(i+ ". " + availableVehiclesOfChoosenTypeList[i-1].ToString());
            }
        
            var clientVehicleChoice = int.Parse(Console.ReadLine());
            var choosenVehicle = availableVehiclesOfChoosenTypeList[clientVehicleChoice - 1];
            return choosenVehicle;
        }
        
//-----------------RENTING LIST DISPLAYING
        private void RentingList()
        {
            Console.WriteLine("---------------Renting List Downloading--------------");
            var lines = FileService.ReadRentingsFile();
            foreach (var line in lines) Console.WriteLine(line);
            Console.WriteLine("CLICK ENTER");
            Console.ReadLine();
            MainMenu();
        }
//-----------------ADMIN MENU

        private void AdminMenu()
        {
            Console.WriteLine("Welcome in ADMIN MENU\n" +
                              "Make a choice by typing a number below.\n" +
                              "1.Display rentings\n" +
                              "2.Add a Car\n");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("NOT AVAILABLE YET");
                    MainMenu();
                    break;
                case "2":
                    CreateVehicle();
                    break;
            }
        }

        private void CreateVehicle()
        {
            var vehicleTypeChoice = VehicleTypeChoice();
            var productionYear = ProductionYearInput();
            var odometer = OdometerInput();
            VehicleService.CreateVehicle(vehicleTypeChoice, productionYear, odometer);
            MainMenu();
        }

        private string ProductionYearInput()
        {
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
            Console.WriteLine("---------------Quiting Process--------------");
            Environment.Exit(0);
        }
    }
}