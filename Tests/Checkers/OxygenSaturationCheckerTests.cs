using Xunit;
using checker.Checkers;

namespace checker.Tests.Checkers
{
    public class OxygenSaturationCheckerTests
    {
        [Theory]
        [InlineData(90, true)]   // Minimum boundary
        [InlineData(95, true)]   // Normal value
        [InlineData(100, true)]  // High normal value
        [InlineData(105, true)]  // Above 100%
        [InlineData(89, false)]  // Below minimum
        [InlineData(85, false)]  // Well below minimum
        [InlineData(50, false)]  // Critically low
        public void CheckOk_ShouldReturnCorrectResult(int oxygenSaturation, bool expected)
        {
            // Act
            var result = OxygenSaturationChecker.CheckOk(oxygenSaturation);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MinValue_ShouldBe90()
        {
            Assert.Equal(90, OxygenSaturationChecker.MinValue);
        }
    }
}