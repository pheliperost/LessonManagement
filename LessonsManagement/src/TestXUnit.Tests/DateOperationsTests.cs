using LessonsManagement.Business.Utils;
using System;
using Xunit;

namespace TestXUnit.Tests
{
    public class DateOperationsTests
    {
        [Fact(DisplayName = "Período Sobrepoe Antes")]
        [Trait("Categoria", "DateOperations Trait Testes")]
        public void DateOperations_CheckIfPeriodOverlapsBefore_ShouldReturnTrue() 
        {
            DateTime dateStart1 = new DateTime(2023, 09, 01, 14, 45, 0);
            DateTime dateEnd1 = new DateTime(2023, 09, 01, 15, 30, 0);
            DateTime dateStart2 = new DateTime(2023, 09, 01, 14, 30, 0);
            DateTime dateEnd2 = new DateTime(2023, 09, 01, 15, 15, 0);
            
            var result = DateOperations.CheckIfDatesOverlaps(dateStart1, dateEnd1, dateStart2 ,dateEnd2);

            Assert.True(result);

        }

        [Fact(DisplayName = "Período Sobrepoe Depois")]
        [Trait("Categoria", "DateOperations Trait Testes")]
        public void DateOperations_CheckIfPeriodOverlapsAfter_ShouldReturnTrue()
        {
            DateTime dateStart1 = new DateTime(2023, 09, 01, 14, 15, 0);
            DateTime dateEnd1 = new DateTime(2023, 09, 01, 15, 00, 0);
            DateTime dateStart2 = new DateTime(2023, 09, 01, 14, 30, 0);
            DateTime dateEnd2 = new DateTime(2023, 09, 01, 15, 15, 0);

            var result = DateOperations.CheckIfDatesOverlaps(dateStart1, dateEnd1, dateStart2, dateEnd2);

            Assert.True(result);

        }

        [Fact(DisplayName = "Período Não Sobrepoe Antes")]
        [Trait("Categoria", "DateOperations Trait Testes")]
        public void DateOperations_CheckIfPeriodOverlapsBefore_ShouldReturnFalse()
        {
            DateTime dateStart1 = new DateTime(2023, 09, 01, 13, 30, 0);
            DateTime dateEnd1 = new DateTime(2023, 09, 01, 14, 15, 0);
            DateTime dateStart2 = new DateTime(2023, 09, 01, 14, 30, 0);
            DateTime dateEnd2 = new DateTime(2023, 09, 01, 15, 15, 0);

            var result = DateOperations.CheckIfDatesOverlaps(dateStart1, dateEnd1, dateStart2, dateEnd2);

            Assert.False(result);

        }


        [Fact(DisplayName = "Período Não Sobrepoe Depois")]
        [Trait("Categoria", "DateOperations Trait Testes")]
        public void DateOperations_CheckIfPeriodOverlapsAfter_ShouldReturnFalse()
        {
            DateTime dateStart1 = new DateTime(2023, 09, 01, 15, 30, 0);
            DateTime dateEnd1 = new DateTime(2023, 09, 01, 16, 15, 0);
            DateTime dateStart2 = new DateTime(2023, 09, 01, 14, 30, 0);
            DateTime dateEnd2 = new DateTime(2023, 09, 01, 15, 15, 0);

            var result = DateOperations.CheckIfDatesOverlaps(dateStart1, dateEnd1, dateStart2, dateEnd2);

            Assert.False(result);

        }
    }
}
