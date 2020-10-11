using System;

namespace ArdalisRating
{
    public class LandPolicyRater : Rater
    {
        private readonly RatingEngine engine;
        private readonly ConsoleLogger logger;

        public LandPolicyRater(RatingEngine engine, ConsoleLogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public override void Rate(Policy policy)
        {
            this.logger.Log("Rating LAND policy...");
            this.logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                this.logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                this.logger.Log("Insufficient bond amount.");
                return;
            }
            this.engine.Rating = policy.BondAmount * 0.05m;
        }
    }
}