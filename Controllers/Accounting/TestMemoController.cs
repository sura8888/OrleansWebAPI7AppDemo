using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class TestMemoController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public TestMemoController(IGrainFactory grains)
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
            items.Add("userid");
            items.Add("A");
            items.Add("B");

            items.Add("memoid");
            items.Add("1");
            items.Add("2");
            items.Add("3");
            // ↑↑　
            return items;
        }

        /// <summary>
        /// 指定したコードの勘定科目を取得します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("{userid}/{memoid}")]

        public async Task<IActionResult> Get(String userid, String memoid)
        {
            // グレインの呼び出し
            var testmemoGrain = _grains.GetGrain<ITestMemoGrain>($"{userid}-{memoid}");
            // 指定グレインのGETメソッドを実行して結果を取得する
            var testMemo = await testmemoGrain.Get();
            if (testMemo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(testMemo);
            }
        }
        /// <summary>
        /// 会社情報を追加・修正します。
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="memoid"></param>
        /// <param name="testMemo"></param>
        /// <returns></returns>
        [HttpPut()]
        [Route("{userid}/{memoid}")]
        public async Task<TestMemo> Set(string userid, string memoid, [FromBody] TestMemo testMemo)
        {

            var testmemoGrain = _grains.GetGrain<ITestMemoGrain>($"{userid}-{memoid}");
            await testmemoGrain.Set(testMemo);

            return testMemo;
        }
        /// <summary>
        /// 会社情報を削除します
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="memoid"></param>
        /// <returns></returns>
        [HttpDelete()]
        [Route("{userid}/{memoid}")]
        public async Task<IActionResult> Remove(string userid, string memoid)
        {
            // ↓↓　テストでデータの一部分を更新
            var testmemoGrain = _grains.GetGrain<ITestMemoGrain>($"{userid}-{memoid}");
            await testmemoGrain.Remove();
            // ↑↑
            return Ok();
        }

    }
}
