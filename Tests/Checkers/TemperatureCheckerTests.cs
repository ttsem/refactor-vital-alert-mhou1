using Xunit;
using checker.Checkers;

namespace checker.Tests.Checkers
{
    public class TemperatureCheckerTests
    {
        [Theory]
        [InlineData(95.0f, true)]   // Minimum boundary
        [InlineData(102.0f, true)]  // Maximum boundary
        [InlineData(98.6f, true)]   // Normal temperature
        [InlineData(94.9f, false)]  // Below minimum
        [InlineData(102.1f, false)] // Above maximum
        [InlineData(90.0f, false)]  // Well below range
        [InlineData(110.0f, false)] // Well above range
        public void CheckOk_ShouldReturnCorrectResult(float temperature, bool expected)
        {
            // Act
            var result = TemperatureChecker.CheckOk(temperature);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MinValue_ShouldBe95()
        {
            Assert.Equal(95f, TemperatureChecker.MinValue);
        }

        [Fact]
        public void MaxValue_ShouldBe102()
        {
            Assert.Equal(102f, TemperatureChecker.MaxValue);
        }
    }
}