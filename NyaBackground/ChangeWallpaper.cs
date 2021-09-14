using System;
using System.Runtime.InteropServices;
using System.IO;
//using NekosSharp;

namespace NyaBackground
{
    class ChangeWallpaper
    {
        
        public static string ImagePath()
        {
            string imagePath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "img"), "current.png");
            return imagePath;
        } 
        
        public static void GetImage()
        {



            string path = Path.Combine(Directory.GetCurrentDirectory(), "img");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"{path} created!");
            }
            ImageDownloader_NekosdotLife.Neko();
            Console.WriteLine("DEBUG: ImageDownloader.Neko() DONE");
            string photo = Path.Combine(path,"current.png");
            DisplayPicture(photo);
        }
        public static string GetImagePath()
        {


            string path = Path.Combine(Directory.GetCurrentDirectory(), "img");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string photo = $@"{path}\current.PNG";
            return photo;
        }
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;

        private static void DisplayPicture(string file_name)
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