using System.Text;

namespace TestHelpers.IO
{
    public class InputPlanner
    {
        private StringBuilder _stream;

        public InputPlanner()
        {
            _stream = new StringBuilder();
        }

        public void ScheduleLine(string line)
        {
            _stream.Append(line + Environment.NewLine);
        }

        public void ScheduleLines(string[] lines)
        {
            _stream.Append(string.Join(Environment.NewLine, lines) + Environment.NewLine);
        }

        public void ScheduleRead(params char[] characters)
        {
            _stream.Append(characters);
        }

        public override string ToString()
        {
            return _stream.ToString();
        }
    }
}