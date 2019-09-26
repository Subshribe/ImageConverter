using ImageClassLibrary;
using System;
using System.Drawing;
using System.IO;


namespace Image
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler importImage = new FileHandler();
            Bitmap image = null;
            ImageConverter imageConverter = new ImageConverter();
            string filePath = null;
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Select an image to convert");
                    filePath = Console.ReadLine();
                }
                else
                {
                    filePath = args[0];
                }
                if (importImage.TryIfFilePathIsAnImage(filePath))
                {
                    image = new Bitmap(filePath);
                }
                else
                {
                    while(!importImage.TryIfFilePathIsAnImage(filePath))
                    {
                        Console.WriteLine("Select an image to convert!");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File dont exist, try again");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong input");
                Environment.Exit(0);
            }

            Bitmap negativeImage = imageConverter.ConvertToNegative(image);
            var negativeFileName = importImage.AddSuffixToFile(filePath, "Negative");
            negativeImage.Save(negativeFileName);
            negativeImage.Dispose();

            var blackWhiteImage = imageConverter.ConvertToBlackAndWhite(image);
            var blackAndWhiteFileName = importImage.AddSuffixToFile(filePath, "BlackAndWhite");
            blackWhiteImage.Save(blackAndWhiteFileName);
            blackWhiteImage.Dispose();

            var blurredImage = imageConverter.ConvertToBlurred(image);
            var blurredFileName = importImage.AddSuffixToFile(filePath, "Blurred");
            blurredImage.Save(blurredFileName);
            blurredImage.Dispose();

            image.Dispose();

        }
    }
}

