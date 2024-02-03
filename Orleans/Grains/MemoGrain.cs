using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class MemoGrain : Grain, IMemoGrain
    {
        private Memo? memo;

        public MemoGrain()
        {
        }

        /// <summary>
        /// グレイン有効化時の処理
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            memo = new Memo
            {
                UserId = (int)this.GetPrimaryKeyLong(),
                MemoId = 1,
                Content = "初めてのメモ",
                Day = DateTime.Now
            };
            return base.OnActivateAsync(cancellationToken);
        }

        public Task<Memo?> GetMemo()
        {
            return Task.FromResult(memo);
        }

        public Task AddMemo(string content)
        {
            var newMemo = new Memo
            {
                UserId = (int)this.GetPrimaryKeyLong(),
                MemoId = memo.MemoId + 1,
                Content = content,
                Day = DateTime.Now
            };
            memo = newMemo;
            return Task.CompletedTask;
        }

        public Task DeleteMemo(int memoId)
        {
            // メモを削除する場合の処理を追加
            // 例: メモを初期状態に戻す
            memo = new Memo
            {
                UserId = (int)this.GetPrimaryKeyLong(),
                MemoId = 1,
                Content = "初めてのメモ",
                Day = DateTime.Now
            };
            return Task.CompletedTask;
        }

    }
}