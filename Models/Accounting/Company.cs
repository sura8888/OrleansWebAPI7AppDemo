using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    /// <summary>
    /// 会社情報
    /// </summary>
    public class Company
    {
        // 会社コード
        public string Code {get;set; } = String.Empty;
        // 名前
        public string Name {get;set;} = String.Empty;
        // 会社フリガナ
        public string NameKana {get;set; }  = String.Empty;
        //
        public string 代表者 {get;set; }  = String.Empty;
        //
        public string 代表者姓 {get;set; }  = String.Empty;
        public string 代表者名 {get;set; }  = String.Empty;
        public string 代表者フリガナ姓 {get;set; }  = String.Empty;
        public string 代表者フリガナ名 {get;set; }  = String.Empty;
        public string 住所郵便番号 {get;set; }  = String.Empty;
        public string 住所都道府県 {get;set; }  = String.Empty;
        public string 住所1 {get;set; }  = String.Empty;
        public string 住所2 {get;set; }  = String.Empty;
        public string TEL1 {get;set; }  = String.Empty;
        public string TEL2 {get;set; }  = String.Empty;
        public string TEL3 {get;set; }  = String.Empty;
        public string FAX1 {get;set; }  = String.Empty;
        public string FAX2 {get;set; }  = String.Empty;
        public string FAX3 {get;set; }  = String.Empty;
        public string HomePage {get;set; }  = String.Empty;
        public string 法人番号 {get;set; }  = String.Empty;
        public Int32 従業員数 {get;set; }  = 0;
        public Int32 役員数 {get;set; }  = 0;
        public string 業種 {get;set; }  = String.Empty;
    }
}
