namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    public class AccountItem
    {
        // 勘定科目コード
        public string Code { get; set; } = String.Empty;
        // 勘定科目名称
        public string Name { get; set; } = String.Empty;
        // 勘定科目略称
        public string 略称 { get; set; } = String.Empty;
        // 勘定科目カナ
        public string カナ { get; set; } = String.Empty;
        // 勘定科目ローマ字
        public string ローマ字 { get; set; } = String.Empty;
        /// <summary>
        /// 貸借
        /// 0：借方科目
        /// 1：貸方科目
        /// </summary>
        public 貸借区分 貸借 { get; set; } = 貸借区分.借方科目;

        // 勘定科目消費税
        public 消費税区分 消費税 { get; set; } = 消費税区分.対象外;
        // 勘定科目帳表種類
        public 帳表種類区分 帳表種類 { get; set; } = 帳表種類区分.貸借対照表;
        // 勘定科目集計先科目
        public string 集計先科目 { get; set; } = String.Empty;
        // 勘定科目帳簿区分
        public 帳簿区分 帳簿区分 { get; set; } = 帳簿区分.設定なし;

    }

    public enum 貸借区分
    {
        借方科目 = 0,
        貸方科目 = 1
    }
    public enum 消費税区分
    {
        対象外 = 0,
        売上 = 1,
        仕入 = 2,
        非課税 = 3
    }

    public enum 帳表種類区分
    {
        貸借対照表 = 0,
        損益計算書 = 1
    }

    public enum 帳簿区分
    {
        設定なし = 0,
        現金 = 1,
        預金 = 2
    }

}
