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
            Image downloadImg = Image.Load(downloadImage);
            Image backgroundImg = Image.Load(downloadImage);
            int downloadImageX = downloadImg.Width;
            int downloadImageY = downloadImg.Height;
            int backgroundImageX = backgroundImg.Width;
            int backgroundImageY = backgroundImg.Height;
            int locX = backgroundImageX * (1 / 2) - downloadImageX * (1 / 2);
            int locY = backgroundImageY * (1 / 2) - downloadImageY * (1 / 2);
            using (Image<Rgba32> img1 = Image.Load<Rgba32>(backgroundImage)) // load up source images
            using (Image<Rgba32> img2 = Image.Load<Rgba32>(downloadImage))
            using (Image<Rgba32> outputImage = new(backgroundImageX, backgroundImageY)) // create output image of the correct dimensions
            {
                // reduce source images to correct dimensions
                // skip if already correct size
                // if you need to use source images else where use Clone and take the result instead

                // take the 2 source images and draw them onto the image
                outputImage.Mutate(o => o
                    .DrawImage(img1, new Point(0, 0), 1f) // draw the first one top left
                    .DrawImage(img2, new Point(locX, locY), 1f) // draw the second next to it
                );

                outputImage.Save(Path.Combine(imagePath, "current.png"));
            }
            string pic = Path.Combine(imagePath, "current.png");
            ChangeWallpaper.DisplayPicture(imagePath);
        }
    }
}