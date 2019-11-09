using Spotifree.DAO;
using Spotifree.Helper;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.Mapper
{
    public class Mapper_User:Mapper_Abstract, Mapper_Interface
    {
        private Password_Cryptography cryptography;

        public Mapper_User()
        {
            Cryptography = new Password_Cryptography();
            Dao = new DAO_User();
            Model = new User();
        }

        public Password_Cryptography Cryptography { get => cryptography; set => cryptography = value; }

        public override void DictionaryToModel(Dictionary<string, string> data)
        {
            User newUser = new User();
            newUser.Name = this.DicHelper.GetString("name", data);
            newUser.Email = this.DicHelper.GetString("email", data);

            string id = this.DicHelper.GetString("id", data);

            if (id != "")
            {
                newUser.Id = Int32.Parse(id);
            }

            string password = this.DicHelper.GetString("password", data);
            string passwordRepeat = this.DicHelper.GetString("password_repeat", data);

            newUser = this.ChangePassword(newUser, password, passwordRepeat);

            this.Model = newUser;
        }

        public bool Register()
        {
            bool status = true;
            try
            {
                User user = Model as User;
                user.Created = DateTime.Today;
                Dao.Insert(user);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        public bool Update()
        {
            bool status = true;
            try
            {
                User user = Model as User;
                User userUpdate = Dao.SearchById(user.Id) as User;
                
                userUpdate.Modified = DateTime.Today;
                userUpdate.Email = user.Email;
                userUpdate.Name = user.Name;
                userUpdate.Password = user.Password;

                Dao.Update(userUpdate);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        public User ChangePassword(User user, string password, string passwordRepeat)
        {
            password = this.Cryptography.Encode(password);
            passwordRepeat = this.Cryptography.Encode(passwordRepeat);

            bool isEqual = this.Cryptography.CompareHash(password, passwordRepeat);

            if (isEqual)
            {
                user.Password = this.Cryptography.Encode(password);
            }

            return user;
        }

        public Model_Abstract Load(int id)
        {
            return Dao.SearchById(id) as User;
        }

        public void SetModelById(int id)
        {
            this.Model = this.Load(id);
        }

        public void validate(User usuario)
        {
            if (string.IsNullOrEmpty(usuario.Name) || (usuario.Name.Length == 0))
            {
                throw new Exception("Nome é obrigatório");
            }

            if (usuario.Email.Length == 0)
            {
                throw new Exception("email é obrigatório");
            }
        }

    }
}