using Xunit;
using checker.Checkers;

namespace checker.Tests.Checkers
{
    public class PulseRateCheckerTests
    {
        [Theory]
        [InlineData(60, true)]   // Minimum boundary
        [InlineData(100, true)]  // Maximum boundary
        [InlineData(75, true)]   // Normal pulse rate
        [InlineData(59, false)]  // Below minimum
        [InlineData(101, false)] // Above maximum
        [InlineData(30, false)]  // Well below range
        [InlineData(150, false)] // Well above range
        public void CheckOk_ShouldReturnCorrectResult(int pulseRate, bool expected)
        {
            // Act
            var result = PulseRateChecker.CheckOk(pulseRate);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MinValue_ShouldBe60()
        {
            Assert.Equal(60, PulseRateChecker.MinValue);
        }

        [Fact]
        public void MaxValue_ShouldBe100()
        {
            Assert.Equal(100, PulseRateChecker.MaxValue);
        }
    }
}