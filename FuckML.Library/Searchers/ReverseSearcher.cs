namespace FuckML.Searchers
{
    public class ReverseSearcher : ISearcher
    {
        public RootSearcher rootSearcher { get; set; } = new();
        public bool ContainsObscene(string msg)
            => rootSearcher.ContainsObscene(new(msg.Reverse().ToArray()));
    }
}
