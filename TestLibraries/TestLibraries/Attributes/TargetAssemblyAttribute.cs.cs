namespace TestHelpers.Attributes
{
    public class TargetAssemblyAttribute : Attribute
    {
        public string Name { get; private set; }

        public TargetAssemblyAttribute(string name)
        {
            Name = name;
        }
    }
}
