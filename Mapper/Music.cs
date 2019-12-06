using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spotifree.DAO;
using Spotifree.Helper;
using Spotifree.Models;

namespace Spotifree.Mapper
{

    public class Mapper_Music : Mapper_Abstract, Mapper_Interface
    {
        private File music;

        public File Music { get => music; set => music = value; }
        public Mapper_Music()
        {
            Dao = new DAO_Music();
            Model = new Music();
        }

        public override void DictionaryToModel(Dictionary<string, string> data)
        {
            Mapper_User userMapper = new Mapper_User();
            Mapper_Category categoryMapper = new Mapper_Category();

            Music newMusic = new Music();
            newMusic.Name = this.DicHelper.GetString("name", data);
            newMusic.Dir_art = this.DicHelper.GetString("dir_art", data);
            newMusic.Dir_music = this.DicHelper.GetString("dir_music", data);
            
            string id_user = this.DicHelper.GetString("id_user", data);
            newMusic.User = userMapper.Load(Int32.Parse(id_user)) as User;
            
            string id_category = this.DicHelper.GetString("id_category", data);
            newMusic.Category = categoryMapper.Load(Int32.Parse(id_category)) as Category;

            string id = this.DicHelper.GetString("id", data);

            if (id != "")
            {
                newMusic.Id = Int32.Parse(id);
            }

            this.Model = newMusic;
        }

        public void UploadMusic(File file, Directory directory)
        {
            directory.CreateFolder();
            file.Upload();
        }

        public Model_Abstract Load(int id)
        {
            return Dao.SearchById(id) as Music;
        }

        public Music FetchOne(int id)
        {
            DAO_Music dao = new DAO_Music();

            return dao.FetchOneById(id);
        }

        public IList<Music> getByName(string name)
        {
            DAO_Music dao = new DAO_Music();

            return dao.FetchByName(name);
        }

        public bool Register()
        {
            bool status = true;
            try
            {
                Music music = Model as Music;
                music.Created = DateTime.Now;
                Dao.Insert(music);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        public void SetModelById(int id)
        {
            this.Model = this.Load(id);
        }

        public bool Update()
        {
            bool status = true;
            try
            {
                Music music = Model as Music;
                Music musicUpdate = Dao.SearchById(music.Id) as Music;

                musicUpdate.Modified = DateTime.Now;
                musicUpdate.Name = music.Name;
                Model = musicUpdate;

                Dao.Update(musicUpdate);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        public void Validate(Music musica)
        {
            if(musica.User == null || musica.Category == null) {
                throw new Exception("Ocorreu um erro ao executar a operação");
            }

            if(string.IsNullOrEmpty(musica.Name)) {
                throw new Exception("nome da musica deve ser informado");
            }
        }
    }
}