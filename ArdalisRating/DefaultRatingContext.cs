using System;

namespace ArdalisRating
{
    public class DefaultRatingContext : IRatingContext
    {
        public RatingEngine Engine { get; set; }

        private readonly IPolicySource policySource;
        private readonly IPolicySerializer policySerializer;

        public DefaultRatingContext(IPolicySource policySource, IPolicySerializer policySerializer)
        {
            this.policySource = policySource;
            this.policySerializer = policySerializer;
        }

        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return this.policySerializer.GetPolicyFromString(policyJson);
        }

        public Policy GetPolicyFromXmlString(string policyXml)
        {
            throw new NotImplementedException();
        }

        public string LoadPolicyFromFile()
        {
            return this.policySource.GetPolicyFromSource();
        }

        public string LoadPolicyFromURI(string uri)
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {
            new ConsoleLogger().Log(message);
        }

        public void UpdateRating(decimal rating)
        {
            Engine.Rating = rating;
        }
    }
}
