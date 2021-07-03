using System;
using System.Collections.Generic;
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
                              "3.Admin Profile" +
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
            var client = InputClientDta();
            var clientVehicleTypeChoice = ClientVehicleTypeChoice();
            var clientVehicleChoice = ClientVehicleChoice(clientVehicleTypeChoice);
            var clientVehicleRentingDate = ClientVehicleRentingDateInput();
            var clientVehicleReturnDate = ClientVehicleReturnDateInput();
            FileService.WriteToRentingsFile(client.GetName() + "_" + client.GetSurname()  );
            Console.Clear();
            MainMenu();
        }

        private Client InputClientDta()
        {
            Console.WriteLine("Input your name:");
            var clientName = Console.ReadLine();
            Console.WriteLine("Input your surname:");
            var clientSurname = Console.ReadLine();
            return ClientService.CreateClient(clientName, clientSurname);
            
        }

        private string ClientVehicleTypeChoice()
        {
            Console.WriteLine("Choose type of ca you want to rent\n" +
                              "1.Normal Car\n" +
                              "2.Muscle Car\n" +
                              "3.Pick-Up Truck");
            return Console.ReadLine() switch
            {
                "1" => "vehicle",
                "2" => "muscle",
                "3" => "pickup",
                _ => ClientVehicleTypeChoice()
            };
        }

        private string ClientVehicleChoice(string vehicleType)
        {
            List<string> vehiclesOfChoosenType = new List<string>();
            var vehiclesList = FileService.ReadVehiclesFile();
            foreach (var vehicle in vehiclesList)
            {
                if (vehicle.Contains(vehicleType) && vehicle.Contains("true"))
                {
                    vehiclesList.Add(vehicle);
                }
            }
            Console.WriteLine("Choose the car by typing its number");
            for (int i = 1; i < vehiclesOfChoosenType.Count + 1; i++)
            {
                Console.WriteLine(i + vehiclesOfChoosenType[i-1]);
            }

            var clientVehicleChoice = int.Parse(Console.ReadLine());
            var choosenVehicle = vehiclesOfChoosenType[clientVehicleChoice - 1];
            return choosenVehicle;
        }

        private string ClientVehicleRentingDateInput()
        {
            //TODO
            Console.WriteLine("NOT AVAILABLE YET!");
            MainMenu();
            return "";
        }

        private string ClientVehicleReturnDateInput()
        {
            //TODO
            Console.WriteLine("NOT AVAILABLE YET!");
            MainMenu();
            return "";
        }
        
//----------------------------------------------------------------------------------------------------------------------
        private void RentingList()
        {
            Console.WriteLine("---------------Renting List Downloading--------------");
            var lines = FileService.ReadRentingsFile();
            foreach (var line in lines) Console.WriteLine(line);
            Console.WriteLine("CLICK ENTER");
            Console.ReadLine();
            MainMenu();
        }

        private void AdminMenu()
        {
            //TODO
            Console.WriteLine("NOT AVAILABLE YET!");
            MainMenu();
        }
//----------------------------------------------------------------------------------------------------------------------
        private void Quit()
        {
            Console.WriteLine("---------------Quiting Process--------------");
            Environment.Exit(0);
        }
    }
}