using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using Spotifree.Helper;
using Spotifree.Password;
using Spotifree.DAO;

namespace Spotifree
{
    public class User : User_Abstract
    {
        private Dictionary dicHelper;

        private Password_Cryptography cryptography;

        private DAO.User daoUser;

        public Dictionary DicHelper { get => dicHelper; set => dicHelper = value; }
        public Password_Cryptography Cryptography { get => cryptography; set => cryptography = value; }
        public User DaoUser { get => daoUser; set => daoUser = value; }

        private User dictionaryToModel(Dictionary<string, string> data)
        {
            User newUser = new User();
            newUser.Name = this.dicHelper.getString("name", data);
            newUser.Email = this.dicHelper.getString("email", data);
            newUser.Id = Int32.Parse(
                this.dicHelper.getString("id", data)
            );

            string password = this.dicHelper.getString("password", data);
            string passwordRepeat = this.dicHelper.getString("password_repeat", data);

            bool isEqual = (password == passwordRepeat);

            if (isEqual)
            {
                newUser.Password = this.cryptography.encode(password);
            }
            
            return newUser;
        }


        public bool register(Dictionary<string, string> data)
        {
            bool status = true;
            try
            {
                User newUser = this.dictionaryToModel(data);
                DateTime datetime = new DateTime();
                string date = datetime.ToString();

                this.DaoUser.load(newUser);
                int userId = newUser.Id;

                if (userId > 0)
                {
                    newUser.Modified = date;
                    this.DaoUser.update(newUser);

                    return status;
                }

                newUser.Created = date;
                this.DaoUser.insert(newUser);
            } 
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }


        public bool delete()
        {
            bool status = true;
            try
            {
                this.DaoUser.remove(this.Id);
            } 
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }
    }
}