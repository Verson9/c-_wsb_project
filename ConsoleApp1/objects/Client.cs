namespace ConsoleApp1.objects
{
    public class Client
    {
        private readonly string _surname;
        private readonly string _name;

        public string GetName() => _name;

        public string GetSurname() => _surname;

        public Client(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }
    }
}