using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;
using System.Threading.Tasks;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class MemoController : ControllerBase
    {
        private static List<Memo> memos = new List<Memo>();
        private static int nextId = 1;

        /// <summary>
        /// ������S�Ă�\�����܂�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllMemos()
        {
            return Ok(memos);
        }

        /// <summary>
        /// �w�肵��id�̃�����\�����܂�
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetMemo(int id)
        {
            var memo = memos.Find(m => m.Id == id);
            if (memo == null)
            {
                return NotFound();
            }
            return Ok(memo);
        }

        /// <summary>
        /// ������ǉ����܂�
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMemo([FromBody] string content)
        {
            var memo = new Memo
            {
                Id = nextId++,
                Content = content,
                Day = DateTime.Now
            };
            memos.Add(memo);
            return Ok(memo);
        }

        /// <summary>
        /// �������폜���܂�
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteMemo(int id)
        {
            var memoToDelete = memos.Find(m => m.Id == id);
            if (memoToDelete == null)
            {
                return NotFound();
            }

            memos.Remove(memoToDelete);

            // �폜������̃�����ID���J��グ��
            foreach (var memo in memos.Where(m => m.Id > id))
            {
                memo.Id--;
            }

            return Ok();
        }
    }
}