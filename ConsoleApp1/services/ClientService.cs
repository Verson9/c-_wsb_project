using ConsoleApp1.objects;

namespace ConsoleApp1.services
{
    public static class ClientService
    {
        public static Client CreateClient(string clientName, string clientSurname)
        {
            return new Client(clientName, clientSurname);
        }
    }
}