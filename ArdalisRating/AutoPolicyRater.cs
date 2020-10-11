using System;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        private readonly RatingEngine engine;
        private readonly ConsoleLogger logger;

        public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public override void Rate(Policy policy)
        {
            this.logger.Log("Rating AUTO policy...");
            this.logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                this.logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    this.engine.Rating = 1000m;
                }
                this.engine.Rating = 900m;
            }
        }
    }
}