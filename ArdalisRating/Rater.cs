namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly IRatingContext context;
        protected readonly ConsoleLogger logger;

        public Rater(IRatingContext context)
        {
            this.context = context;
            this.logger = context.Logger;
        }

        public abstract void Rate(Policy policy);
    }
}