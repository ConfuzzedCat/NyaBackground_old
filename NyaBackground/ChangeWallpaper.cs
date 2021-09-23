using System;
using System.Runtime.InteropServices;
using System.IO;
namespace NyaBackground
{
    class ChangeWallpaper
    {
        public static void GetImage()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "img");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"{path} created!");
            }
            Console.WriteLine("Type either \"neko\" or \"waifu\".");
            CategorySwitch(Console.ReadLine());
            string photo = Path.Combine(path,"current.png");
            Console.WriteLine(photo);
        }
        static void CategorySwitch(string cat)
        {
            switch (cat)
            {
                case "neko":
                    NekosdotLife.NekoIMG();
                    break;
                case "waifu":
                    NekosdotLife.WaifuIMG();
                    break;
                default:
                    Console.WriteLine("Invalid category. Vaild categories: \"neko\" and \"waifu\".");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }
        }
        public static string GetImagePath()
        {
            string path = GetFolderPath();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string photo = Path.Combine(path,"unmerge.png");
            return photo;
        }
        public static string GetFolderPath()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "img");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);
        private const uint SPI_SETDESKWALLPAPER = 0x14;
        public static void DisplayPicture(string file_name)
        {
            uint flags = 0;
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0, file_name, flags))
            {
                Console.WriteLine("Error");
            }
        }
    }
}