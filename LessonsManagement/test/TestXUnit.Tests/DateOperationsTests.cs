using LessonsManagement.Business.Utils;
using System;
using TestXUnitBusiness.Tests;
using Xunit;

namespace TestXUnit.Tests
{
    public class DateOperationsTests
    {
        [Theory(DisplayName = "Per�odo Sobrepoe Antes")]
        [Trait("Categoria", "DateOperations Trait Testes")]
        [MemberData(nameof(DateParamOverlap.GetDatesOverlapping_Between_StartDate2_And_EndDate1), MemberType = typeof(DateParamOverlap))]
        public void DateOperations_CheckIfPeriodOverlapsBefore_ShouldReturnTrue(DateTime dateStart1,
                                                                                DateTime dateEnd1,
                                                                                DateTime dateStart2,
                                                                                DateTime dateEnd2)
        { 
            
            var result = DateOperations.CheckIfDatesOverlaps(dateStart1, dateEnd1, dateStart2 ,dateEnd2);

            Assert.True(result);

        }

        [Theory(DisplayName = "Per�odo Sobrepoe Depois")]
        [Trait("Categoria", "DateOperations Trait Testes")]
        [MemberData(nameof(DateParamOverlap.GetDatesOverlapping_Between_EndDate1_And_StartDate2), MemberType = typeof(DateParamOverlap))]
        public void DateOperations_CheckIfPeriodOverlapsAfter_ShouldReturnTrue(DateTime dateStart1,
                                                                               DateTime dateEnd1,
                                                                               DateTime dateStart2,
                                                                               DateTime dateEnd2)
        { 

            var result = DateOperations.CheckIfDatesOverlaps(dateStart1, dateEnd1, dateStart2, dateEnd2);

            Assert.True(result);

        }

        [Theory(DisplayName = "Per�odo N�o Sobrepoe Antes")]
        [Trait("Categoria", "DateOperations Trait Testes")]
        [MemberData(nameof(DateParamOverlap.GetDatesNotOverlapping), MemberType = typeof(DateParamOverlap))]
        public void DateOperations_CheckIfPeriodOverlapsBefore_ShouldReturnFalse(DateTime dateStart1,
                                                                                 DateTime dateEnd1,
                                                                                 DateTime dateStart2,
                                                                                 DateTime dateEnd2)
        {

            var result = DateOperations.CheckIfDatesOverlaps(dateStart1, dateEnd1, dateStart2, dateEnd2);

            Assert.False(result);

        }


        [Theory(DisplayName = "Per�odo N�o Sobrepoe Depois")]
        [Trait("Categoria", "DateOperations Trait Testes")]
        [MemberData(nameof(DateParamOverlap.GetDatesOverlapping_Between_EndDate2_And_StartDate1), MemberType = typeof(DateParamOverlap))]
        public void DateOperations_CheckIfPeriodOverlapsAfter_ShouldReturnFalse(DateTime dateStart1,
                                                                                DateTime dateEnd1,
                                                                                DateTime dateStart2,
                                                                                DateTime dateEnd2)
        {

            var result = DateOperations.CheckIfDatesOverlaps(dateStart1, dateEnd1, dateStart2, dateEnd2);

            Assert.False(result);

        }
    }
}
