using System;
using System.Runtime.InteropServices;

namespace NyaBackground
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            Start();
        }
        static void Start()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Environment.Exit(0);
            Console.WriteLine("Welcome!");
            ChangeWallpaper.GetImage();
            Console.Write("Want another background? yes or no: ");
            string restart = Console.ReadLine();
            if (restart != null) restart.ToLower();
            if (restart == "yes") Start();
        }
    }
}
