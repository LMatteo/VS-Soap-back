using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class CommandHandler
    {
        List<Command> commands;

        public CommandHandler(params Command[] commands)
        {
            Console.WriteLine("type ? for help");
            this.commands = new List<Command>(commands);
        }

        public void Process(string[] args)
        {
            if(args[0] == "?")
            {
                printHelp();
                return;
            }

            foreach (Command command in commands)
            {
                if(args[0] == command.GetName())
                {
                    command.Process(args);
                    return;
                }
            }

            Console.WriteLine("Command not found");
            return;
        }

        private void printHelp()
        {
            Console.WriteLine("? : print help");
            foreach(Command command in commands)
            {
                Console.WriteLine(command.PrintHelp());
            }
        }
    }

    interface Command
    {
        string GetName();
        void Process(string[] args);
        string PrintHelp();
    }

    class QuitCommand : Command
    {
        public string GetName()
        {
            return "quit";
        }

        public string PrintHelp()
        {
            return GetName() +" : end the program ";
        }

        public void Process(string[] args)
        {
            System.Environment.Exit(0);
        }
    }

    class ListCityCommand : Command
    {
        private BikeServiceClient client;

        public ListCityCommand(BikeServiceClient client)
        {
            this.client = client;
        }

        public string GetName()
        {
            return "city";
        }

        public string PrintHelp()
        {
            return GetName() +" : display all the cities";
        }

        public void Process(string[] args)
        {
            if (args.Length !=1)
            {
                Console.Error.Write("Wrong number of arguments \n");
                return;
            }
            string[] cities = client.ListCity();

            if (cities.Length == 0)
            {
                Console.Error.Write("Something went wrong with the request ...\n");
                return;
            }
            foreach (string curr in cities)
            {
                Console.WriteLine(curr);
            }
        }
    }

    class ListStationsCommand : Command
    {
        private BikeServiceClient client;

        public ListStationsCommand(BikeServiceClient client)
        {
            this.client = client;
        }

        public string GetName()
        {
            return "station";
        }

        public string PrintHelp()
        {
            return GetName() + " <city> : return all the stations of the given city";
        }

        public void Process(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.Write("Wrong number of arguments\n");
                return;
            }

            string[] stations = client.ListStation(args[1]);

            if (stations.Length == 0)
            {
                Console.Error.Write("Something went wrong with the request ...\n");
                return;
            }
            foreach (string curr in stations)
            {
                Console.WriteLine(curr);
            }
        }
    }

    class AvailableBikeCommand : Command
    {
        private BikeServiceClient client;

        public AvailableBikeCommand(BikeServiceClient client)
        {
            this.client = client;
        }

        public string GetName()
        {
            return "bike";
        }

        public string PrintHelp()
        {
            return GetName() + " <city> <station> : return name of the given station in the given city";
        }

        public void Process(string[] args)
        {
            if (args.Length != 3)
            {
                Console.Error.Write("Wrong number of arguments\n");
                return;
            }

            int available = client.AvailableBike(args[1], args[2]);

            if (available == -1)
            {
                Console.Error.Write("Something went wrong with the request ...\n");
                return;
            }
            Console.Write("number of available bike in station :");
            Console.WriteLine(available);
        }
    }
}
