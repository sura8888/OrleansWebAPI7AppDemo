using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class TestController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public TestController(IGrainFactory grains)
        {
            _grains = grains;
        }

        /// <summary>
        /// ƒZƒbƒVƒ‡ƒ“î•ñ‚ğæ“¾‚µ‚Ü‚·
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("")]
        public string Get()
        {
            return DateTime.Now.ToShortTimeString();
        }
    }
}
