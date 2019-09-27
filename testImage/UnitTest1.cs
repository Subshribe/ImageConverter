using NUnit.Framework;
using System.Drawing;
using ImageClassLibrary;


namespace testImageConverter // Stor bokstav på namespace
{
    public class TestImageConverter
    {

        ImageConverter imageConverter = new ImageConverter();
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
            string 
        }
    }
}