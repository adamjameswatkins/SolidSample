namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly IRatingUpdater ratingUpdater;
        public ILogger Logger {get; set;} = new ConsoleLogger();

        public Rater(IRatingContext context)
        {
            this.ratingUpdater = context;
        }

        public abstract void Rate(Policy policy);
    }
}