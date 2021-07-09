namespace ConsoleApp1.objects
{
    public class Vehicle
    {
        protected bool Available;
        protected string Brand;
        protected double Depreciation;
        protected string Model;
        protected double Odometer;
        protected string ProductionDate;
        protected double Value;

//----------CONSTRUCTORS----------------------------------------
        protected Vehicle(string productionDate, double odometer, bool available)
        {
            ProductionDate = productionDate;
            Odometer = odometer;
            Available = available;
        }

        protected Vehicle(string productionDate, double odometer)
        {
            ProductionDate = productionDate;
            Odometer = odometer;
            Available = true;
        }

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

//-----------TO STRING-----------------------------------------
        public override string ToString()
        {
            return GetType().Name + "_" + Brand + "_" + Model + "_" + ProductionDate + "_" + Value + "_" +
                   Depreciation + "_" + Odometer + "_" + Available;
        }
    }

//----------NORMAL----------------------------------------------
    public class Normal : Vehicle
    {
        public Normal(string productionDate, double odometer, bool available) : base(productionDate, odometer,
            available)
        {
            Brand = "Fiat";
            Model = "Tipo";
            Value = 100;
            Depreciation = 200;
            ProductionDate = productionDate;
            Odometer = odometer;
            Available = available;
        }

        public Normal(string productionDate, double odometer) : base(productionDate, odometer)
        {
            Brand = "Fiat";
            Model = "Tipo";
            Value = 100;
            Depreciation = 200;
            ProductionDate = productionDate;
            Odometer = odometer;
            Available = true;
        }
    }

    //----------MUSCLE----------------------------------------------
    public class Muscle : Vehicle
    {
        public Muscle(string productionDate, double odometer, bool available) : base(productionDate, odometer,
            available)
        {
            Brand = "Ford";
            Model = "Mustang GT";
            Value = 150;
            Depreciation = 300;
            ProductionDate = productionDate;
            Odometer = odometer;
            Available = available;
        }

        public Muscle(string productionDate, double odometer) : base(productionDate, odometer)
        {
            Brand = "Ford";
            Model = "Mustang GT";
            Value = 150;
            Depreciation = 300;
            ProductionDate = productionDate;
            Odometer = odometer;
            Available = true;
        }
    }

//----------PICK UP----------------------------------------------
    public class PickUp : Vehicle
    {
        public PickUp(string productionDate, double odometer, bool available) : base(productionDate, odometer,
            available)
        {
            Brand = "Ford";
            Model = "Ranger";
            Value = 200;
            Depreciation = 400;
            ProductionDate = productionDate;
            Odometer = odometer;
            Available = available;
        }

        public PickUp(string productionDate, double odometer) : base(productionDate, odometer)
        {
            Brand = "Ford";
            Model = "Ranger";
            Value = 200;
            Depreciation = 400;
            ProductionDate = productionDate;
            Odometer = odometer;
            Available = true;
        }
    }
}