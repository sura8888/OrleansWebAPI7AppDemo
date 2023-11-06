using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class CompanyGrain : Grain , ICompanyGrain
    {
        private Company? _company { get; set; }

        public CompanyGrain()
        {
        }

        /// <summary>
        /// グレイン有効化時の処理
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {

            string primaryKey = this.GetPrimaryKeyString(); //Grain IDを取得

            // ↓　本来はデータベースから取得する
            switch(primaryKey)
            {
                case "t283162780":
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
                    break;
                default:

                    break;
            }

            return base.OnActivateAsync(cancellationToken);
        }

        public Task<Company?> Get()
        {
            return Task.FromResult(_company);
        }

        public Task Set(Company company)
        {
            // UPDATE company SET 住所1 = '**** ;
            _company = company;
            return Task.CompletedTask;
        }

        public Task Remove()
        {
            // DELETE FROM company where ID = '****' ;
            _company = null;
            return Task.CompletedTask;
        }

    }


}
