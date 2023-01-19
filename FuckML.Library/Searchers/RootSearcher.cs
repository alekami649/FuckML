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

            #region Russain-Only Obsense
            if (msg.Contains("хуе") || msg.Contains("хуй") || msg.Contains("нах"))
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

            #region Russain-Only Asterisk Obsense
            if (msg.Contains("*уе") || msg.Contains("х*е") || msg.Contains("ху*"))
                return true;
            else if (msg.Contains("*уй") || msg.Contains("х*й") || msg.Contains("ху*"))
                return true;
            else if (msg.Contains("*лен") || msg.Contains("ч*ен")  || msg.Contains("чл*н") || msg.Contains("чле*"))
                return true;
            else if (msg.Contains("*ля") || msg.Contains("б*я") || msg.Contains("бл*"))
                return true;
            else if (msg.Contains("п**") || msg.Contains("п*з") || msg.Contains("пи*"))
                return true;
            else if (msg.Contains("е*") || msg.Contains("ё*") || msg.Contains("*б"))
                return true;
            #endregion

            #region Russian-English One-Design Obsense
            if (msg.Contains("xye") || msg.Contains("xyй") || msg.Contains("нaх"))
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
