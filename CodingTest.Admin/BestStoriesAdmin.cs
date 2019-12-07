using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingTest.Infrastructure.Dtos;
using CodingTest.Infrastructure.Dtos.Service;
using CodingTest.Infrastructure.Helpers;
using Microsoft.Extensions.Options;

namespace CodingTest.Admin
{
    public class BestStoriesAdmin : IBestStoriesAdmin
    {
        private readonly Appsettings _config;
        public BestStoriesAdmin(IOptions<Appsettings> config)
        {
            _config = config.Value;
        }
        private Task<List<long>> GetBestStoriesIdsAsync()
        {
            return HttpHelper<List<long>>.Get(_config.BestStoriesUrl);
        }

        private Task<StoryResponseDto> GetStoryAsync(long id)
        {
            return HttpHelper<StoryResponseDto>.Get($"{_config.SingleStoryUrl}{id}.json");
        }

        public async Task<List<BestStoriesResponseDto>> GetTop20Async() {
            var bestIDs = await GetBestStoriesIdsAsync();
            var result = new List<BestStoriesResponseDto>();
            foreach (var id in bestIDs)
            {
                var story = await GetStoryAsync(id);
                result.Add( new BestStoriesResponseDto {
                    Title = story.Title,
                    CommentCount = story.Descendants,
                    PostedBy = story.By,
                    Score = story.Score,
                    Uri = story.Url,
                    Time = Convert.ToDateTime(new TimeSpan(story.Time).ToString())
                });
            }

            return result.OrderByDescending(x => x.Score).Take(20).ToList();
        }
    }
}
