using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    /// <summary>
    /// 認証モデル （パスワードはハッシュ済　保管用）
    /// </summary>
    [GenerateSerializer]
    public class AuthenticationState
    {
        [Id(0)]
        // ユーザーID （メールアドレス）
        public string Code { get; set; } = String.Empty;
        [Id(1)]
        // パスワードハッシュ
        public string PasswordHash { get; set; } = String.Empty;

    }

}
