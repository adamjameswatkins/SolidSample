using System;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(ILogger logger)
            : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            this.Logger.Log("Rating AUTO policy...");
            this.Logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                this.Logger.Log("Auto policy must specify Make");
                return 0m;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    return 1000m;
                }
                return 900m;
            }
                return 0m;
        }
    }
}