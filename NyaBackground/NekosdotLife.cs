using System.Net;
namespace NyaBackground
{
    class NekosdotLife : ImageDownloader
    {
        public static string ImageURLCreator(string tag, string cat)
        {
            string url = $"https://nekos.life/api/v2/{tag}/{cat}";
            return url;
        }
        public static void NekoIMG()
        {
            DoesFileExist();
            WebRequest request = WebRequest.Create(ImageURLCreator("img", "neko")); //Fix OutOfMemory Error!
            string imageURL = JsonParser(request).url;
            DownloadClient(imageURL);
        }
        public static void WaifuIMG()
        {
            DoesFileExist();
            WebRequest request = WebRequest.Create(ImageURLCreator("img", "waifu"));
            string imageURL = JsonParser(request).url;
            DownloadClient(imageURL);
        }
    }
}
