using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Data.Mappings
{
    public static class DataBaseTypes
    {
        public static string Varchar(int length = 100)
        {
            if (length > 0)
            {
                return string.Format("varchar({0})", arg0: length.ToString());
            }
            else return Varchar(100);
        }

        public static string DateTime() => "datetime";
        public static string Decimal() => "decimal";
        public static string Int() => "int";
    }
}
