using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{

    /// <summary>
    /// メモ情報
    /// </summary>
    [GenerateSerializer]
    public class TestMemo
    {
        [Id(0)]
        // ユーザーコード
        public string UserCode { get; set; } = String.Empty;
        [Id(1)]
        // メモコード
        public string MemoCode { get; set; } = String.Empty;
        [Id(2)]
        // メモ本文
        public string Content { get; set; } = String.Empty;
    }
}
