namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly IRatingContext context;
        public ILogger Logger {get; set;} = new ConsoleLogger();

        public Rater(IRatingContext context)
        {
            this.context = context;
        }

        public abstract void Rate(Policy policy);
    }
}