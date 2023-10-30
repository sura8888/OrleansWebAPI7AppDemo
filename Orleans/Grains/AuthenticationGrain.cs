using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;
using System.Text;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class AuthenticationGrain : Grain, IAuthenticationGrain
    {
        private Authentication? _model { get; set; }

        public AuthenticationGrain()
        {
        }

        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {

            string primaryKey = this.GetPrimaryKeyString(); //Grain IDを取得

            // ↓　本来はデータベースから取得する
            switch (primaryKey)
            {
                case "test@test.com":
                    {
                        _model = new Authentication
                        {
                            Code = "test@test.com",
                            Password = "testtesttest"
                        };
                    }
                    break;

                default:

                    break;
            }

            return base.OnActivateAsync(cancellationToken);
        }

        public Task<Authentication?> Get()
        {
            return Task.FromResult(_model);
        }

        public Task Set(Authentication model)
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
