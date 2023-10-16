using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Models.Demo;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class CompanyController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public CompanyController(IGrainFactory grains)
        {
            _grains = grains;
        }

        /// <summary>
        /// 会社情報のコード一覧を取得します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("")]
        public IList<string> Index()
        {
            var companies = new List<string>();
            // ↓↓　一般的にはデータベースから取得する
            // SELECT * FROM Company;
            companies.Add("t283162780");
            // ↑↑
            return companies;
        }
        /// <summary>
        /// 会社情報をコードを指定して取得します
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("{id}")]
        public async Task<Company> Get(string id)
        {
            // var company = new Company();
            // ↓↓　一般的にはデータベースから取得する
            // SELECT * FROM Company WHERE Code = {id};
            //switch (id)
            //{
            //    case "t283162780":
            //        {
            //            company.Code = "t283162780";
            //            company.Name = "デモ株式会社";
            //            company.NameKana = "デモカブシキガイシャ";
            //            company.代表者姓 = "円簿";
            //            company.代表者名 = "太郎";
            //            company.代表者フリガナ姓 = "エンボ";
            //            company.代表者フリガナ名 = "タロウ";
            //            company.住所郵便番号 = "1120012";
            //            company.住所都道府県 = "東京都";
            //            company.住所1 = "文京区大塚1-5-18";
            //        }
            //        break;
            //}

            var campanyGrain = _grains.GetGrain<ICompanyGrain>(id);
            var company = await campanyGrain.Get();

            // ↑↑
            return company;
        }
        /// <summary>
        /// 会社情報を修正します。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("{id}")]
        public async Task<Company> Set(string id , [FromBody] Company company)
        {
            // ↓↓　テストでデータの一部分を更新
            // UPDATE company SET 住所1 = '**** ;

            var campanyGrain = _grains.GetGrain<ICompanyGrain>(id);
            await campanyGrain.Set(company);
            // ↑↑
            return company;
        }
    }
}
