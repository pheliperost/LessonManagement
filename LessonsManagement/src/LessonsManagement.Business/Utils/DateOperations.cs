﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace LessonsManagement.Business.Utils
{
    public static class DateOperations
    {
        public static DateTime ConvertDateStringToDateTime(string date)
        {

            CultureInfo ptBR = new CultureInfo("pt-BR");

            List<string> months = new List<string>();

            foreach (var item in ptBR.DateTimeFormat.MonthNames)
            {
                months.Add(item);
            }

            string[] dateSplit = date.Split(' ');

            var result = months.IndexOf(dateSplit[2].ToLower());

            DateTime dateConverted = new DateTime(
                                         Convert.ToInt32(dateSplit[4]),
                                         result + 1,
                                         Convert.ToInt32(dateSplit[0]));
            return dateConverted;
        }
    }
}
