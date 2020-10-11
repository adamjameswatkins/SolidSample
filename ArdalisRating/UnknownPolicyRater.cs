using System;

namespace ArdalisRating
{
    public class UnknownPolicyRater : Rater
    {
        private readonly RatingEngine engine;
        private readonly ConsoleLogger logger;

        public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public override void Rate(Policy policy)
        {
            this.logger.Log("Unknown Policy type.");
        }
    }
}