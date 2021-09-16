

using System;
using System.IO;
using System.Net;

namespace NyaBackground
{
   class ImageDownloader
   {
       public static void FileNamer()
        {
            var rnd = new Random();
            rnd.Next();
            string rndName = rnd.Next(999999999).ToString();
            string file = ChangeWallpaper.GetFolderPath();
            bool exist = true;
            while(exist)
            {
                if (!File.Exists(Path.Combine(file, $"{rndName}.png")))
                {
                    File.Move(Path.Combine(file, "current.png"), Path.Combine(file, $"{rndName}.png"));
                    Console.WriteLine($"The old file is now named {rndName}.png...");
                    exist = false;
                }
                else
                {
                    rndName = rnd.Next(999999999).ToString();
                    File.Move(Path.Combine(file, "current.png"), Path.Combine(file, $"{rndName}.png"));
                }
            }
        }
        public static void DoesFileExist()
        {
            string file = ChangeWallpaper.GetImagePath();
            Console.WriteLine("Checking for existing files...");
            if (File.Exists(file))
            {
                Console.WriteLine("File found. Renaming old image...");
                FileNamer();                
            }
            Console.WriteLine("Requesting image...");
        }
        public static string ImageURLCreator(string tag, string cat)
        {
            string url = $"https://nekos.life/api/v2/{tag}/{cat}";
            return url;
        }
        public static void DownloadClient(string url)
        {
            string sourceFile = Path.Combine(Directory.GetCurrentDirectory(), "current.png");
            string destFile = ChangeWallpaper.GetImagePath();

            using (var client = new WebClient())
            {
                client.DownloadFile(url, "current.png");
                File.Move(sourceFile, destFile);
            }
            Console.WriteLine("Image downloaded");            
        }
        public static dynamic JsonParser(WebRequest apiurl)
        {
            apiurl.Method = "GET";

            using var webResponse = apiurl.GetResponse();
            using var webStream = webResponse.GetResponseStream();
            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            dynamic json = Newtonsoft.Json.Linq.JObject.Parse(data);
            Console.WriteLine($"Image url: {json.url}");
            return json;
        }

   } 
}