using Newtonsoft.Json;

namespace SWDemo.Models.Common
{
    public partial class IndustryIdentifier
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
}
