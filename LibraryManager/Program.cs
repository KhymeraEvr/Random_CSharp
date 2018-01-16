using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryManager lm = new LibraryManager("C:\\Users\\bogda\\onedrive\\документы\\visual studio 2017\\Projects\\LibraryManager\\LibraryManager\\Library.txt");
            lm.ReadBooksFromFile("C:\\Users\\bogda\\onedrive\\документы\\visual studio 2017\\Projects\\LibraryManager\\LibraryManager\\Books.txt");
            lm.Print();
        }
    }
}
