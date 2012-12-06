using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesktopUI
{
    class Model
    {
        private static Model instance;
        public static Model GetInstance()
        {
            if (instance == null)
            {
                instance = new Model();
            }
            return instance;
        }

        internal void CreateDocument(string file)
        {
            System.IO.File.WriteAllText(file,"");
        }

        internal void CreateFolder(string folder)
        {
            System.IO.Directory.CreateDirectory(folder);
        }


        internal string ReadFile(string currentPath)
        {
            StreamReader streamReader = new StreamReader(currentPath);
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            return text;
        }

        internal void SaveFile(string currentPath, string text)
        {
            //deletes all existing text and writes the new text
            File.WriteAllText(currentPath,text);
        }

        internal void DeleteFile(string file)
        {
            File.Delete(file);
        }

        internal void DeleteFolder(DirectoryInfo CurrentDirectoryInfo)
        {
            Directory.Delete(CurrentDirectoryInfo.FullName, true);
        }

        internal void Synchronize(string username, string password)
        {
            
        }
    }
}
