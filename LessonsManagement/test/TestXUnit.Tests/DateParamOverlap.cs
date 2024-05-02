using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestXUnitBusiness.Tests
{
    public class DateParamOverlap
    {
        public static IEnumerable<object[]> GetDatesOverlapping_Between_StartDate2_And_EndDate1()
        {
            yield return new object[]
            {
                new DateTime(2023, 09, 01, 14, 45, 0),
                new DateTime(2023, 09, 01, 15, 30, 0),
                new DateTime(2023, 09, 01, 14, 30, 0),
                new DateTime(2023, 09, 01, 15, 15, 0)
            };
        }
        public static IEnumerable<object[]> GetDatesOverlapping_Between_EndDate1_And_StartDate2()
        {
            yield return new object[]
            {
                new DateTime(2023, 09, 01, 14, 15, 0),
                new DateTime(2023, 09, 01, 15, 00, 0),
                new DateTime(2023, 09, 01, 14, 30, 0),
                new DateTime(2023, 09, 01, 15, 15, 0)
            };
        }
        public static IEnumerable<object[]> GetDatesNotOverlapping()
        {
            yield return new object[]
            {
                new DateTime(2023, 09, 01, 13, 30, 0),
                new DateTime(2023, 09, 01, 14, 15, 0),
                new DateTime(2023, 09, 01, 14, 30, 0),
                new DateTime(2023, 09, 01, 15, 15, 0)
            };
        }

        public static IEnumerable<object[]> GetDatesOverlapping_Between_EndDate2_And_StartDate1()
        {
            yield return new object[]
            {
                new DateTime(2023, 09, 01, 15, 30, 0),
                new DateTime(2023, 09, 01, 16, 15, 0),
                new DateTime(2023, 09, 01, 14, 30, 0),
                new DateTime(2023, 09, 01, 15, 15, 0)
            };
        }
    }
}
