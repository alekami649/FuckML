using FuckML.Searchers;
using IronOcr;

namespace FuckML.ImageSearchers
{
    public class RootImageSearcher : IImageSearcher
    {
        public RootImageSearcher()
        {
            tesseract = new();
            tesseract.AddSecondaryLanguage(OcrLanguage.Russian);

            searcher = new();
        }

        IronTesseract tesseract = new();
        RootSearcher searcher = new();

        public bool ContainsObsense(byte[] bytes)
        {
            var input = new OcrInput(bytes);
            input.Dispose();
            var text = tesseract.Read(input).Text;
            return searcher.ContainsObscene(text);
        }

        public bool ContainsObsense(string path)
        {
            var input = new OcrInput(path);
            input.Dispose();
            var text = tesseract.Read(input).Text;
            return searcher.ContainsObscene(text);
        }
    }
}
