using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        private RatingEngine engine;
        private FakeLogger logger;
        private FakePolicySource policySource;
        private JsonPolicySerializer policySerializer;
        private RaterFactory raterFactory;

        public RatingEngineRate()
        {
            this.logger = new FakeLogger();
            this.policySource = new FakePolicySource();
            this.policySerializer = new JsonPolicySerializer();
            this.raterFactory = new RaterFactory(this.logger);
            this.engine = new RatingEngine(this.logger, this.policySource, this.policySerializer, this.raterFactory);
        }

        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = "Land",
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = JsonConvert.SerializeObject(policy);
            this.policySource.PolicyString = json;

            this.engine.Rate();
            var result = engine.Rating;

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                //Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            this.policySource.PolicyString = json;

            this.engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }

        [Fact]
        public void LogsStartingLoadAndCompleting()
        {
            var policy = new Policy
            {
                Type = "Land",
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            this.policySource.PolicyString = json;

            this.engine.Rate();
            var result = engine.Rating;

            Assert.Contains(logger.LoggedMessages, m => m == "Starting rate.");
            Assert.Contains(logger.LoggedMessages, m => m == "Loading policy.");
            Assert.Contains(logger.LoggedMessages, m => m == "Rating completed.");
        }
    }
}
