using System.Diagnostics.CodeAnalysis;

namespace FuckML.Converters
{
    public class DotConverter : IConverter
    {
        /// <summary>
        /// Removes all dots from <paramref name="msg"/>. 
        /// </summary>
        /// <param name="msg">A message for remove dots</param>
        /// <returns>A <paramref name="msg"/> without dots.</returns>
        public string Convert([NotNull]string msg)
#pragma warning disable CA1307 // Используйте StringComparison, чтобы ясно указать намерение.
            => msg.Replace(".", "");
#pragma warning restore CA1307 // Используйте StringComparison, чтобы ясно указать намерение.
    }
}
