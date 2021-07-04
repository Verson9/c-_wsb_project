using System;

namespace ConsoleApp1.objects
{
    public class Renting
    {
        private Client _client { get; }
        private Vehicle _vehicle { get; }
        private DateTime _rentingDate { get; }
        private DateTime _returnDate { get; }
        private double _rentingCost { get; } 

        public Renting(Client client, Vehicle vehicle, DateTime rentingDate, DateTime returnDate, double rentingCost)
        {
            _client = client;
            _vehicle = vehicle;
            _rentingDate = rentingDate;
            _returnDate = returnDate;
            _rentingCost = rentingCost;
        }

        public override string ToString()
        {
            return _client.ToString() + "_" + _vehicle.ToString() + "_" + _rentingDate.ToString("YYYY-MM-DD") + "_" +
                   _returnDate.ToString("YYYY-MM-DD") + "_" + _rentingCost;
        }
    }
}