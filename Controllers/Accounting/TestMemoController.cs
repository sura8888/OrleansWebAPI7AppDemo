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
        /// ����Ȗڂ��擾���܂�
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("")]
        public IList<string> Index()
        {
            var items = new List<string>();
            // �����@��ʓI�ɂ̓f�[�^�x�[�X����擾����
            // SELECT * FROM AccountItem;
            items.Add("userid");
            items.Add("A");
            items.Add("B");

            items.Add("memoid");
            items.Add("1");
            items.Add("2");
            items.Add("3");
            // �����@
            return items;
        }

        /// <summary>
        /// �w�肵���R�[�h�̊���Ȗڂ��擾���܂�
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("{userid}/{memoid}")]

        public async Task<IActionResult> Get(String userid, String memoid)
        {
            // �O���C���̌Ăяo��
            var testmemoGrain = _grains.GetGrain<ITestMemoGrain>($"{userid}-{memoid}");
            // �w��O���C����GET���\�b�h�����s���Č��ʂ��擾����
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
        /// ��Џ���ǉ��E�C�����܂��B
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
        /// ��Џ����폜���܂�
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="memoid"></param>
        /// <returns></returns>
        [HttpDelete()]
        [Route("{userid}/{memoid}")]
        public async Task<IActionResult> Remove(string userid, string memoid)
        {
            // �����@�e�X�g�Ńf�[�^�̈ꕔ�����X�V
            var testmemoGrain = _grains.GetGrain<ITestMemoGrain>($"{userid}-{memoid}");
            await testmemoGrain.Remove();
            // ����
            return Ok();
        }

    }
}
