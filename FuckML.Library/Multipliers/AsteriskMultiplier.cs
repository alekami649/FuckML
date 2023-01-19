namespace FuckML.Multipliers
{
    public class AsteriskMultiplier : IMultiplier
    {
        public string[] MultiplyString(string source)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentNullException(nameof(source));

            var result = new List<char[]>();
            
            var sourceArray = source.ToArray();

            result.Add(sourceArray);

            return result.Select(x => new string(x)).ToArray();
        }
    }
}
