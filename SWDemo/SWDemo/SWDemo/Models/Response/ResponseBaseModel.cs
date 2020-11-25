using Newtonsoft.Json;

namespace SWDemo.Models.Response
{
    public class ResponseBaseModel
    {
        [JsonProperty("kind")]
        string Kind { get; set; }

        [JsonProperty("totalItems")]
        long totalItems { get; set; }

        public bool Success { get; set; } = false;
    }
}
