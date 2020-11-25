using Newtonsoft.Json;

namespace SWDemo.Models.Common
{
    public partial class ReadingModes
    {
        [JsonProperty("text")]
        public bool Text { get; set; }

        [JsonProperty("image")]
        public bool Image { get; set; }
    }
}
