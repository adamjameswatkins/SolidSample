namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger logger;
        private readonly IPolicySource policySource;

        public IRatingContext Context { get; set; }
        public decimal Rating { get; set; }
        
        public RatingEngine(ILogger logger, IPolicySource policySource)
        {
            this.logger = logger;
            this.policySource = policySource;
            this.Context = new DefaultRatingContext(this.policySource);
            Context.Engine = this;
        }

        public void Rate()
        {
            this.logger.Log("Starting rate.");

            this.logger.Log("Loading policy.");

            string policyJson = Context.LoadPolicyFromFile();

            var policy = Context.GetPolicyFromJsonString(policyJson);

            var rater = Context.CreateRaterForPolicy(policy, Context);

            rater.Rate(policy);

            this.logger.Log("Rating completed.");
        }
    }
}
