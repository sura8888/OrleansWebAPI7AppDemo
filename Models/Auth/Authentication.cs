using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    /// <summary>
    /// 認証モデル（パスワードあり）
    /// </summary>
    [GenerateSerializer]
    public class Authentication
    {
        [Id(0)]
        // ユーザーID （メールアドレス）
        public string Code { get; set; } = String.Empty;
        [Id(1)]
        // パスワード
        public string Password { get; set; } = String.Empty;

    }
}
