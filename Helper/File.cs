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
        private string type;
        private HttpRequest request;
        private string fullPath;

        public Directory Directory { get => directory; set => directory = value; }
        public string Path { get => path; set => path = value; }
        public HttpPostedFile PostedFile { get => postedFile; set => postedFile = value; }
        public string Type { get => type; set => type = value; }
        public HttpRequest Request { get => request; set => request = value; }
        public string FullPath { get => fullPath; set => fullPath = value; }

        public void ConfigurePath(string newName)
        {
            string extension = System.IO.Path.GetExtension(PostedFile.FileName);
            Path = newName + extension;
            FullPath = Directory.ServerPath + Directory.Path + Path;
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
                    string folder = Directory.CreateFolder();
                    FullPath = Directory.ServerPath + Directory.Path + Path;
                    PostedFile.SaveAs(folder + Path);
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

        public void FileValidate(string errorMessage)
        {
            if (Request.Files.Count < 1)
            {
                throw new Exception(errorMessage);
            }

            foreach (string file in Request.Files)
            {
                this.postedFile = Request.Files[file];

                if (postedFile.ContentType != Type)
                {
                    throw new Exception(errorMessage);
                }
            }

        }


    }
}