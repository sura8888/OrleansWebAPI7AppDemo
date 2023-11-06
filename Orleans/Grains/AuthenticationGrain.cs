using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;
using System.Text;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class AuthenticationGrain : Grain, IAuthenticationGrain
    {
        private AuthenticationState? _model { get; set; }

        public AuthenticationGrain()
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
            switch (primaryKey)
            {
                case "test@test.com":
                    {
                        _model = new AuthenticationState
                        {
                            Code = "test@test.com",
                            PasswordHash = "Mm7UM0Cj8t0oaKIMSDZdT4n+SpJeTpefGvw9+YFM2Fg="
                        };
                    }
                    break;

                default:

                    break;
            }

            return base.OnActivateAsync(cancellationToken);
        }

        public Task<AuthenticationState?> Get()
        {
            return Task.FromResult(_model);
        }

        public Task Set(AuthenticationState model)
        {
            // UPDATE company SET 住所1 = '**** ;
            _model = model;
            return Task.CompletedTask;
        }

        public Task Remove()
        {
            // DELETE FROM company where ID = '****' ;
            _model = null;
            return Task.CompletedTask;
        }

        public async Task<bool> Authenticate(Authentication model)
        {
            var hash = await GetPasswordHash(model);
            return _model?.PasswordHash == hash;
        }

        public Task<string> GetPasswordHash(Authentication model)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: model.Password!,
                salt: Encoding.Unicode.GetBytes(model.Code),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return Task.FromResult(hashed);
        }

    }


}
