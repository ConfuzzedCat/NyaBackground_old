using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;

namespace NyaBackground
{
    class ImageMerger 
    {
        public static string MergeImages(string outputFolder)
        {
            using (Image<Rgba32> img1 = Image.Load<Rgba32>("source1.png")) // load up source images
            using (Image<Rgba32> img2 = Image.Load<Rgba32>("source2.png"))
            using (Image<Rgba32> outputImage = new Image<Rgba32>(200, 150)) // create output image of the correct dimensions
            {
                // reduce source images to correct dimensions
                // skip if already correct size
                // if you need to use source images else where use Clone and take the result instead
                img1.Mutate(o => o.Resize(new SixLabors.ImageSharp.Size(100, 150))); 
                img2.Mutate(o => o.Resize(new SixLabors.ImageSharp.Size(100, 150)));

                // take the 2 source images and draw them onto the image
                outputImage.Mutate(o => o
                    .DrawImage(img1, new SixLabors.ImageSharp.Point(0, 0), 1f) // draw the first one top left
                    .DrawImage(img2, new SixLabors.ImageSharp.Point(100, 0), 1f) // draw the second next to it
                );

                outputImage.Save("ouput.png");
            }


            string imagePath = ChangeWallpaper.GetFolderPath();
            return imagePath;
        }
        public static string GetExtension(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return extension;
        }
    }
}