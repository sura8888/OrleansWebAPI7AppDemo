using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;
using System;
using System.Threading.Tasks;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class MemoGrain : Grain, IMemoGrain
    {
        private Memo _memo;

        public Task<Memo> Get()
        {
            return Task.FromResult(_memo);
        }

        public async Task Set(string content)
        {
            _memo = new Memo
            {
                Id = this.GetPrimaryKeyLong(),
                Content = content,
                CreatedAt = DateTime.UtcNow
            };
            await WriteStateAsync();
        }
    }


}
