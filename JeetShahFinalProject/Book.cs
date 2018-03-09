using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class Book : Media
    {
        // Instance fields
        public int NumPages { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public Book()
        {
        }

        // Constructor
        public Book(string type, string id, string desc, double price, int qty, string rDate, int numPages, string author, string publisher)
          : base(type, id, desc, price, qty, rDate)
        {
            this.NumPages = numPages;
            this.Author = author;
            this.Publisher = publisher;
        }
        
        // Get display text
        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + NumPages + sep + Author + sep + Publisher;
        }
        
        //Book ToString
        public override string ToString()
        {
            return getDisplayText("\r\n");
        }
        
        // Get a CSV string
        public override string ToCSV()
        {
            return getDisplayText(",");
        }
    }
}
