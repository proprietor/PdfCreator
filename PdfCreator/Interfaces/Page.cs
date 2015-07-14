using iTextSharp.text.pdf;
using PdfCreator.Models;

namespace PdfCreator.Interfaces
{
    public abstract class Page
    {
        public PdfImportedPage Image { get; set; }

        public TextForPage TextForPage { get; set; }
    }
}
