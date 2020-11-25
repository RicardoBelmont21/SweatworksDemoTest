using Newtonsoft.Json;

namespace SWDemo.Models.Common
{
    public partial class Epub
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
    }
}
