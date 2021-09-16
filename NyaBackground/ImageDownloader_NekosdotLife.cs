﻿using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace NyaBackground
{
    class ImageDownloader_NekosdotLife : ImageDownloader
    {
        public static void NekoIMG()
        {
            DoesFileExist();
            WebRequest request = WebRequest.Create(ImageURLCreator("img", "neko"));
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
