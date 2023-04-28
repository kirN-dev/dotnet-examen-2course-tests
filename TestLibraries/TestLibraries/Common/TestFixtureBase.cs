using NUnit.Framework;
using System.Reflection;
using TestHelpers.Attributes;

namespace TestHelpers.Common
{
    [TestFixture]
    public abstract class TestFixtureBase<T>
    {
        protected static ReflectionHelper ReflectionHelper;

        [Test]
        [TestCaseSource(nameof(CodeStyleTestCaseSource))]
        [Category("Кодстайл")]
        public void CodeStyleTests(string actual, string expected, string errorMessage)
        {
            Assert.AreEqual(expected, actual, errorMessage);
        }

        public static IEnumerable<TestCaseData> CodeStyleTestCaseSource()
        {
            InsureReflectionHelperInitialized<T>();

            var testCases = CodeStyleTestCaseDataFactory.GetMethodsTestCaseData(ReflectionHelper.GetAllTypes());
            return testCases;
        }

        private static void InsureReflectionHelperInitialized<TTestClass>()
        {
            var testType = typeof(TTestClass);
            var targetAssembly = testType.GetCustomAttribute<TargetAssemblyAttribute>(false);
            ReflectionHelper = ReflectionHelper.CreateForAssembly(targetAssembly.Name);
        }
    }
}
