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
        private readonly IPolicySerializer policySerializer;
        private readonly RaterFactory raterFactory;

        public IRatingContext Context { get; set; }
        public decimal Rating { get; set; }
        
        public RatingEngine(ILogger logger, IPolicySource policySource, IPolicySerializer policySerializer, RaterFactory raterFactory)
        {
            this.logger = logger;
            this.policySource = policySource;
            this.policySerializer = policySerializer;
            this.raterFactory = raterFactory;
            this.Context = new DefaultRatingContext(this.policySource, this.policySerializer);
            Context.Engine = this;
        }

        public void Rate()
        {
            this.logger.Log("Starting rate.");

            this.logger.Log("Loading policy.");

            string policyString = Context.LoadPolicyFromFile();

            var policy = this.policySerializer.GetPolicyFromString(policyString);

            var rater = this.raterFactory.Create(policy);

            this.Rating = rater.Rate(policy);

            this.logger.Log("Rating completed.");
        }
    }
}
