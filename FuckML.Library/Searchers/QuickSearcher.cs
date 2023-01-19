using FuckML.Converters;

namespace FuckML.Searchers
{
    public class QuickSearcher : ISearcher
    {
        public ReverseSearcher reverseSearcher { get; set; } = new();
        public RootSearcher rootSearcher { get; set; } = new();

        public SpaceConverter spaceConverter { get; set; } = new();
        public DotConverter dotConverter { get; set; } = new();

        public bool ContainsObscene(string msg)
        {
            msg = spaceConverter.Convert(msg);
            msg = dotConverter.Convert(msg);

            if (reverseSearcher.ContainsObscene(msg) || rootSearcher.ContainsObscene(msg))
                return true;

            return false;
        }
    }
}
