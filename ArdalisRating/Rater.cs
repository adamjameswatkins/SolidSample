namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly IRatingUpdater ratingUpdater;
        public ILogger Logger {get; set;} = new ConsoleLogger();

        public Rater(IRatingUpdater ratingUpdater)
        {
            this.ratingUpdater = ratingUpdater;
        }

        public abstract void Rate(Policy policy);
    }
}