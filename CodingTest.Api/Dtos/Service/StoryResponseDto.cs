using Newtonsoft.Json;

namespace CodingTest.Api.Dtos.Service
{
    public class StoryResponseDto
    {
        [JsonProperty("by")]
        public string By { get; set; }

        [JsonProperty("descendants")]
        public long Descendants { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("kids")]
        public long[] Kids { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}