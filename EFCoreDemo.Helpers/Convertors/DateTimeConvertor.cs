﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EFCore.Helpers.Convertors
{
    public static class DateTimeConvertor
    {
        public static string ToPersianDate(this DateTime time)
        {
            var pc = new PersianCalendar();
            return pc.GetYear(time) + "/" + pc.GetMonth(time) + "/" + pc.GetDayOfMonth(time);
        }
    }
}
