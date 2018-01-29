using System;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /search
    /// </summary>
    internal class SearchService : BaseHttpService<SearchResultData>
    {
        internal SearchService(string q, params SearchType[] types) : base(15, 0)
        {
            URL = "search";

            QueryString.Add("q", q);

            if (types != null && types.Length > 0)
            {
                QueryString.Add("type", string.Join(",", types));
            }
            else
            {
                QueryString.Add("type", string.Join(",", Enum.GetNames(typeof(SearchType))));
            }
        }
    }
}