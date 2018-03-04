using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperationClient client = new MathsOperationClient();
            Console.Write(client.add(5, 5));
            Console.WriteLine(client.add(10, 10));
        }
    }
}
