using FuckML.Searchers;
using IronOcr;

#pragma warning disable CA1304 // Укажите CultureInfo

namespace FuckML.ImageSearchers
{
    public class QuickImageSearcher : IImageSearcher
    {
        /// <summary>
        /// Creates an instance of <see cref="QuickImageSearcher"/>
        /// </summary>
        public QuickImageSearcher()
        {
            tesseract = new();
            tesseract.AddSecondaryLanguage(OcrLanguage.RussianFast);

            quickSearcher = new();
        }


        /// <summary>
        /// Creates an instance of <see cref="QuickImageSearcher"/>
        /// </summary>
        /// <param name="fastOrDetail">If true -> detail searching, false -> fast searching</param>
        public QuickImageSearcher(bool fastOrDetail)
        {
            tesseract = new();
            tesseract.AddSecondaryLanguage(fastOrDetail ? OcrLanguage.RussianBest
                                                        : OcrLanguage.RussianFast);

            quickSearcher = new();
        }

        readonly IronTesseract tesseract = new();
        readonly QuickSearcher quickSearcher = new();

        public bool ContainsObsense(byte[] bytes)
        {
            var input = new OcrInput();
            input.Dispose();
            input.Add(bytes);
            input = input.SelectTextColor(IronSoftware.Drawing.Color.White);
            var text = tesseract.Read(input).Text;
            return quickSearcher.ContainsObscene(text.ToLower());
        }

        public bool ContainsObsense(string path)
        {
            return ContainsObsense(File.ReadAllBytes(path));
        }
    }
}
