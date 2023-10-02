using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Demo
{
    /// <summary>
    /// 
    /// </summary>
    public class Animal
    {
        // 名前
        private string _name = string.Empty;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }


        // 年齢
        private int _age = 0;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
    }
}
