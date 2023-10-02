using Microsoft.AspNetCore.Mvc;
using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Demo
{
    // https://learn.microsoft.com/ja-jp/dotnet/orleans/quickstarts/build-your-first-orleans-app?tabs=visual-studio
    [ApiController]
    [Route("[controller]")]
    public class OrleansStringCacheController : ControllerBase
    {

        private readonly ILogger<OrleansStringCacheController> _logger;
        private readonly IGrainFactory _grains;

        public OrleansStringCacheController(ILogger<OrleansStringCacheController> logger, IGrainFactory grains)
        {
            _logger = logger;
            _grains = grains;
        }

        [HttpGet("set/{value}", Name = "Set")]
        public async Task<Uri> Set(string value)
        {
            // Create a unique, short ID
            var key = Guid.NewGuid().GetHashCode().ToString("X");

            // Create and persist a grain with the shortened ID and full URL
            var stringCacheGrain = _grains.GetGrain<IStringCacheGrain>(key);
            await stringCacheGrain.SetValue(value);

            // Return the shortened URL for later use
            var resultBuilder = new UriBuilder($"{Request.Scheme}://{Request.Host.Value}")
            {
                Path = $"/stringcache/get/{key}"
            };

            return resultBuilder.Uri;

        }

        [HttpGet("get/{key}", Name = "Get")]
        public async Task<ActionResult> Get(string key)
        {
            // Retrieve the grain using the shortened ID and redirect to the original URL        
            var stringCacheGrain = _grains.GetGrain<IStringCacheGrain>(key);
            var value = await stringCacheGrain.GetValue();
            return Content(value);
        }
    }
}