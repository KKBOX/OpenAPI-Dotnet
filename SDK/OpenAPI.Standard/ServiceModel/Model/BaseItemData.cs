using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// BaseItem collection with offset data.
    /// </summary>
    public class BaseItemOffsetData : OffsetData<List<BaseItemData>>
    {

    }

    public class BaseItemData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("images")]
        public List<ImageData> Images { get; set; }
    }
}
