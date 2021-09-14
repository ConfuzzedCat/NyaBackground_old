using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NyaBackground
{
    class Program
    {
        static void Main(string[] args) => RunAsync();

        public static async void RunAsync()
        {
            
            bool testing = true;
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && !testing) 
            {
                Console.WriteLine("Linux not supported yet.");
                Environment.Exit(0);
            }
            Console.WriteLine("Welcome!");
            
            //await ChangeWallpaper.GetImageAsync();
            await ImageDownloader.NekoAsync();
            Console.WriteLine(ChangeWallpaper.GetImagePath());


        }
    }
}

//bgimage_url: https://i.imgur.com/59J10Ch.jpeg
