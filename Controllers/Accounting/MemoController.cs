using Microsoft.AspNetCore.Mvc;
using Orleans;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;
using System.Threading.Tasks;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class MemoController : ControllerBase
    {
        private static Dictionary<int, List<Memo>> userMemos = new Dictionary<int, List<Memo>>();
        private static int nextUserId = 1;
        private static int nextMemoId = 1;

        private readonly IMemoGrain _memoGrain;

        public MemoController(IMemoGrain memoGrain)
        {
            _memoGrain = memoGrain;
        }
        /// <summary>
        /// ユーザーをIDと紐づけて追加します
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [Route("")]
        public IActionResult AddUser()
        {
            var userId = nextUserId++;
            userMemos[userId] = new List<Memo>();
            return Ok(userId);
        }
        /// <summary>
        /// 指定したユーザーIDのメモをすべて表示します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("{userId}")]
        public IActionResult GetAllMemos(int userId)
        {
            if (userMemos.ContainsKey(userId))
            {
                var userMemosList = userMemos[userId];
                return Ok(userMemosList);
            }
            else
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }

        /// <summary>
        /// 指定したユーザーIDとメモ番号に対応したメモを表示します        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("{userId}/{memoId}")]
        public IActionResult GetMemo(int userId, int memoId)
        {
            if (userMemos.ContainsKey(userId))
            {
                var userMemosList = userMemos[userId];
                var memo = userMemosList.Find(m => m.MemoId == memoId);
                if (memo == null)
                {
                    return NotFound($"Memo with ID {memoId} not found for user {userId}.");
                }
                return Ok(memo);
            }
            else
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }

        /// <summary>
        /// 指定したユーザーIDにメモを追加します
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [Route("{userId}")]
        public async Task<IActionResult> AddMemo(int userId, [FromBody] string content)
        {
            if (!userMemos.ContainsKey(userId))
            {
                return NotFound($"User with ID {userId} not found.");
            }

            await _memoGrain.AddMemo(content);
            var memo = await _memoGrain.GetMemo();
            userMemos[userId].Add(memo);
            return Ok(memo);
        }

        /// <summary>
        /// 指定したユーザーIDとメモ番号に対応するメモを削除します
        /// </summary>
        /// <returns></returns>
        [HttpDelete()]
        [Route("{userId}/{memoId}")]
        public async Task<IActionResult> DeleteMemo(int userId, int memoId)
        {
            if (userMemos.ContainsKey(userId))
            {
                var userMemosList = userMemos[userId];
                var memoToDelete = userMemosList.Find(m => m.MemoId == memoId);
                if (memoToDelete == null)
                {
                    return NotFound($"Memo with ID {memoId} not found for user {userId}.");
                }

                userMemosList.Remove(memoToDelete);

                // 削除した後のメモのIDを繰り上げる
                foreach (var memo in userMemosList.Where(m => m.MemoId > memoId))
                {
                    memo.MemoId--;
                }

                await _memoGrain.DeleteMemo(memoId);
                return Ok();
            }
            else
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }
    }
}