using HarmonyLib;
using System;
using System.IO;
using System.Reflection;


namespace TestHelpers.IO
{
    public class ConsoleMock : IDisposable
    {
        private ConsoleIOManager _consoleManager;
        private TextReader _defaultIn;
        private TextWriter _defaultOut;
        private Harmony _harmonyPatcher;

        public ConsoleMock()
        {
            _consoleManager = new ConsoleIOManager();
            _defaultIn = Console.In;
            _defaultOut = Console.Out;
            Console.SetIn(new InputManager(_consoleManager));
            Console.SetOut(new OutputManager(_consoleManager, Console.OutputEncoding));
            PatchConsole();
        }

        public void Schedule(InputPlanner planner)
        {
            _consoleManager.AddInput(planner.ToString());
        }

        public void Dispose()
        {
            RestoreStreams();
            UnpatchConsole();
        }

        public string ReadOutput()
        {
            return _consoleManager.ReadOutput();
        }

        public string[] ReadOutputLines()
        {
            string output = ReadOutput();
            if (output.StartsWith(Environment.NewLine))
                output = output[Environment.NewLine.Length..];
            if (output.EndsWith(Environment.NewLine))
                output = output[..^Environment.NewLine.Length];
            return output.Split(Environment.NewLine);
        }

        private void RestoreStreams()
        {
            Console.SetIn(_defaultIn);
            Console.SetOut(_defaultOut);
        }

        private MethodInfo _originalMethod;
        private MethodInfo _patchMethod;

        private void PatchConsole()
        {
            var consoleType = typeof(Console);
            _originalMethod = consoleType.GetMethod("ReadKey",
                BindingFlags.Static | BindingFlags.Public,
                null,
                Array.Empty<Type>(),
                Array.Empty<ParameterModifier>());
            _harmonyPatcher = new Harmony("com.courses.dotnet");
            var patch = typeof(ConsolePatch).GetMethod("Transpiler", BindingFlags.Static | BindingFlags.NonPublic);
            _patchMethod = _harmonyPatcher.Patch(_originalMethod, transpiler: new HarmonyMethod(patch));
        }

        private void UnpatchConsole()
        {
            _harmonyPatcher.Unpatch(_originalMethod, _patchMethod);
        }
    }
}
