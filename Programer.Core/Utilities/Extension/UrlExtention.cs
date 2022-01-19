using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.Utilities.Extension
{
    public static class UrlExtention
    { 
        public static string FixedUrl (this string url)
        {
            return url.Trim().ToLower().Replace(' ', '-');
        }
    }
}
