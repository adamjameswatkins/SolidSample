using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();
        
        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource();

            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    var autoPolicyRater = new AutoPolicyRater(this, this.Logger);
                    autoPolicyRater.Rate(policy);
                    break;

                case PolicyType.Land:
                    var landPolicyRater = new LandPolicyRater(this, this.Logger);
                    landPolicyRater.Rate(policy);
                    break;

                case PolicyType.Life:
                    var lifePolicyRater = new LifePolicyRater(this, this.Logger);
                    lifePolicyRater.Rate(policy);
                    break;

                default:
                    Logger.Log("Unknown policy type");
                    break;
            }

            Logger.Log("Rating completed.");
        }
    }
}
