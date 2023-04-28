using System;
using System.IO;
using System.Text;

namespace TestHelpers.IO
{
    internal class OutputManager : TextWriter
    {
        public override Encoding Encoding => _encoding;

        private ConsoleIOManager _consoleManager;
        private Encoding _encoding;

        public OutputManager(ConsoleIOManager consoleManager, Encoding encoding)
        {
            _consoleManager = consoleManager;
            _encoding = encoding;
        }


        public override void Write(bool value)
        {
            _consoleManager.Write(value ? "True" : "False");
        }

        public override void Write(char value)
        {
            _consoleManager.Write($"{value}");
        }

        public override void Write(char[] buffer, int index, int count)
        {
            _consoleManager.Write(new string(buffer.AsSpan(index, count)));
        }

        public override void Write(char[] buffer)
        {
            _consoleManager.Write(new string(buffer));
        }

        public override void Write(decimal value)
        {
            _consoleManager.Write(value.ToString());
        }

        public override void Write(double value)
        {
            _consoleManager.Write(value.ToString());
        }

        public override void Write(float value)
        {
            _consoleManager.Write(value.ToString());
        }

        public override void Write(int value)
        {
            _consoleManager.Write(value.ToString());
        }

        public override void Write(long value)
        {
            _consoleManager.Write(value.ToString());
        }

        public override void Write(object value)
        {
            _consoleManager.Write(value.ToString());
        }

        public override void Write(ReadOnlySpan<char> buffer)
        {
            _consoleManager.Write(new string(buffer));
        }

        public override void Write(string format, object arg0)
        {
            _consoleManager.Write(string.Format(format, arg0));
        }

        public override void Write(string format, object arg0, object arg1)
        {
            _consoleManager.Write(string.Format(format, arg0, arg1));
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            _consoleManager.Write(string.Format(format, arg0, arg1, arg2));
        }

        public override void Write(string format, params object[] arg)
        {
            _consoleManager.Write(string.Format(format, arg));
        }

        public override void Write(string value)
        {
            _consoleManager.Write(value);
        }

        public override void Write(StringBuilder value)
        {
            _consoleManager.Write(value.ToString());
        }

        public override void Write(uint value)
        {
            _consoleManager.Write(value.ToString());
        }

        public override void Write(ulong value)
        {
            _consoleManager.Write(value.ToString());
        }



        public override void WriteLine()
        {
            _consoleManager.Write(Environment.NewLine);
        }

        public override void WriteLine(bool value)
        {
            _consoleManager.Write((value ? "True" : "False") + Environment.NewLine);
        }

        public override void WriteLine(char value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            _consoleManager.Write(new string(buffer.AsSpan(index, count)) + Environment.NewLine);
        }

        public override void WriteLine(char[] buffer)
        {
            _consoleManager.Write(new string(buffer) + Environment.NewLine);
        }

        public override void WriteLine(decimal value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }

        public override void WriteLine(double value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }

        public override void WriteLine(float value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }

        public override void WriteLine(int value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }

        public override void WriteLine(long value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }

        public override void WriteLine(object value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }

        public override void WriteLine(ReadOnlySpan<char> buffer)
        {
            _consoleManager.Write(new string(buffer) + Environment.NewLine);
        }

        public override void WriteLine(string format, object arg0)
        {
            _consoleManager.Write(string.Format(format, arg0) + Environment.NewLine);
        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            _consoleManager.Write(string.Format(format, arg0, arg1) + Environment.NewLine);
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            _consoleManager.Write(string.Format(format, arg0, arg1, arg2) + Environment.NewLine);
        }

        public override void WriteLine(string format, params object[] arg)
        {
            _consoleManager.Write(string.Format(format, arg) + Environment.NewLine);
        }

        public override void WriteLine(string value)
        {
            _consoleManager.Write(value + Environment.NewLine);
        }

        public override void WriteLine(StringBuilder value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }

        public override void WriteLine(uint value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }

        public override void WriteLine(ulong value)
        {
            _consoleManager.Write(value.ToString() + Environment.NewLine);
        }
    }
}
