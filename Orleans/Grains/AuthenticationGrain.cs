using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class AuthenticationGrain : Grain , IAuthenticationGrain
    {
        private Authentication? _model { get; set; }

        public AuthenticationGrain()
        {
        }

        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {

            string primaryKey = this.GetPrimaryKeyString(); //Grain IDを取得

            // ↓　本来はデータベースから取得する
            switch(primaryKey)
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

        public Task Set(Authentication company)
        {
            // UPDATE company SET 住所1 = '**** ;
            _model = company;
            return Task.CompletedTask;
        }

        public Task Remove()
        {
            // DELETE FROM company where ID = '****' ;
            _model = null;
            return Task.CompletedTask;
        }

    }


}
