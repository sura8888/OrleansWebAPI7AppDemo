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

        [HttpGet]
        public IActionResult GetAllMemos()
        {
            return Ok(memos);
        }

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

        [HttpPost]
        public IActionResult AddMemo([FromBody] string content)
        {
            var memo = new Memo
            {
                Id = nextId++,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };
            memos.Add(memo);
            return Ok(memo);
        }
    }