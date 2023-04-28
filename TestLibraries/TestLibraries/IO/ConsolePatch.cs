using HarmonyLib;
using System.Reflection;
using System.Reflection.Emit;

namespace TestHelpers.IO
{
    internal class ConsolePatch
    {
        private static MethodInfo _readKeyOverwrite = typeof(ConsolePatch).GetMethod(nameof(ReadKeyMock), BindingFlags.Static | BindingFlags.NonPublic);

        private static ConsoleKeyInfo ReadKeyMock()
        {
            int read = Console.Read();
            return new ConsoleKeyInfo((char)read, (ConsoleKey)read, false, false, false);
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            yield return new CodeInstruction(OpCodes.Call, _readKeyOverwrite);
            yield return new CodeInstruction(OpCodes.Ret);
        }
    }
}
