using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class AccountItemController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public AccountItemController(IGrainFactory grains)
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
            // SELECT * FROM AccountItem;
            items.Add("100");
            items.Add("700");
            // ↑↑　
            return items;
        }

        /// <summary>
        /// 指定したコードの勘定科目を取得します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("{id}")]

        public async Task<IActionResult> Get(String id)
        {
            // グレインの呼び出し
            var campanyGrain = _grains.GetGrain<IAccountItemGrain>(id);
            // 指定グレインのGETメソッドを実行して結果を取得する
            var accountItem = await campanyGrain.Get();
            if (accountItem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(accountItem);
            }
        }
        /// <summary>
        /// 会社情報を追加・修正します。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountItem"></param>
        /// <returns></returns>
        [HttpPut()]
        [Route("{id}")]
        public async Task<AccountItem> Set(string id, [FromBody] AccountItem accountItem)
        {

            var campanyGrain = _grains.GetGrain<IAccountItemGrain>(id);
            await campanyGrain.Set(accountItem);

            return accountItem;
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
            var campanyGrain = _grains.GetGrain<IAccountItemGrain>(id);
            await campanyGrain.Remove();
            // ↑↑
            return Ok();
        }

    }
}
