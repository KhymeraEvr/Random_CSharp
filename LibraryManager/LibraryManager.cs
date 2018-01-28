using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibraryManager
{
    class LibraryManager
    {
        private List<Book> _library;
        private string _filePath;

        public LibraryManager()
        {
            _library = new List<Book>();
            _filePath = "";
        }

        public LibraryManager(string filePath)
        {
            _filePath = filePath;
            _library = new List<Book>();
        }

        public void Add(Book newBook)
        {
            _library.Add(newBook);
        }

        public bool Remove(Book book)
        {
            if (_library.Contains(book))
            {
                _library.Remove(book);
                return true;
            }
            else return false;
        }

        public Book Search(string name, string author)
        {
            foreach (Book book in _library)
            {
                if (book.name == name && book.author == author) return book;
            }
            return null;
        }

        public bool ReadBooksFromFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            if (!File.Exists(filePath))
            {
                return false;
            }

            while (!sr.EndOfStream)
            {
                AddBook(sr.ReadLine());
            }
            return true;
            sr.Close();
        }

        public void Print()
        {
            _library.Sort();
            StreamWriter sw = File.CreateText(_filePath);
            foreach (Book bk in _library)
            {
                sw.WriteLine(bk.ToString());
            }
            sw.Close();
        }

        private void AddBook(string line)
        {
            string[] data = line.Split('|');
            Book bk = new Book();
            bk.name = data[0];
            bk.author = data[1];
            bk.year = data[2];

            _library.Add(bk);
        }

        public void formatToXML()
        {
            XmlDocument xmlLibr = new XmlDocument();
            XmlDeclaration xmlDecl = xmlLibr.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlLibr.AppendChild(xmlDecl);
            XmlElement xmlLibrary = xmlLibr.CreateElement("library");
            foreach(Book bk in _library)
            {
                XmlElement bookElement = xmlLibr.CreateElement("book");
                XmlElement authorElemnet = xmlLibr.CreateElement("author");
                authorElemnet.InnerText = bk.author;
                XmlElement yearElement = xmlLibr.CreateElement("year");
                yearElement.InnerText = bk.year;
                XmlElement titleElement = xmlLibr.CreateElement("name");
                titleElement.SetAttribute("language", "en");
                XmlCDataSection titleSection = xmlLibr.CreateCDataSection(bk.name);
                titleElement.AppendChild(titleSection);

                bookElement.AppendChild(authorElemnet);
                bookElement.AppendChild(yearElement);
                bookElement.AppendChild(titleElement);
                xmlLibrary.AppendChild(bookElement);
            }
            xmlLibr.AppendChild(xmlLibrary);
            xmlLibr.Save("library.xml");
        }

    }
    class LibraryExceptions : Exception
    {
        public string message;
    }
}
