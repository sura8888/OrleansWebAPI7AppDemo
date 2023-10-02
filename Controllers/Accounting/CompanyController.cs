using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Models.Demo;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]/[action]")]
    public class CompanyController : ControllerBase
    {

        public CompanyController()
        {
        }

        [HttpGet()]
        [Route("/Accounting/Company")]
        public Company Index()
        {
            var company = new Company();
            company.Code = "t283162780";
            company.Name = "デモ株式会社";
            company.NameKana = "デモカブシキガイシャ";
            company.代表者姓 = "円簿";
            company.代表者名 = "太郎";
            company.代表者フリガナ姓 = "エンボ";
            company.代表者フリガナ名 = "タロウ";
            company.住所郵便番号 = "1120012";
            company.住所都道府県 = "東京都";
            company.住所1 = "文京区大塚1-5-18";
            return company;
        }

    }
}
