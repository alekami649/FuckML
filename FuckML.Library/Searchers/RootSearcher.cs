using System.Text.RegularExpressions;

namespace FuckML.Searchers
{
    public class RootSearcher : ISearcher
    {
        public bool ContainsObscene(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return false;
#pragma warning disable CA1307 // Используйте StringComparison, чтобы ясно указать намерение.

            if (msg.Contains("**"))
                return true;

            var options = RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase;
            var regex = new Regex("(^[\\s\\S]*з(а|a)л(у|y)п[\\s\\S]*$)|(^[\\s\\S]*(х|x|з)(у|y)(е|e|й|и|)[\\s\\S]*$)|(^[\\s\\S]*чл(е|e)н[\\s\\S]*$)|(^[\\s\\S]*пизд[\\s\\S]*$)|(^[\\s\\S]*(е|e|ё)б)[\\s\\S]*$|(^[\\s\\S]*(с|c)(у|y)к[\\s\\S]*$)|(^бл[\\s\\S]*$)", options);

            if (regex.IsMatch(msg))
                return true;

            #region English-Only Obsense
            if (msg.Contains("fuck"))
                return true;
            if (msg.Contains("penis") || msg.Contains("cock"))
                return true;
            #endregion

#pragma warning restore CA1307 // Используйте StringComparison, чтобы ясно указать намерение.
            return false;
        }

        internal bool ContainsObscene(IEnumerable<char> enumerable)
        {
            throw new NotImplementedException();
        }
    }
}
