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
        public static void DownloadClient(string url)
        {
            string sourceFile = Path.Combine(Directory.GetCurrentDirectory(), "unmerge.png");
            string destFile = ChangeWallpaper.GetImagePath();

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, "unmerge.png");
                File.Move(sourceFile, destFile);
            }
            Console.WriteLine("Image downloaded");
            ImageMerger.MergeImages(ChangeWallpaper.GetImagePath(), Path.Combine(ChangeWallpaper.GetFolderPath(), "bg.png"));
        }
        public static dynamic JsonParser(WebRequest apiurl)
        {
            apiurl.Method = "GET";

            using WebResponse webResponse = apiurl.GetResponse();
            using Stream webStream = webResponse.GetResponseStream();
            using StreamReader reader = new StreamReader(webStream);
            string data = reader.ReadToEnd();
            dynamic json = Newtonsoft.Json.Linq.JObject.Parse(data);
            Console.WriteLine($"Image url: {json.url}");
            return json;
        }

   } 
}