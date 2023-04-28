using NUnit.Framework;
using System.Reflection;

namespace TestHelpers.Common
{
    internal static class CodeStyleTestCaseDataFactory
    {
        private static BindingFlags All = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        internal static IEnumerable<TestCaseData> GetMethodsTestCaseData(Type[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                var methods = type.GetMethods(All).Where(m =>
                    !IsGetterOrSetter(m)
                    && !IsOperator(m)
                    && !IsSpecial(m));

                foreach (var method in methods)
                {
                    if (type.FullName.Equals(method.DeclaringType.FullName))
                    {
                        string errorMessage = $"Метод должен быть назван с прописной буквы: {type.Name}.{method.Name}";

                        string pascalCaseMethodName = Char.ToUpperInvariant(method.Name[0]) + method.Name.Substring(1);
                        yield return new TestCaseData($"{type.Name}.{method.Name}", $"{type.Name}.{pascalCaseMethodName}", errorMessage)
                            .SetName("[Кодстайл] Название методов")
                            .SetCategory("Кодстайл");
                    }
                }
            }
        }

        private static bool IsGetterOrSetter(MethodInfo data)
        {
            return data.Name.Contains("set_") ||
                   data.Name.Contains("get_");
        }

        private static bool IsOperator(MethodInfo data)
        {
            return data.Name.Contains("op_");
        }

        private static bool IsSpecial(MethodInfo method)
        {
            return method.IsSpecialName;
        }
    }
}
