using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        private readonly ILogger logger;

        public RaterFactory(ILogger logger)
        {
            this.logger = logger;
        }

        public Rater Create(Policy policy)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                    new object[] { this.logger }
                );
            }
            catch
            {
                return new UnknownPolicyRater(this.logger);
            }
        }
    }
}