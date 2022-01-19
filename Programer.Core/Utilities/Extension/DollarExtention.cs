using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.Utilities.Extension
{
    public static class DollarExtention
    {
        public static string ToDollar (this int price)
        {
            return $"{price:#,# $}";
        }
    }
}
