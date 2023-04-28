namespace TestHelpers.IO
{
    internal class InputManager : TextReader
    {
        private ConsoleIOManager _consoleManager;

        public InputManager(ConsoleIOManager consoleManager)
        {
            _consoleManager = consoleManager;
        }

        public override string ReadLine()
        {
            return _consoleManager.ReadLine();
        }
        public override int Read()
        {
            return _consoleManager.Read();
        }
    }
}
