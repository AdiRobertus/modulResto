using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace LKSN2018
{
    public static class Support
    {
        public static string employeeid;

        public static void Clstb(Control c)
        {
            foreach (Control a in c.Controls)
            {
                if (a is TextBox)
                    ((TextBox)a).Clear();
            }
        }

        public static string MD5Has(string input)
        {
            StringBuilder builder = new StringBuilder();
            SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
            byte[] result = sha512.ComputeHash(UTF8Encoding.UTF8.GetBytes(input));
            for(int i = 0; i < result.Length; i++)
            {
                builder.Append(result[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
