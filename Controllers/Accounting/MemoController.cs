using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using OrleansWebAPI7AppDemo.Models.Accounting;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class MemoController : ControllerBase
    {
        private static int nextUserId = 1;
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
        /// 指定したユーザーIDにメモを追加します
        /// </summary>
        [HttpPost]
        [Route("{userId}")]
        public IActionResult AddMemo(int userId, [FromBody] string content)
        {
            if (userMemos.TryGetValue(userId, out var memos))
            {
                // 既存のメモの中で最大の ID を取得
                var maxMemoId = memos.Any() ? memos.Max(m => m.MemoId) : 0;

                // 新しいメモの ID を決定
                var newMemoId = maxMemoId + 1;

                // 新しいメモを作成
                var newMemo = new Memo
                {
                    MemoId = newMemoId,
                    Content = content,
                    Day = DateTime.Now
                };

                // 新しいメモを追加
                memos.Add(newMemo);

                return Ok(memos);
            }
            else
            {
                return NotFound($"User with ID {userId} not found.");
            }
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
                var memo = memos.FirstOrDefault(m => m.MemoId == memoId);
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
        /// 指定したユーザーIDとメモ番号に対応するメモを削除します
        /// </summary>
        [HttpDelete]
        [Route("{userId}/{memoId}")]
        public IActionResult DeleteMemo(int userId, int memoId)
        {
            if (userMemos.ContainsKey(userId))
            {
                var memos = userMemos[userId];
                var memoToRemove = memos.FirstOrDefault(m => m.MemoId == memoId);
                if (memoToRemove != null)
                {
                    memos.Remove(memoToRemove);
                    // 削除したメモの ID より大きい ID を持つメモの ID を繰り上げる
                    foreach (var memo in memos.Where(m => m.MemoId > memoId))
                    {
                        memo.MemoId--;
                    }
                    return Ok(memos);
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
