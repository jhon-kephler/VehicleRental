using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VehicleRental.Application.Helper
{
    public class CnhHelper
    {
        public static bool ValidateCnh(string cnh)
        {
            var firstChar = cnh[0];
            if (cnh.Length == 11 && cnh != new string('1', 11))
            {
                var dsc = 0;
                var v = 0;
                for (int i = 0, j = 9; i < 9; i++, j--)
                {
                    v += (Convert.ToInt32(cnh[i].ToString()) * j);
                }

                var vl1 = v % 11;
                if (vl1 >= 10)
                {
                    vl1 = 0;
                    dsc = 2;
                }



                v = 0;
                for (int i = 0, j = 1; i < 9; ++i, ++j)
                {
                    v += (Convert.ToInt32(cnh[i].ToString()) * j);
                }

                var x = v % 11;
                var vl2 = (x >= 10) ? 0 : x - dsc;

                return vl1.ToString() + vl2.ToString() == cnh.Substring(cnh.Length - 2, 2);
            }

            return false;
        }

        public static bool ValidateTypeCnh(string cnh_Type)
        {
            cnh_Type = cnh_Type.Replace("Categoria", "").Replace("Tipo", "");

            var result = cnh_Type switch
            {
                "ACC" => true,
                "A"  => true,
                "AB" => true,
                "B"  => true,
                "C"  => true,
                "D"  => true,
                "E"  => true,
                _ => false
            };

            return result;
        }

        public static bool ValidateUrl(string cnh_Img_Url)
        {
            var urlRegex = new Regex(
                @"^(https?|ftps?):\/\/(?:[a-zA-Z0-9]" +
                        @"(?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}" +
                        @"(?::(?:0|[1-9]\d{0,3}|[1-5]\d{4}|6[0-4]\d{3}" +
                        @"|65[0-4]\d{2}|655[0-2]\d|6553[0-5]))?" +
                        @"(?:\/(?:[-a-zA-Z0-9@%_\+.~#?&=]+\/?)*)?$",
                RegexOptions.IgnoreCase);

            urlRegex.Matches(cnh_Img_Url);

            return urlRegex.IsMatch(cnh_Img_Url);
        }
    }
}
