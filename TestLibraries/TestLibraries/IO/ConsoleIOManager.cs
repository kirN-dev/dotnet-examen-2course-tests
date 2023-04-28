using System.Text;

namespace TestHelpers.IO
{
    internal class ConsoleIOManager
    {
        private string _input;
        private StringBuilder _output;

        public ConsoleIOManager()
        {
            _input = string.Empty;
            _output = new StringBuilder();
        }

        internal void AddInput(string input)
        {
            _input += input;
        }

        internal string ReadLine()
        {
            string result = null;
            if (_input.Contains(Environment.NewLine))
            {
                var lines = _input.Split(Environment.NewLine);
                _input = string.Join(Environment.NewLine, lines[1..]);
                result = lines[0];
                _output.AppendLine(result);
                return lines[0];
            }

            result = _input;
            _input = string.Empty;
            _output.AppendLine(result);
            return result;
        }

        internal int Read()
        {
            if (string.IsNullOrEmpty(_input))
                return -1;

            int read = _input[0];
            _input = _input[1..];
            return read;
        }

        internal void Write(string str)
        {
            _output.Append(str);
        }

        internal string ReadOutput()
        {
            string output = _output.ToString();
            _output.Clear();
            return output;
        }
    }
}
