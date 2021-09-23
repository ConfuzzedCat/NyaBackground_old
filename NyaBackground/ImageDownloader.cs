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
            string temp_1 = Path.Combine(file, "current.png");
            string temp_2 = Path.Combine(file, "unmerge.png");            
            if (File.Exists(temp_1))
            {
                rndName = rnd.Next(999999999).ToString();
                File.Move(temp_1, Path.Combine(file, $"{rndName}.png"));
                Console.WriteLine($"{temp_1} renamed to {Path.Combine(file, $"{rndName}.png")}");
            }
            if (File.Exists(temp_2))
            {
                rndName = rnd.Next(999999999).ToString();
                File.Move(temp_2, Path.Combine(file, $"{rndName}.png"));
                Console.WriteLine($"{temp_2} renamed to {Path.Combine(file, $"{rndName}.png")}");
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
            DoesFileExist();
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