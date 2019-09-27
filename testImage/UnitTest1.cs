using NUnit.Framework;
using System.Drawing;
using ImageClassLibrary;


namespace TestImageConverter 
{
    public class TestImageConverter
    {

        ImageConverter imageConverter = new ImageConverter();
        FileHandler fileHandler = new FileHandler();
        [Test]
        public void TestConvertToNegative()
        {
            Bitmap testImageNegative = new Bitmap(5, 5);
            for (int x = 0; x < testImageNegative.Width; x++)
            {
                for (int y = 0; y < testImageNegative.Height; y++)
                {
                    testImageNegative.SetPixel(x, y, Color.FromArgb(145, 120, 205));
                }
            }

            Bitmap expectedResult = new Bitmap(5, 5);
            for (int x = 0; x < expectedResult.Width; x++)
            {
                for (int y = 0; y < expectedResult.Height; y++)
                {
                    expectedResult.SetPixel(x, y, Color.FromArgb(110, 135, 50));
                }
            }
            
            Bitmap result = imageConverter.ConvertToNegative(testImageNegative);
            for (int x = 0; x < testImageNegative.Width; x++)
            {
                for (int y = 0; y < testImageNegative.Height; y++)
                {
                    Assert.AreEqual(expectedResult.GetPixel(x, y), result.GetPixel(x, y));
                }
            }
        }
       
        [Test]
        public void TestConvertToBlackAndWhite()
        {
            Bitmap testBlackAndWhite = new Bitmap(5, 5);
            for (int x = 0; x < testBlackAndWhite.Width; x++)
            {
                for (int y = 0; y < testBlackAndWhite.Width; y++)
                {
                    testBlackAndWhite.SetPixel(x, y, Color.FromArgb(120, 150, 100));
                }
            }
            
            Bitmap expectedResult = new Bitmap(5, 5);
            for (int x = 0; x < expectedResult.Width; x++)
            {
                for (int y = 0; y < expectedResult.Height; y++)
                {
                    expectedResult.SetPixel(x, y, Color.FromArgb(123, 123, 123));
                }
            }
            
            Bitmap result = imageConverter.ConvertToBlackAndWhite(testBlackAndWhite);
            for (int x = 0; x < testBlackAndWhite.Width; x++)
            {
                for (int y = 0; y < testBlackAndWhite.Height; y++)
                {
                    Assert.AreEqual(expectedResult.GetPixel(x, y), result.GetPixel(x, y));
                }
            }
        }
        
        [Test]
        public void TestAddSuffixToFile()
        {
            string expectedResult = @"C:\Users\91danand\Desktop\äpplen\äpplen_Negative.jpg";
            string result = fileHandler.AddSuffixToFile(@"C:\Users\91danand\Desktop\äpplen\äpplen.jpg", "Negative");
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestConvertToBlurred()
        {
            Bitmap testImageBlurred = new Bitmap(3, 3);
            for (int x = 0; x < testImageBlurred.Width; x++)
            {
                for (int y = 0; y < testImageBlurred.Height; y++)
                {
                    testImageBlurred.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    if (y == 1 && x == 1)
                    {
                        testImageBlurred.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            Bitmap expectedResult = new Bitmap(3, 3);
            for (int x = 0; x < expectedResult.Width; x++)
            {
                for (int y = 0; y < expectedResult.Height; y++)
                {
                    if (x == 1 && y == 1)
                    {
                        expectedResult.SetPixel(x, y, Color.FromArgb(226, 226, 226));
                    }
                    else if (x != 1 && y != 1)
                    {
                        expectedResult.SetPixel(x, y, Color.FromArgb(191, 191, 191));
                    }
                    else
                    {
                        expectedResult.SetPixel(x, y, Color.FromArgb(212, 212, 212));
                    }
                }
            }

            Bitmap result = imageConverter.ConvertToBlurred(testImageBlurred);
            for (int x = 0; x < testImageBlurred.Width; x++)
            {
                for (int y = 0; y < testImageBlurred.Height; y++)
                {
                    Assert.AreEqual(expectedResult.GetPixel(x, y), result.GetPixel(x, y));
                }
            }
        }
    }
}