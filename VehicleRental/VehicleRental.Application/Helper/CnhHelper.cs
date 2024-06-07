using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
