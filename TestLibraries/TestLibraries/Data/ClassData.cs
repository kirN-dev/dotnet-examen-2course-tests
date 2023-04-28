namespace TestHelpers.Data
{
    public class ClassData
    {
        public string DataName { get; set; }
        public object Value { get; set; }
        public Type DataType => Value?.GetType();
    }
}
