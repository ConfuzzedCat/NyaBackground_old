using System;
using System.Runtime.InteropServices;
using System.Timers;

namespace NyaBackground
{
    class Program
    {
        public static void Main()
        {
            //Fix OutOfMemory Error!
            Console.WriteLine("Welcome!");
            Start();
        }
        static void Start()
        {
            Timer timer = new Timer(30 * 60 * 1000);
            ChangeWallpaper.GetImage();
            timer.Start();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                while(true){
                    timer.Elapsed += OnTick; // Which can also be written as += new ElapsedEventHandler(OnTick);
                }           
            }
        }

        static void OnTick(object source, ElapsedEventArgs e)
        { 
            ChangeWallpaper.GetImage();
        }
    }
}
