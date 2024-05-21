using LessonsManagement.Business.Utils;
using System;
using TestXUnitBusiness.Tests;
using Xunit;

namespace TestXUnit.Tests
{
    public class DateOperationsTests
    {
        [Theory(DisplayName = "Período Sobrepoe Antes")]
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

        [Theory(DisplayName = "Período Sobrepoe Depois")]
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

        [Theory(DisplayName = "Período Não Sobrepoe Antes")]
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


        [Theory(DisplayName = "Período Não Sobrepoe Depois")]
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

        [Theory(DisplayName = "Successful Convert DateTime String to Date")]
        [Trait("Categoria", "ConvertDateStringToDateTime Traits Tests")]
        [InlineData("09 de Janeiro de 2024")]
        [InlineData("26 de Janeiro de 2024")]
        [InlineData("28 de Fevereiro de 2024")]
        public void ConvertDateStringToDateTime_SendAValidDateTimeStringFormat_ShouldReturnADateTimeValue(String dateTimeP)
        {
            var result = DateOperations.ConvertDateStringToDateTime(dateTimeP);
            Assert.IsType<DateTime>(result);

        }

        [Theory(DisplayName = "Unsuccessful Convert DateTime String Format to Date")]
        [Trait("Categoria", "ConvertDateStringToDateTime Traits Tests")]
        [InlineData("31 de Fevereiro de 2024")]
        [InlineData("00 de Janeiro de 2024")]
        [InlineData("33 de dezembro de 2024")]
        [InlineData("33 de dezembro de 0000")]
        public void ConvertDateStringToDateTime_SendAInvalidDateTimeStringFormat_ShouldReturnADateTimeValue(String dateTimeP)
        {
            var exception =
            Assert.Throws<ArgumentOutOfRangeException>(() => DateOperations.ConvertDateStringToDateTime(dateTimeP));

            Assert.Equal("Year, Month, and Day parameters describe an un-representable DateTime.", exception.Message);

        }

        [Theory(DisplayName = "Unsuccessful Convert DateTime String Format to Date")]
        [Trait("Categoria", "ConvertDateStringToDateTime Traits Tests")]
        [InlineData("26/01/2024")]
        [InlineData("01/01/2024")]
        [InlineData("01/30/2024")]
        [InlineData("2024/01/01")]
        public void ConvertDateStringToDateTime_SendAInvalidDateTimeStringFormat_ShouldReturnAException(String dateTimeP)
        {
            var exception =
            Assert.Throws<IndexOutOfRangeException>(() => DateOperations.ConvertDateStringToDateTime(dateTimeP));

            Assert.Equal("Index was outside the bounds of the array.", exception.Message);

        }
    }
}
