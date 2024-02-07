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
        private static int nextUserId = 1;
        private static int nextMemoId = 1;
        private static Dictionary<int, List<Memo>> userMemos = new Dictionary<int, List<Memo>>();

        /// <summary>
        /// ユーザーをIDと紐づけて追加します
        /// </summary>
        [HttpPost]
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
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetAllMemos(int userId)
        {
            if (userMemos.ContainsKey(userId))
            {
                var memos = userMemos[userId];
                return Ok(memos);
            }
            else
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }

        /// <summary>
        /// 指定したユーザーIDとメモ番号に対応したメモを表示します
        /// </summary>
        [HttpGet]
        [Route("{userId}/{memoId}")]
        public IActionResult GetMemo(int userId, int memoId)
        {
            if (userMemos.ContainsKey(userId))
            {
                var memos = userMemos[userId];
                var memo = memos.Find(m => m.MemoId == memoId);
                if (memo != null)
                {
                    return Ok(memo);
                }
                else
                {
                    return NotFound($"Memo with ID {memoId} not found for user {userId}.");
                }
            }
            else
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }

        /// <summary>
        /// 指定したユーザーIDにメモを追加します
        /// </summary>
        [HttpPost]
        [Route("{userId}")]
        public IActionResult AddMemo(int userId, [FromBody] string content)
        {
            if (userMemos.ContainsKey(userId))
            {
                var memo = new Memo
                {
                    MemoId = nextMemoId++,
                    Content = content,
                    Day = DateTime.Now
                };
                userMemos[userId].Add(memo);
                return Ok(userMemos[userId]);
            }
            else
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }
        /// <summary>
        /// 指定したユーザーIDとメモ番号に対応するメモを削除します
        /// </summary>
        [HttpDelete]
        [Route("{userId}/{memoId}")]
        public IActionResult DeleteMemo(int userId, int memoId)
        {
            if (userMemos.ContainsKey(userId))
            {
                var memos = userMemos[userId];
                var memoToRemove = memos.Find(m => m.MemoId == memoId);
                if (memoToRemove != null)
                {
                    memos.Remove(memoToRemove);
                    return Ok(userMemos[userId]);
                }
                else
                {
                    return NotFound($"Memo with ID {memoId} not found for user {userId}.");
                }
            }
            else
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }
    }
}