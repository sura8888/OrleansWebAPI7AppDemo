using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;
using System.Security.Cryptography.X509Certificates;

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


        ///// <summary>
        ///// 認証データを取得します
        ///// </summary>
        ///// <returns></returns>
        [HttpGet()]
        [Route("{id}")]

        public async Task<IActionResult> Get(String id)
        {
            // グレインの呼び出し
            var authenticationGrain = _grains.GetGrain<IAuthenticationGrain>(id);
            // 指定グレインのGETメソッドを実行して結果を取得する
            var authentication = await authenticationGrain.Get();
            if (authentication == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(authentication);
            }
        }
        /// <summary>
        /// ハッシュコードを取得します
        /// </summary>
        /// <param name="authentication"></param>
        /// <returns></returns>
        [HttpPut()]
        [Route("gethash")]
        public async Task<String> GetHash([FromBody] Authentication authentication)
        {
            // ユーザーIDでグレインの呼び出し
            var authenticationGrain = _grains.GetGrain<IAuthenticationGrain>(authentication.Code);
            // パスワードハッシュの作成
            var hash = await authenticationGrain.GetPasswordHash(authentication);
            return hash;
        }
        /// <summary>
        /// ユーザーデータを削除します
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete()]
        [Route("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            // ユーザーIDでグレインの呼び出し
            var authenticationGrain = _grains.GetGrain<IAuthenticationGrain>(id);
            // ユーザーデータの削除
            await authenticationGrain.Remove();
            // ↑↑
            return Ok();
        }

        /// <summary>
        /// ユーザーIDとパスワードから認証処理を行い
        /// 認証できた場合にはセッションIDを返す
        /// </summary>
        /// <param name="authentication"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("auth")]
        public async Task<Guid?> Authentication([FromBody] Authentication authentication)
        {
            // ユーザーIDでグレインの呼び出し
            var authenticationGrain = _grains.GetGrain<IAuthenticationGrain>(authentication.Code);
            // 認証処理を実行
            var result = await authenticationGrain.Authenticate(authentication);
            //
            if (result) // 認証OK時の処理
            {
                // 新規セッションIDの作成
                var guid = Guid.NewGuid();
                // セッションIDからセッショングレインの呼び出し
                var sessionGrain = _grains.GetGrain<ISessionGrain>(guid);
                // セッションデータの作成
                var session = new Session
                {
                    Enabled = true,
                    Expired = DateTime.UtcNow.AddHours(12),
                    UserId = authentication.Code
                };
                // グレインにセッションデータを保存
                await sessionGrain.Set(session);
                // セッションIDを返す
                return guid;
            }
            return null; //認証NG時はNULLを返す
        }

    }
}
