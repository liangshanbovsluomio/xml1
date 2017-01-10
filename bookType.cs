using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    class bookType
    {
        public bookType() { }
        public bookType(int bookId,string bookName, int price, string describetion)
        {
            this.BookID = bookId;
            this.BookName = bookName;
            this.Price = price;
            this.Describetion = describetion;
        }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }

        public string Describetion { get; set; }
    }
}
