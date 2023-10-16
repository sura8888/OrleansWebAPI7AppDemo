using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class CompanyGrain : Grain , ICompanyGrain
    {
        private Company _company { get; set; }

        public CompanyGrain()
        {
            _company = new Company();
            _company.Code = "t283162780";
            _company.Name = "デモ株式会社";
            _company.NameKana = "デモカブシキガイシャ";
            _company.代表者姓 = "円簿";
            _company.代表者名 = "太郎";
            _company.代表者フリガナ姓 = "エンボ";
            _company.代表者フリガナ名 = "タロウ";
            _company.住所郵便番号 = "1120012";
            _company.住所都道府県 = "東京都";
            _company.住所1 = "文京区大塚1-5-18";
        }

        public Task<Company> Get()
        {
            return Task.FromResult(_company);
        }

        public Task Set(Company company)
        {
            _company = company;
            return Task.CompletedTask;
        }


    }


}
