using System.Collections.Generic;
using System.Linq;
using PdfCreator.Analizers;
using PdfCreator.Interfaces;
using PdfCreator.Services;

namespace PdfCreator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string directoryPath = @"C:\Users\Egor\Desktop\ВНО\PdfFiles";
            const string outputPath = @"C:\Users\Egor\Desktop\output.pdf";

            List<string> fileNames = DirectoryAnalizer.GetFileNames(directoryPath).ToList();
            PdfServise pdfServise = new PdfServise();
            Album album = new AlbumCreator().GetAlbum(pdfServise.GetImportedPages(fileNames));
            pdfServise.Create(album, outputPath);
        }
    }

    
}


