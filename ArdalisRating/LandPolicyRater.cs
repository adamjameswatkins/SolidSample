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
            this.Logger.Log("Rating LAND policy...");
            this.Logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                this.Logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                this.Logger.Log("Insufficient bond amount.");
                return;
            }
            this.ratingUpdater.UpdateRating(policy.BondAmount * 0.05m);
        }
    }
}