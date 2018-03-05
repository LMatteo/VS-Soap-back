using System;


namespace Client
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

            while(true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                handler.Process(input.Split(' '));
            }

        }
    }
}
