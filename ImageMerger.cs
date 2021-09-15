

namespace NyaBackground
{
    class ImageMerger 
    {
        private static List ConvertUrlsToBitmaps(string folderPath, ImageFormat imageFormat)
        {
            List bitmapList = new List();
            
            
            //List imagesFromFolder = Directory.GetFiles(folderPath, "*." + imageFormat, SearchOption.AllDirectories).ToList();
            // Loop Files
            foreach (string imgPath in imagesFromFolder)
            {
            try
            {
                var bmp = (Bitmap) Image.FromFile(imgPath);
                bitmapList.Add(bmp);
            }
            catch (Exception ex)
            {
            Console.Write(ex.Message);
            }
            }
            return bitmapList;
        }
        private static Bitmap Merge(IEnumerable images)
        {
        var enumerable = images as IList ?? images.ToList();
        var width = 0;
        var height = 0;
        // Get max width and height of the image
        foreach (var image in enumerable)
        {
            width = image.Width > width ? image.Width : width;
            height = image.Height > height ? image.Height : height;
        }
        // merge images
        var bitmap = new Bitmap(width, height);
        using (var g = Graphics.FromImage(bitmap))
        {
            foreach (var image in enumerable) {
            g.DrawImage(image, 0, 0);
            }
        }
        return bitmap;
        }
    }
}