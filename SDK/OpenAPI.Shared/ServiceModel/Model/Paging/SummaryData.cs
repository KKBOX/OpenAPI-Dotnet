using Newtonsoft.Json;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Summary metadata.
    /// </summary>
    public class SummaryData
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}