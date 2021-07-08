using System;

namespace ConsoleApp1.objects
{
    public class Renting
    {
        public Client _client { get; }
        public Vehicle _vehicle { get; }
        public DateTime _rentingDate { get; }
        public DateTime _returnDate { get; }
        public double _rentingCost { get; } 

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
            return _client.ToString() + "_" + _vehicle.ToString() + "_" + _rentingDate.ToString("yyyy-MM-dd") + "_" +
                   _returnDate.ToString("yyyy-MM-dd") + "_" + _rentingCost;
        }
    }
}