namespace ArdalisRating
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(IRatingContext context)
            :base(context)
        {
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
            this.context.UpdateRating(policy.BondAmount * 0.05m);
        }
    }
}