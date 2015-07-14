using System.Collections.Generic;
using PdfCreator.Interfaces;

namespace PdfCreator.Models
{
    public class Album412 : Album
    {
        public Album412(IList<Page> pages)
        {
            this.Pages = pages;
        }

        public Album412()
        {
        }
    }
}
