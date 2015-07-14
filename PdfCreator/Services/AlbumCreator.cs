using System.Collections.Generic;
using iTextSharp.text.pdf;
using PdfCreator.Interfaces;
using PdfCreator.Models;

namespace PdfCreator.Services
{
    public class AlbumCreator
    {
        public Album GetAlbum(IList<PdfImportedPage> importedPages)
        {
            Album album = new Album412();
            FillAlbum(importedPages, album);
            return album;
        }

        private void FillAlbum(IList<PdfImportedPage> importedPages, Album album)
        {
            int i = 0;
            foreach (PdfImportedPage importedPage in importedPages)
            {
                string header = "header" + i;
                string footer = "footer" + i;
                string pageNumber = (i + 1).ToString();
                i++;
                TextForPage textForPage = new TextForPage() { Footer = footer, Header = header, PageNubmer = pageNumber };
                album.Pages.Add(new Models.PdfPage()
                {
                    TextForPage = textForPage,
                    Image = importedPage,
                });
            }
        }
    }
}
