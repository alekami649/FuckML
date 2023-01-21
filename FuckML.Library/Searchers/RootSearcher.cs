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
            var regex = new Regex("(^з(а|a)л(у|y)п(а|a))|(^(х|x)(у|y)(е|e|й|и))|(^чл(е|e)н)|(^пизд)|(^(е|e|ё)б)|(^с|cу|yк)|(^бл)", options);

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
