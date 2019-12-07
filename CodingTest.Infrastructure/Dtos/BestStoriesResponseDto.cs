using System;
using Newtonsoft.Json;

namespace CodingTest.Infrastructure.Dtos
{
    public class BestStoriesResponseDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("postedBy")]
        public string PostedBy { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("commentCount")]
        public long CommentCount { get; set; }
    }
}