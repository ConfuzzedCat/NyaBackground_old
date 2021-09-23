using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
namespace NyaBackground
{
    class ImageMerger 
    {
        public static void MergeImages(string downloadImage, string backgroundImage)
        {
            string imagePath = ChangeWallpaper.GetFolderPath();            
            Image<Rgba32> downloadImg = Image.Load<Rgba32>(downloadImage);
            Image<Rgba32> backgroundImg = Image.Load<Rgba32>(backgroundImage);
            int downloadImageX = downloadImg.Width;
            int downloadImageY = downloadImg.Height;
            int backgroundImageX = backgroundImg.Width;
            int backgroundImageY = backgroundImg.Height;
            float locXtemp = (backgroundImageX * .5f - downloadImageX * .5f);
            float locYtemp = (backgroundImageY * .5f - downloadImageY * .5f);
            int locX = Convert.ToInt32(locXtemp);
            int locY = Convert.ToInt32(locYtemp);            
            downloadImg = Resizer(Corner.CornerImage(downloadImg, downloadImageX, downloadImageY), backgroundImg);
            using (Image<Rgba32> img1 = Image.Load<Rgba32>(backgroundImage))
            using (Image<Rgba32> img2 = Image.Load<Rgba32>(downloadImage))
            using (Image<Rgba32> outputImage = new(backgroundImageX, backgroundImageY))
            {
                outputImage.Mutate(o => o
                    .DrawImage(img1, new Point(0, 0), 1f) 
                    .DrawImage(img2, new Point(locX, locY), 1f)
                );
                outputImage.Save(System.IO.Path.Combine(imagePath, "current.png"));
            }
            string pic = System.IO.Path.Combine(imagePath, "current.png");
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                ChangeWallpaper.DisplayPicture(imagePath);
            } else Console.WriteLine("Manually change your wallpaper!");            
        }

        static Image<Rgba32> Resizer(Image<Rgba32> dwnImage, Image<Rgba32> bgImage)
        {
            
            int dwnImageX = dwnImage.Width;
            int dwnImageY = dwnImage.Height;
            int bgImageX = bgImage.Width;
            int bgImageY = bgImage.Height;
            var resizeFactorX = bgImageX/dwnImageX*dwnImageX;
            var resizeFactorY = bgImageY/dwnImageY*dwnImageY;
            
            Image<Rgba32> dwnImageResized;
            string tempLoc = System.IO.Path.Combine(ChangeWallpaper.GetFolderPath(), "unmerge.png");
            
             if(bgImageX < dwnImageX)
            {
                File.Delete(tempLoc);
                dwnImage.Mutate(x => x.Resize(bgImageX, 0));
                dwnImage.Save(tempLoc);
                dwnImageResized = Image.Load<Rgba32>(tempLoc);
            } else if (bgImageY < dwnImageY)
            {
                File.Delete(tempLoc);
                dwnImage.Mutate(x => x.Resize(0, bgImageY));
                dwnImage.Save(tempLoc);                
                dwnImageResized = Image.Load<Rgba32>(tempLoc);
            }
            dwnImageResized = dwnImage;
            return dwnImageResized;
        }
    }
}