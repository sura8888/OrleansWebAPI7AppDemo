using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    ///Accounting
    /// 
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
    }
}
