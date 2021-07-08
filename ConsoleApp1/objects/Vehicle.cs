namespace ConsoleApp1.objects
{
    public class Vehicle
    {
        protected string Brand;
        protected string Model;
        protected string ProductionDate;
        protected double Value;
        protected double Depreciation;
        protected double Odometer;
        protected bool Available;

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
//-----------TO STRING-----------------------------------------
        public override string ToString()
        {
            return GetType().Name + "_" + Brand + "_" + Model + "_" + ProductionDate + "_" + Value + "_" + Depreciation + "_" + Odometer + "_" + Available;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
        public Muscle(string productionDate, double odometer, bool available) : base(productionDate, odometer, available)
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
        public PickUp(string productionDate, double odometer, bool available) : base(productionDate, odometer, available)
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