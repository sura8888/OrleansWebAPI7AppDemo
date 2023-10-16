using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Models.Demo;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class AccountItemController : ControllerBase
    {

        public AccountItemController()
        {
        }
        /// <summary>
        /// 勘定科目を取得します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("")]
        public IList<string> Index()
        {
            var items = new List<string>();
            // ↓↓　一般的にはデータベースから取得する
            // SELECT * FROM AccountItem;
            items.Add("100");
            items.Add("700");
            // ↑↑　
            return items;
        }

        /// <summary>
        /// 指定したコードの勘定科目を取得します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("{id}")]

        public AccountItem Get(String id)
        {
            var item = new AccountItem();
            // ↓↓　一般的にはデータベースから取得する
            // SELECT * FROM AccountItem WHERE Code = {id};
            switch (id)
            {
                case "100":
                    {
                        item.Code = "100";
                        item.Name = "現金";
                        item.略称 = "現金";
                        item.カナ = "ゲンキン";
                        item.ローマ字 = "genkin";
                        item.貸借 = 貸借区分.借方科目;
                        item.消費税 = 消費税区分.対象外;
                        item.帳表種類 = 帳表種類区分.貸借対照表;
                        item.集計先科目 = "1399";
                        item.帳簿区分 = 帳簿区分.現金;
                    }
                    break;
                case "700":
                    {
                        item.Code = "700";
                        item.Name = "売上高";
                        item.略称 = "売上高";
                        item.カナ = "ウリアゲダカ";
                        item.ローマ字 = "uriagedaka";
                        item.貸借 = 貸借区分.借方科目;
                        item.消費税 = 消費税区分.売上;
                        item.帳表種類 = 帳表種類区分.損益計算書;
                        item.集計先科目 = "7199";
                        item.帳簿区分 = 帳簿区分.設定なし;
                    }
                    break;
            }

            // ↑↑　
            return item;
        }
        /// <summary>
        /// 指定したIDの勘定科目を修正します
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("{id}")]
        public AccountItem Set(String id , [FromBody] AccountItem item)
        {
            // ↓↓　テストでデータの一部分を更新
            // UPDATE AccountItem SET 略称 = '**** ;
            item.略称 = "システムで上書きした値が表示されています";
            // ↑↑　
            return item;
        }

    }
}
