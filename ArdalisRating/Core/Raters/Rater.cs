namespace ArdalisRating
{
    public abstract class Rater
    {
        public ILogger Logger {get; set;}

        public Rater(ILogger logger)
        {
            this.Logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}