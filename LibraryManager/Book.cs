using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    class Book : IComparable
    {
        public string name { set; get; }
        public string author { set; get; }
        public string year { set; get; }

        public override string ToString()
        {
            return string.Format("<<{0}>> by {1}, {2}",
                name,
                author,
                year);
        }
         int IComparable.CompareTo(object obj)
        {
            Book book = (Book)obj;
            return string.Compare(author, book.author);
        }

        
    }
}
