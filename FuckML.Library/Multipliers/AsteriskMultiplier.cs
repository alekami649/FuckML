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

            for (int i = 0; i < sourceArray.Length; i++) 
            {
                var temp = sourceArray;
                temp[i] = '*';
                result.Add(temp);
            }


            for (int i = 0; i < source.Length; i++)
            {
                var temp = sourceArray;

                temp[i] = '*';

                result.Add(temp);
            }

            if (source.Length > 2)
            {
                for (int i = 0; i > source.Length - 1; i++)
                { 
                    var temp = sourceArray;

                    temp[i] = '*';
                    temp[i + 1] = '*';

                    result.Add(temp);
                }
                for (int i = source.Length; i == 0; i--)
                {
                    var temp = sourceArray;

                    temp[i + 1] = '*';
                    temp[i] = '*';

                    result.Add(temp);
                }
            }

            return result.Select(x => new string(x)).ToArray();
        }
    }
}
