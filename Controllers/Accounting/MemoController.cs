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
        private readonly IGrainFactory _grains;

        public MemoController(IGrainFactory grains)
        {
            _grains = grains;
        }


        /// <summary>
        /// ������S�Ă�\�����܂�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMemos()
        {
            var memoGrain = _grains.GetGrain<IMemoGrain>(0); // Assuming grain ID is 0
            var memoState = await memoGrain.GetMemoState();

            return Ok(memoState.Memos);
        }

        /// <summary>
        /// �w�肵��id�̃�����\�����܂�
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemo(int id)
        {
            var grain = _grains.GetGrain<IMemoGrain>(id);
            var memo = await grain.GetMemo(id);
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
        public async Task<IActionResult> AddMemo([FromBody] string content)
        {
            var memoGrain = _grains.GetGrain<IMemoGrain>(0); // Assuming grain ID is 0
            await memoGrain.AddMemo(content);

            return Ok();
        }


        /// <summary>
        /// �������폜���܂�
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemo(int id)
        {
            var grain = _grains.GetGrain<IMemoGrain>(id);
            await grain.DeleteMemo(id);
            return Ok();
        }
    }
}