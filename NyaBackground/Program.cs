using System;
using System.Runtime.InteropServices;

namespace NyaBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Environment.Exit(1);
            Console.WriteLine("Welcome!");
            ChangeWallpaper.GetImage();
            Console.WriteLine(ChangeWallpaper.GetImagePath());
            
        }
    }
}

//bgimage_url: https://i.imgur.com/59J10Ch.jpeg
