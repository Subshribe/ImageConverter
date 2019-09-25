using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ImageClassLibrary
{
    public class ImageConverter
    {
        public Bitmap ConvertToNegative(Bitmap image)
        {
            Bitmap negativeImage = new Bitmap(image);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    var originalColor = negativeImage.GetPixel(x, y);
                    var r = 255 - originalColor.R;
                    var g = 255 - originalColor.G;
                    var b = 255 - originalColor.B;
                    var negativeColor = Color.FromArgb(originalColor.A, r, g, b);
                    negativeImage.SetPixel(x, y, negativeColor);
                }
            }
            return negativeImage;
        }
        public Bitmap ConvertToBlackAndWhite(Bitmap image)
        {
            Bitmap blackWhiteImage = new Bitmap(image);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    var originalColor = blackWhiteImage.GetPixel(x, y);
                    var r = (originalColor.R + originalColor.G + originalColor.B) / 3;
                    var g = (originalColor.G + originalColor.R + originalColor.B) / 3;
                    var b = (originalColor.B + originalColor.G + originalColor.R) / 3;
                    var blackWhiteColor = Color.FromArgb(originalColor.A, r, g, b);
                    blackWhiteImage.SetPixel(x, y, blackWhiteColor);
                }
            }
            return blackWhiteImage;

        }
        public Bitmap ConvertToBlurred(Bitmap image)
        {
            Bitmap blurredImage = new Bitmap(image);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int redSum = 0;
                    int greenSum = 0;
                    int blueSum = 0;
                    var pixels = new List<Color>();
                    pixels.Add(blurredImage.GetPixel(x, y));
                    if (y > 0)
                    {
                        pixels.Add(blurredImage.GetPixel(x, y - 1));
                    }
                    if (x > 0)
                    {
                        pixels.Add(blurredImage.GetPixel(x - 1, y));
                    }
                    if (x > 0 && y > 0)
                    {
                        pixels.Add(blurredImage.GetPixel(x - 1, y - 1));
                    }
                    if (y < blurredImage.Height - 1)
                    {
                        pixels.Add(blurredImage.GetPixel(x, y + 1));
                    }
                    if (x < blurredImage.Width - 1)
                    {
                        pixels.Add(blurredImage.GetPixel(x + 1, y));
                    }
                    if (x < blurredImage.Width - 1 && y < blurredImage.Height - 1)
                    {
                        pixels.Add(blurredImage.GetPixel(x + 1, y + 1));
                    }
                    if (x > 0 && y < blurredImage.Height - 1)
                    {
                        pixels.Add(blurredImage.GetPixel(x - 1, y + 1));
                    }
                    if (x < blurredImage.Width - 1 && y > 0)
                    {
                        pixels.Add(blurredImage.GetPixel(x + 1, y - 1));
                    }
                    foreach (var pixel in pixels)
                    {
                        redSum += pixel.R;
                        greenSum += pixel.G;
                        blueSum += pixel.B;
                    }
                    redSum = redSum / pixels.Count;
                    greenSum = greenSum / pixels.Count;
                    blueSum = blueSum / pixels.Count;
                    blurredImage.SetPixel(x, y, Color.FromArgb(redSum, greenSum, blueSum));
                }
            }
            return blurredImage;
        }
    }
}
