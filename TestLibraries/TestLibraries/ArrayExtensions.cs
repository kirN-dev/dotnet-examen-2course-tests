using System;
using System.Text;

namespace TestHelpers
{
    public static class ArrayExtensions
    {
        public static int IndexOf<T>(this T[] array, Func<T, bool> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                    return i;
            }
            return -1;
        }

        public static string ToStringRepresentation<T>(this T[,] array)
        {
            StringBuilder arrayString = new StringBuilder();
            arrayString.AppendLine("[");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                arrayString.Append("  [");

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arrayString.Append(j < array.GetLength(1) - 1 ? $"{array[i, j]}, " : $"{array[i, j]}");
                }

                arrayString.AppendLine(i < array.GetLength(0) - 1 ? "]," : "]");
            }
            arrayString.AppendLine("]");
            return arrayString.ToString();
        }
    }
}
