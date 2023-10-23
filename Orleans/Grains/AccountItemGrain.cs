using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class AccountItemGrain : Grain , IAccountItemGrain
    {
        private AccountItem? _model { get; set; }

        public AccountItemGrain()
        {
        }

        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {

            string primaryKey = this.GetPrimaryKeyString(); //Grain IDを取得

            // ↓　本来はデータベースから取得する
            switch(primaryKey)
            {
                case "100":
                    {
                        _model = new AccountItem
                        {
                            Code = "100",
                            Name = "現金",
                            略称 = "現金",
                            カナ = "ゲンキン",
                            ローマ字 = "genkin",
                            貸借 = 貸借区分.借方科目,
                            消費税 = 消費税区分.対象外,
                            帳表種類 = 帳表種類区分.貸借対照表,
                            集計先科目 = "1399",
                            帳簿区分 = 帳簿区分.現金
                        };
                    }
                    break;
                case "700":
                    {
                        _model = new AccountItem();
                        _model.Code = "700";
                        _model.Name = "売上高";
                        _model.略称 = "売上高";
                        _model.カナ = "ウリアゲダカ";
                        _model.ローマ字 = "uriagedaka";
                        _model.貸借 = 貸借区分.借方科目;
                        _model.消費税 = 消費税区分.売上;
                        _model.帳表種類 = 帳表種類区分.損益計算書;
                        _model.集計先科目 = "7199";
                        _model.帳簿区分 = 帳簿区分.設定なし;
                    }
                    break;

                default:

                    break;
            }

            return base.OnActivateAsync(cancellationToken);
        }

        public Task<AccountItem?> Get()
        {
            return Task.FromResult(_model);
        }

        public Task Set(AccountItem company)
        {
            // UPDATE company SET 住所1 = '**** ;
            _model = company;
            return Task.CompletedTask;
        }

        public Task Remove()
        {
            // DELETE FROM company where ID = '****' ;
            _model = null;
            return Task.CompletedTask;
        }

    }


}
