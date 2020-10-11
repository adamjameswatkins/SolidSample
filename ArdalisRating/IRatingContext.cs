namespace ArdalisRating
{
    public interface IRatingUpdater
    {
        void UpdateRating(decimal rating);
    }

    public interface IRatingContext : ILogger
    {
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        Policy GetPolicyFromJsonString(string policyJson);
        Policy GetPolicyFromXmlString(string policyXml);
        RatingEngine Engine { get; set; }
    }
}
