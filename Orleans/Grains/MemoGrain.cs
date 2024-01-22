using System;
using System.Threading.Tasks;
using Orleans.Providers;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class MemoGrain : Grain<MemoState>, IMemoGrain
    {
        new public MemoState State
        {
            get => base.State;
            set => base.State = value;
        }

        public MemoGrain()
        {
            State = new MemoState();
        }

        public Task<MemoState> GetMemoState()
        {
            return Task.FromResult(State);
        }

        public async Task<Memo> GetMemo(int id)
        {
            var memo = State.Memos.FirstOrDefault(m => m.Id == id);
            return await Task.FromResult(memo);
        }

        public async Task AddMemo(string content)
        {
            var memo = new Memo
            {
                Id = State.NextId++,
                Content = content,
                Day = DateTime.Now
            };

            State.Memos.Add(memo);

            await WriteStateAsync();

            return;
        }

        public async Task DeleteMemo(int id)
        {
            var memoToDelete = State.Memos.FirstOrDefault(m => m.Id == id);
            if (memoToDelete != null)
            {
                State.Memos.Remove(memoToDelete);

                // çÌèúÇµÇΩå„ÇÃÉÅÉÇÇÃIDÇåJÇËè„Ç∞ÇÈ
                foreach (var memo in State.Memos.Where(m => m.Id > id))
                {
                    memo.Id--;
                }

                await WriteStateAsync(); // ÉOÉåÉCÉìÇÃèÛë‘Çâië±âªÇ∑ÇÈ
            }
        }

        Task<int> IMemoGrain.AddMemo(string content)
        {
            throw new NotImplementedException();
        }
    }
}