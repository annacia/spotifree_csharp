using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Spotifree.Password
{
    public class Password_Cryptography
    {
        private MD5 md5Hash;

        public MD5 Md5Hash { get => md5Hash; set => md5Hash = value; }

        public string encode(string input)
        {
            byte[] data = this.md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public bool compareString(string input, string hash)
        {
            string hashOfInput = this.encode(input);

            return this.compareHash(hashOfInput, hash);
        }

        public bool compareHash(string hash1, string hash2)
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