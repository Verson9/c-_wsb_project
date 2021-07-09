namespace ConsoleApp1.objects
{
    public class Client
    {
        private readonly string _name;
        private readonly string _surname;

        public Client(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public override string ToString()
        {
            return _name + "_" + _surname;
        }
    }
}