using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public AuthenticationController(IGrainFactory grains)
        {
            _grains = grains;
        }
        /// <summary>
        /// 勘定科目を取得します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("")]
        public IList<string> Index()
        {
            var items = new List<string>();
            // ↓↓　一般的にはデータベースから取得する
            // SELECT * FROM Authentication;
            items.Add("test@test.com");
            // ↑↑　
            return items;
        }

        ///// <summary>
        ///// 指定したコードの勘定科目を取得します
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet()]
        //[Route("{id}")]

        //public async Task<IActionResult> Get(String id)
        //{
        //    // グレインの呼び出し
        //    var authenticationGrain = _grains.GetGrain<IAuthenticationGrain>(id);
        //    // 指定グレインのGETメソッドを実行して結果を取得する
        //    var authentication = await authenticationGrain.Get();
        //    if (authentication == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(authentication);
        //    }
        //}
        /// <summary>
        /// 会社情報を追加・修正します。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authentication"></param>
        /// <returns></returns>
        [HttpPut()]
        [Route("{id}")]
        public async Task<Authentication> Set(string id, [FromBody] Authentication authentication)
        {

            var authenticationGrain = _grains.GetGrain<IAuthenticationGrain>(id);
            await authenticationGrain.Set(authentication);

            return authentication;
        }
        [HttpPut()]
        [Route("gethash")]
        public async Task<String> GetHash([FromBody] Authentication authentication)
        {

            var authenticationGrain = _grains.GetGrain<IAuthenticationGrain>(authentication.Code);
            var hash = await authenticationGrain.GetPasswordHash(authentication);
            return hash;
        }
        /// <summary>
        /// 会社情報を削除します
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete()]
        [Route("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            // ↓↓　テストでデータの一部分を更新
            var authenticationGrain = _grains.GetGrain<IAuthenticationGrain>(id);
            await authenticationGrain.Remove();
            // ↑↑
            return Ok();
        }


        [HttpPost()]
        [Route("{id}")]
        public async Task<Authentication> Authentication([FromBody] Authentication authentication)
        {

            var authenticationGrain = _grains.GetGrain<IAuthenticationGrain>(authentication.Code);
            var current =  await authenticationGrain.Get();

            return authentication;
        }

    }
}
