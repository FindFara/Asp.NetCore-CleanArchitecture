﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.Utilities.Extension
{
    public  static class DataTimeExtension
    {

        public static string toshamsi(this DateTime dateTime)
        {
            PersianCalendar p = new PersianCalendar();
            return p.GetYear(dateTime).ToString("00") + "/" +
                    p.GetMonth(dateTime).ToString("00") + "/" +
                    p.GetDayOfMonth(dateTime).ToString("00");
        }
    }
}
