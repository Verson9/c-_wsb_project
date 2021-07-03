namespace ConsoleApp1.objects
{
    public class Vehicle
    {
        protected string Brand;
        protected string Model;
        protected string ProductionDate = "2019";
        protected double Value;
        protected double Depreciation;
        protected double Odometer = 0;
        protected bool Available = true;

        public string GetBrand()
        {
            return Brand;
        }
        public string GetModel()
        {
            return Model;
        }
        public string GetProductionDate()
        {
            return ProductionDate;
        }
        public double GetValue()
        {
            return Value;
        }
        public double GetDepreciation()
        {
            return Depreciation;
        }
        public double GetOdometer()
        {
            return Odometer;
        }
        public void SetOdometer(double newValue)
        {
            Odometer = newValue;
        }       
        public bool GetAvailable()
        {
            return Available;
        }
        public void SetAvailable(bool newValue)
        {
            Available = newValue;
        }

//----------CONSTRUCTORS----------------------------------------
        public Vehicle(string productionDate, double odometer, bool available)
        {
            ProductionDate = productionDate;
            Odometer = odometer;
            Available = available;
        }

        public Vehicle(string productionDate, double odometer)
        {
            ProductionDate = productionDate;
            Odometer = odometer;
        }
//-----------TO STRING-----------------------------------------
        public override string ToString()
        {
            return "base.ToString();";
        }
    }
//----------NORMAL----------------------------------------------
    public class Normal:Vehicle
    {
        public Normal(string productionDate, double odometer, bool available) : base(productionDate, odometer, available)
        {
            Brand = "Fiat";
            Model = "Tipo";
            Value = 100;
            Depreciation = 200;
        }

        public Normal(string productionDate, double odometer) : base(productionDate, odometer)
        {
            Brand = "Fiat";
            Model = "Tipo";
            Value = 100;
            Depreciation = 200;
        }
    }
    //----------MUSCLE----------------------------------------------
    public class Muscle : Vehicle
    {
        public Muscle(string productionDate, double odometer, bool available) : base(productionDate, odometer, available)
        {
            Brand = "Ford";
            Model = "Mustang GT";
            Value = 150;
            Depreciation = 300;
        }

        public Muscle(string productionDate, double odometer) : base(productionDate, odometer)
        {
            Brand = "Ford";
            Model = "Mustang GT";
            Value = 150;
            Depreciation = 300;
        }
    }
//----------PICK UP----------------------------------------------
    public class PickUp : Vehicle
    {
        public PickUp(string productionDate, double odometer, bool available) : base(productionDate, odometer, available)
        {
            Brand = "Ford";
            Model = "Ranger";
            Value = 200;
            Depreciation = 400;
        }

        public PickUp(string productionDate, double odometer) : base(productionDate, odometer)
        {
            Brand = "Ford";
            Model = "Ranger";
            Value = 200;
            Depreciation = 400;
        }
    }
}