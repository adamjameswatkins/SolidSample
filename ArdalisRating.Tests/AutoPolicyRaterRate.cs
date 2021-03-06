using System.Linq;
using Xunit;

namespace ArdalisRating.Tests
{

    public class AutoPolicyRaterRate
    {
        [Fact]
        public void LogsMakeRequiredMessageGivenPolicyWithoutMake()
        {
            //Given
            var policy = new Policy() { Type = "Auto" };
            var logger = new FakeLogger();
            var rater = new AutoPolicyRater(null);
            rater.Logger = logger;

            //When
            rater.Rate(policy);

            //Then
            Assert.Equal("Auto policy must specify Make", logger.LoggedMessages.Last());
        }

        [Fact]
        public void SetsRatingTo1000ForBMWWith250Deductible()
        {
            //Given
            var policy = new Policy()
            {
                Type = "Auto",
                Make = "BMW",
                Deductible = 250m
            };
            var logger = new FakeLogger();
            var rater = new AutoPolicyRater(logger);

            //When
            var result = rater.Rate(policy);

            //Then
            Assert.Equal(1000m, result);
        }
    }
}