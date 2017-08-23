using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // the wrapped main function
                MainAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.GetType()}! Details: {ex}");
            }
#if DEBUG
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
#endif
        }

        private static async Task MainAsync()
        {
            using (StreamWriter writer = File.CreateText(@"c:\tmp\file.txt"))
            {
                await writer.WriteLineAsync("Hello");
            }
        }
    }
}
