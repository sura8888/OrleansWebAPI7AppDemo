using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class TestMemoGrain : Grain, ITestMemoGrain
    {
        private TestMemo? _testmemo { get; set; }

        public TestMemoGrain()
        {
        }

        /// <summary>
        /// グレイン有効化時の処理
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {

            string primaryKeys = this.GetPrimaryKeyString(); //Grain IDを取得
            string[] primaryKey = primaryKeys.Split('-');

            // ↓　本来はデータベースから取得する
            switch (primaryKey[0])
            {
                case "A":
                    {
                        _testmemo = new TestMemo();
                        _testmemo.UserCode = "A";
                        switch (primaryKey[1])
                        {
                            case "1":
                                {
                                    _testmemo.MemoCode = "1";
                                    _testmemo.Content = "test";
                                }
                                break;
                                case "2":
                                {
                                    _testmemo.MemoCode = "2";
                                    _testmemo.Content = "test2";
                                }
                                break;
                                case"3":
                                {
                                    _testmemo.MemoCode = "3";
                                    _testmemo.Content = "test3";
                                }
                                break;
                            default:

                                break;
                        }
                    }
                    break;
                    case "B":
                    {
                        _testmemo = new TestMemo();
                        _testmemo.UserCode = "B";
                        switch (primaryKey[1])
                        {
                            case "1":
                                {
                                    _testmemo.MemoCode = "1";
                                    _testmemo.Content = "demo";
                                }
                                break;
                            case "2":
                                {
                                    _testmemo.MemoCode = "2";
                                    _testmemo.Content = "demo2";
                                }
                                break;
                            case "3":
                                {
                                    _testmemo.MemoCode = "3";
                                    _testmemo.Content = "demo3";
                                }
                                break;
                            default: 
                                
                                break;
                        }
                    }
                    break;
                default:

                    break;
            }

            return base.OnActivateAsync(cancellationToken);
        }

        public Task<TestMemo?> Get()
        {
            return Task.FromResult(_testmemo);
        }

        public Task Set(TestMemo testmemo)
        {
            // UPDATE company SET 住所1 = '**** ;
            _testmemo = testmemo;
            return Task.CompletedTask;
        }

        public Task Remove()
        {
            // DELETE FROM company where ID = '****' ;
            _testmemo = null;
            return Task.CompletedTask;
        }

    }


}
