using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingTest.Api.Dtos;
using CodingTest.Api.Dtos.Service;
using CodingTest.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CodingTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestStoriesController : ControllerBase
    {
        private readonly Appsettings _config;
        public BestStoriesController(IOptions<Appsettings> config)
        {
            _config = config.Value;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            var bestIDs = await HttpHelper<List<long>>.Get(_config.BestStoriesUrl);
            var result = new List<BestStoriesResponseDto>();
            foreach (var id in bestIDs)
            {
                var story = await HttpHelper<StoryResponseDto>.Get($"{_config.SingleStoryUrl}{id}.json");
                result.Add( new BestStoriesResponseDto {
                    Title = story.Title,
                    CommentCount = story.Descendants,
                    PostedBy = story.By,
                    Score = story.Score,
                    Uri = story.Url,
                    Time = Convert.ToDateTime(new TimeSpan(story.Time).ToString())
                });
            }

            var top20 = result.OrderByDescending(x => x.Score).Take(20).ToList();
            
            return new OkObjectResult(top20);
        }
    }
}
