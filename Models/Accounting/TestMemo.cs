using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{

    /// <summary>
    /// �������
    /// </summary>
    [GenerateSerializer]
    public class TestMemo
    {
        [Id(0)]
        // ���[�U�[�R�[�h
        public string UserCode { get; set; } = String.Empty;
        [Id(1)]
        // �����R�[�h
        public string MemoCode { get; set; } = String.Empty;
        [Id(2)]
        // �����{��
        public string Content { get; set; } = String.Empty;
    }
}
