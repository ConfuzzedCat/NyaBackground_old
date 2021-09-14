using System;

namespace NyaBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            ChangeWallpaper.GetImage();
            Console.WriteLine(ChangeWallpaper.GetImagePath());
        }
    }
}

//bgimage_url: https://i.imgur.com/59J10Ch.jpeg
