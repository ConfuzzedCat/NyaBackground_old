using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NekosSharp;

namespace NyaBackground
{
    class ImageDownloader
    {
        public static NekoClient imgDownloader = new NekoClient("NyaBackground");
        
        public static async Task NekoAsync()
        {

            imgDownloader.SendRequest(true, );
            Console.WriteLine("Requesting image...");
            Request Req = await imgDownloader.Image_v3.Neko(1);
            Console.WriteLine(Req.ImageUrl);
            Console.WriteLine("Image downloaded");
            //Console.WriteLine(Req.Error);
            //imgDownloader.Image.Neko();
            
        }

    }
}
