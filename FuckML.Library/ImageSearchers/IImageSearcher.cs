namespace FuckML.ImageSearchers
{
    public interface IImageSearcher
    {
        public bool ContainsObsense(string path);
        public bool ContainsObsense(byte[] bytes);
    }
}
