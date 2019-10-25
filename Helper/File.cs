using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.Helper
{
    public class File
    {
        private Directory directory;
        private string path;
        private HttpPostedFile postedFile;

        public Directory Directory { get => directory; set => directory = value; }
        public string Path { get => path; set => path = value; }
        public HttpPostedFile PostedFile { get => postedFile; set => postedFile = value; }

        public void ConfigurePath(string newName, string extension)
        {
            Path = Directory.Path + newName + "." + extension;
        }

        public File()
        {
            Directory = new Directory();
        }

        public void Upload()
        {
            try 
            {
                if (PostedFile != null && PostedFile.ContentLength > 0)
                {
                    PostedFile.SaveAs(Path);
                }
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
            }
        }

        public void Delete()
        {
            if (System.IO.File.Exists(Path))
            {
                try
                {
                    System.IO.File.Delete(Path);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }


    }
}