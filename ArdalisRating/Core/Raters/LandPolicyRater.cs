namespace ArdalisRating
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(ILogger logger)
            :base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            this.Logger.Log("Rating LAND policy...");
            this.Logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                this.Logger.Log("Land policy must specify Bond Amount and Valuation.");
                return 0m;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                this.Logger.Log("Insufficient bond amount.");
                return 0m;
            }
            return policy.BondAmount * 0.05m;
        }
    }
}