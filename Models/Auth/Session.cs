using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    /// <summary>
    /// セッションモデル
    /// </summary>
    [GenerateSerializer]
    public class Session
    {
        [Id(0)]
        // 有効かどうか
        public bool Enabled { get; set; } = false;
        [Id(1)]
        // 有効期限
        public DateTime Expired { get; set; } = DateTime.MinValue;
        [Id(2)]
        // 認証したユーザーID
        public string UserId { get; set; } = String.Empty;
    }

}
