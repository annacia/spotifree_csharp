using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.Helper
{
    public class Directory
    {
        private string path;

        public string Path { get => path; set => path = value; }

        public void CreateFolder()
        {
            System.IO.Directory.CreateDirectory(Path);
        }

        public void ConfigureFolder(string localFolder, string folder)
        {
            Path = System.IO.Path.Combine(localFolder, folder);
        }

        public void Delete()
        {
            if (System.IO.Directory.Exists(Path))
            {
                try
                {
                    System.IO.Directory.Delete(Path, true);
                }

                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public string[] GetFiles()
        {
            return System.IO.Directory.GetFiles(Path);
        }
    }
}