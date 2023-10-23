using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    /// <summary>
    /// 会社情報
    /// </summary>
    [GenerateSerializer]
    public class Company
    {
        [Id(0)]
        // 会社コード
        public string Code {get;set; } = String.Empty;
        [Id(1)]
        // 名前
        public string Name {get;set;} = String.Empty;
        // 会社フリガナ
        [Id(2)]
        public string NameKana {get;set; }  = String.Empty;
        //
        [Id(3)]
        public string 代表者 {get;set; }  = String.Empty;
        //
        [Id(4)]
        public string 代表者姓 {get;set; }  = String.Empty;
        [Id(5)]
        public string 代表者名 {get;set; }  = String.Empty;
        [Id(6)]
        public string 代表者フリガナ姓 {get;set; }  = String.Empty;
        [Id(7)]
        public string 代表者フリガナ名 {get;set; }  = String.Empty;
        [Id(8)]
        public string 住所郵便番号 {get;set; }  = String.Empty;
        [Id(9)]
        public string 住所都道府県 {get;set; }  = String.Empty;
        [Id(10)]
        public string 住所1 {get;set; }  = String.Empty;
        [Id(11)]
        public string 住所2 {get;set; }  = String.Empty;
        [Id(12)]
        public string Tel1 {get;set; }  = String.Empty;
        [Id(13)]
        public string Tel2 {get;set; }  = String.Empty;
        [Id(14)]
        public string Tel3 {get;set; }  = String.Empty;
        [Id(15)]
        public string Fax1 {get;set; }  = String.Empty;
        [Id(16)]
        public string Fax2 {get;set; }  = String.Empty;
        [Id(17)]
        public string Fax3 {get;set; }  = String.Empty;
        [Id(18)]
        public string HomePage {get;set; }  = String.Empty;
        [Id(19)]
        public string 法人番号 {get;set; }  = String.Empty;
        [Id(20)]
        public Int32 従業員数 {get;set; }  = 0;
        [Id(21)]
        public Int32 役員数 {get;set; }  = 0;
        [Id(22)]
        public string 業種 {get;set; }  = String.Empty;
    }
}
