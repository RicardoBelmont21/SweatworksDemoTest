using Newtonsoft.Json;

namespace SWDemo.Models.Response.Books
{
    public class GetBooksResponse : ResponseBaseModel
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
}
