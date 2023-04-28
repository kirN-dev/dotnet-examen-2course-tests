using NUnit.Framework;
using System;
using System.Linq;

namespace TestHelpers.Common
{
    public class TestData<T> : TestData
    {
        public string[] Input { get; }
        public T Expected { get; }

        public TestData(string[] input, T expected)
        {
            Input = input;
            Expected = expected;
        }

        public string GetErrorMessage(T actual)
            => $"{Environment.NewLine}Ввод: [{string.Join(", ", Input.Select(i => $"\"{i}\""))}]" +
            $"{Environment.NewLine}Ожидалось: {Expected}" +
            $"{Environment.NewLine}Было: {actual}";
    }

    public class TestData
    {
        public static TestCaseData CreateTestCaseData<TValue>(string[] input, TValue expected, string testName)
        {
            return new TestCaseData(new TestData<TValue>(input, expected)).SetName(testName);
        }
    }
}
