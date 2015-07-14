using System.Collections.Generic;

namespace PdfCreator.Interfaces
{
    public abstract class Album
    {
        protected Album()
        {
            Pages = new List<Page>();
        }

        public IList<Page> Pages { get; set; }
    }
}
