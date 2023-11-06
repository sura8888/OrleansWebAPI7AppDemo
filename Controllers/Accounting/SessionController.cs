using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class SessionController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public SessionController(IGrainFactory grains)
        {
            _grains = grains;
        }

        /// <summary>
        /// セッション情報を取得します
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            // グレインの呼び出し
            var campanyGrain = _grains.GetGrain<ISessionGrain>(id);
            // 指定グレインのGETメソッドを実行して結果を取得する
            var Session = await campanyGrain.Get();
            if (Session == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Session);
            }
        }
    }
}
