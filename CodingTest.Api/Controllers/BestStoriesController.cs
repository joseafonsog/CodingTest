using System.Collections.Generic;
using System.Threading.Tasks;
using CodingTest.Admin;
using CodingTest.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CodingTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestStoriesController : ControllerBase
    {
        private readonly Appsettings _config;
        private readonly IBestStoriesAdmin _bestStoriesAdmin;
        public BestStoriesController(IOptions<Appsettings> config, IBestStoriesAdmin bestStoriesAdmin)
        {
            _config = config.Value;
            _bestStoriesAdmin = bestStoriesAdmin;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            var top20 = await _bestStoriesAdmin.GetTop20Async();

            return new OkObjectResult(top20);
        }
    }
}
