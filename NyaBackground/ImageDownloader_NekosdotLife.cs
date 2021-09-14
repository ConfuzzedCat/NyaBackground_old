using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace NyaBackground
{
    class ImageDownloader_NekosdotLife
    {

        public static void FileNamer()
        {
            Console.WriteLine("File found. Renaming old image...");
            var rnd = new Random();
            rnd.Next();
            int rndInt = rnd.Next(999999999);
            string rndName = rndInt.ToString();
            string file = Path.Combine(Directory.GetCurrentDirectory(), "img");
            bool exist = true;
            while(exist)
            {
                if (!File.Exists(Path.Combine(file, $"{rndName}.png")))
                {
                    File.Move(Path.Combine(file, "current.png"), Path.Combine(file, $"{rndName}.png"));
                    Console.WriteLine($"The old file is now named {rndInt}.png...");
                    exist = false;
                }
                else
                {
                    rndInt = rnd.Next(999999999);
                    File.Move(Path.Combine(file, "current.png"), Path.Combine(file, $"{rndName}.png"));
                }
            }



        }
        static bool DoesFileExist()
        {
            bool returnBool = false;
            string file = ChangeWallpaper.ImagePath();
            Console.WriteLine("Checking for existing files...");
            if (File.Exists(file))
            {
                returnBool = true;
                
            }
            Console.WriteLine("Requesting image...");

            return returnBool;
        }

        static string ImageCreator(string tag, string cat)
        {
            string url = $"https://nekos.life/api/v2/{tag}/{cat}";

            return url;
        }

        
        public static void Neko()
        {
            if (DoesFileExist()) FileNamer();
            string sourceFile = Path.Combine(Directory.GetCurrentDirectory(), "current.png");
            string destFile = ChangeWallpaper.ImagePath();

            //var url = "https://nekos.life/api/v2/img/neko";

            var request = WebRequest.Create(ImageCreator("img", "neko"));
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();
            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            dynamic json = JObject.Parse(data);
            Console.WriteLine($"Image url: {json.url}");
            string imageURL = json.url;



            using (var client = new WebClient())
            {
                client.DownloadFile(imageURL, "current.png");
                File.Move(sourceFile, destFile);
            }
            Console.WriteLine("Image downloaded");

        }
    }
}
