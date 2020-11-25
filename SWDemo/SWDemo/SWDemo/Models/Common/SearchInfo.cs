using Newtonsoft.Json;

namespace SWDemo.Models.Common
{
    public partial class SearchInfo
    {
        [JsonProperty("textSnippet")]
        public string TextSnippet { get; set; }
    }
}
