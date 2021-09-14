using System;
using System.Runtime.InteropServices;

namespace NyaBackground
{
    class Program
    {
        //static void Main(string[] args) => Run();

        public static void Main(string[] args)
        {
            bool linuxTesting = false;
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && !linuxTesting)
            {
                Console.WriteLine("Linux not supported.");
                Environment.Exit(0);
            }
            Console.WriteLine("Welcome!");

            ImageDownloader_NekosdotLife.Neko();
            //Console.WriteLine(ChangeWallpaper.GetImagePath());
            Console.ReadLine();


        }
    }
}

//bgimage_url: https://i.imgur.com/59J10Ch.jpeg
