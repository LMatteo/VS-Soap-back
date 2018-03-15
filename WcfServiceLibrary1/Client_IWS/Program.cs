using System;
using Client_IWS.ServiceReference1;

namespace Client_IWS
{
    class Program
    {
        static void Main(string[] args)
        {
            BikeServiceClient client = new BikeServiceClient();

            CommandHandler handler = new CommandHandler(
                new QuitCommand(),
                new ListCityCommand(client),
                new AvailableBikeCommand(client),
                new ListStationsCommand(client));

            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                handler.Process(input.Split(' '));
            }

        }
    }
}
