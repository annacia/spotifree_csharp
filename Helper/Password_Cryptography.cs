using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Spotifree.Helper
{
    public class Password_Cryptography
    {
        private MD5 md5Hash;

        public MD5 Md5Hash { get => md5Hash; set => md5Hash = value; }

        public Password_Cryptography()
        {
            Md5Hash = MD5.Create();
        }

        public string Encode(string input)
        {
            byte[] hash = Encoding.UTF8.GetBytes(input);
            byte[] data = Md5Hash.ComputeHash(hash);

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public bool CompareString(string input, string hash)
        {
            string hashOfInput = this.Encode(input);

            return this.CompareHash(hashOfInput, hash);
        }

        public bool CompareHash(string hash1, string hash2)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hash1, hash2))
            {
                return true;
            }

            return false;
        }
    }
}