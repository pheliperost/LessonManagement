using LessonsManagement.Business.Utils;
using System;
using Xunit;

namespace TestXUnit.Tests
{
    public class DateOperationsTests
    {
        [Fact]
        public void DateOperations_ConvertDateStringToDateTime() 
        {
            DateTime dateStart1 = new DateTime(2023, 09, 01, 14, 45, 0);
            DateTime dateEnd1 = new DateTime(2023, 09, 01, 15, 30, 0);
            DateTime dateStart2 = new DateTime(2023, 09, 01, 14, 30, 0);
            DateTime dateEnd2 = new DateTime(2023, 09, 01, 15, 15, 0);
            
            var result = DateOperations.CheckIfDatesOverlapps(dateStart1, dateEnd1, dateStart2 ,dateEnd2);

            Assert.True(result);


        }
    }
}
