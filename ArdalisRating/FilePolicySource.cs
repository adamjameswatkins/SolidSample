using System.IO;

namespace ArdalisRating
{
    public interface IPolicySource
    {
        string GetPolicyFromSource();
    }

    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}