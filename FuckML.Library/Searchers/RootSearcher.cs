namespace FuckML.Searchers
{
    public class RootSearcher : ISearcher
    {
        public bool Recurse { get; set; } = true;

        public bool ContainsObscene(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return false;
#pragma warning disable CA1307 // Используйте StringComparison, чтобы ясно указать намерение.

            #region Russain-Only Obsense
            if (msg.Contains("хуе") || msg.Contains("хуй"))
                return true;
            else if (msg.Contains("член"))
                return true;
            else if (msg.Contains("бля"))
                return true;
            else if (msg.Contains("пиз"))
                return true;
            else if (msg.Contains("еб") || msg.Contains("ёб"))
                return true;
            #endregion

            #region Russian-English One-Design Obsense
            if (msg.Contains("xye") || msg.Contains("xyй"))
                return true;
            else if (msg.Contains("члeн"))
                return true;
            else if (msg.Contains("eб"))
                return true;
            #endregion

            #region Russian-English Translit Obsense
            if (msg.Contains("xyi"))
                return true;
            else if (msg.Contains("chlen"))
                return true;
            else if (msg.Contains("blya"))
                return true;
            else if (msg.Contains("piz"))
                return true;
            else if (msg.Contains("eb"))
                return true;
            #endregion

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
