using System;

namespace TestHelpers.Common
{
    public class TestMessage<TValue>
    {
        private readonly string input;
        private readonly TValue expected;
        private readonly TValue actual;
        private readonly string message;

        public TestMessage(string input, TValue expected, TValue actual, string message = "")
        {
            this.input = input;
            this.expected = expected;
            this.actual = actual;
            this.message = message;
        }

        public override string ToString()
        {
            return $"{Environment.NewLine}{message}" +
                $"{Environment.NewLine}Ввод: {input}" +
                $"{Environment.NewLine}Ожидалось: {expected}" +
                $"{Environment.NewLine}Было: {actual}";
        }
    }
}
