using System.Diagnostics.CodeAnalysis;

namespace FuckML.Converters
{
    public class SpaceConverter : IConverter
    {
        public string Convert([NotNull]string msg)
#pragma warning disable CA1307 // Используйте StringComparison, чтобы ясно указать намерение.
            => msg.Replace(" ", "");
#pragma warning restore CA1307 // Используйте StringComparison, чтобы ясно указать намерение.
    }
}
