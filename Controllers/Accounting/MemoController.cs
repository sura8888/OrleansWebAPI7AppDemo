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
        /// ���[�U�[��ID�ƕR�Â��Ēǉ����܂�
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
        /// �w�肵�����[�U�[ID�Ƀ�����ǉ����܂�
        /// </summary>
        [HttpPost]
        [Route("{userId}")]
        public IActionResult AddMemo(int userId, [FromBody] string content)
        {
            if (userMemos.TryGetValue(userId, out var memos))
            {
                // �����̃����̒��ōő�� ID ���擾
                var maxMemoId = memos.Any() ? memos.Max(m => m.MemoId) : 0;

                // �V���������� ID ������
                var newMemoId = maxMemoId + 1;

                // �V�����������쐬
                var newMemo = new Memo
                {
                    MemoId = newMemoId,
                    Content = content,
                    Day = DateTime.Now
                };

                // �V����������ǉ�
                memos.Add(newMemo);

                return Ok(memos);
            }
            else
            {
                return NotFound($"User with ID {userId} not found.");
            }
        }

        /// <summary>
        /// �w�肵�����[�U�[ID�̃��������ׂĕ\�����܂�
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
        /// �w�肵�����[�U�[ID�ƃ����ԍ��ɑΉ�����������\�����܂�
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
        /// �w�肵�����[�U�[ID�ƃ����ԍ��ɑΉ����郁�����폜���܂�
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
                    // �폜���������� ID ���傫�� ID ���������� ID ���J��グ��
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
