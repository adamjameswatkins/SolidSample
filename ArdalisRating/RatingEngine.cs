namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger logger;

        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }
        
        public RatingEngine(ILogger logger)
        {
            Context.Engine = this;
            this.logger = logger;
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
