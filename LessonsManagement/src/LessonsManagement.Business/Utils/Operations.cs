using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Business.Utils
{
    public static class Operations
    {
        public static bool VerifyIfIntValue(string item)
        {
            Int32 outInt;
            bool resultConvertInt = Int32.TryParse(item, out outInt);
            return resultConvertInt;
        }

        public static bool VerifyIfValidTimeFormat(string input)
        {
            TimeSpan dummyOutput;
            return TimeSpan.TryParse(input, out dummyOutput);
        }
    }
}
