using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class SessionGrain : Grain , ISessionGrain
    {
        private Session? _Session { get; set; }

        public SessionGrain()
        {
        }


        public Task<Session?> Get()
        {
            return Task.FromResult(_Session);
        }

        public Task Set(Session Session)
        {
            // UPDATE Session SET 住所1 = '**** ;
            _Session = Session;
            return Task.CompletedTask;
        }

        public Task Remove()
        {
            // DELETE FROM Session where ID = '****' ;
            _Session = null;
            return Task.CompletedTask;
        }

    }


}
