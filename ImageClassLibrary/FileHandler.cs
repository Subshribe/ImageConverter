using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ImageClassLibrary
{
    public class FileHandler
    {
        public bool TryIfFilePathIsAnImage(string filePath)
        {
            filePath = Path.GetExtension(filePath);
            switch (filePath)
            {
                case ".jpg":
                    return true;
                case ".jfif":
                    return true;
                case ".png":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }
        public string AddSuffixToFile(string filePath, string suffix)
        {
            string newFileName = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filePath) + "_" + suffix + Path.GetExtension(filePath);
            return newFileName;
        }

    }

}
