using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Helper
{
    public class BrandHelper
    {
        public static string FormatName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            if(name.Contains("bmw"))
                return name.ToUpper();

            string[] words = name.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            return string.Join(" ", words);
        }
    }
}
