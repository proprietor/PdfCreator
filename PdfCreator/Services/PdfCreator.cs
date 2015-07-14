using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfCreator.Interfaces;
using PdfCreator.Models;

namespace PdfCreator.Services
{
    public class PdfServise
    {
        public void Create(Album album, string outputPdfPath)
        {
            Document document = new Document();

            PdfCopy pdfCopyProvider = new PdfCopy(document,
                new FileStream(outputPdfPath, FileMode.Create));

            document.Open();
            foreach (Page page in album.Pages)
            {
                AddTextForPage(pdfCopyProvider, page.Image, page.TextForPage);
                pdfCopyProvider.AddPage(page.Image);
            }
            document.Close();
        }

        /// <summary>
        /// Merge pdf files.
        /// </summary>
        /// <param name="inFiles">List of file paths to merge.</param>
        public IList<PdfImportedPage> GetImportedPages(List<String> inFiles)
        {
            List<PdfImportedPage> pages = new List<PdfImportedPage>();
            {
                foreach (string file in inFiles)
                {
                    pages.AddRange(ExtractPagesFromFile(file));
                }
            }
            return pages;
        }

        private IList<PdfImportedPage> ExtractPagesFromFile(string sourcePdfPath)
        {
            IList<PdfImportedPage> pages = new List<PdfImportedPage>();

            PdfReader reader = new PdfReader(sourcePdfPath);
            PdfCopy pdfCopyProvider = new PdfCopy(new Document(), new MemoryStream());
            for (int i = 0; i < reader.NumberOfPages; i++)
            {
                pages.Add(pdfCopyProvider.GetImportedPage(reader, i + 1));
            }
            return pages;
        }      

        private void AddTextForPage(PdfCopy pdfCopyProvider, PdfImportedPage importedPage, TextForPage textForPage)
        {
            PdfCopy.PageStamp stamper = pdfCopyProvider.CreatePageStamp(importedPage);

            ColumnText.ShowTextAligned(stamper.GetOverContent(), Element.ALIGN_CENTER, new Phrase(textForPage.PageNubmer,
                new Font()), 820f, 15, 0);
            stamper.AlterContents();

            AddParagraph(stamper, textForPage.Header, importedPage.Width / 2,
                importedPage.Height - 30, Element.ALIGN_CENTER, 1);

            AddParagraph(stamper, textForPage.Footer, importedPage.Width / 2,
                30, Element.ALIGN_CENTER, 1);

            stamper.AlterContents();
        }

        private void AddParagraph(PdfCopy.PageStamp pageStamp,
            string text, float x, float y, int alignElement, float rotation)
        {
            ColumnText.ShowTextAligned(pageStamp.GetOverContent(), alignElement,
                new Phrase(text), x, y, rotation);
        }
    }
}
