using Newtonsoft.Json;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Image format.
    /// </summary>
    public class ImageData
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}