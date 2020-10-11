using System;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(IRatingContext context)
            : base(context)
        {
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
                    this.context.UpdateRating(900m);
                }
                this.context.UpdateRating(900m);
            }
        }
    }
}