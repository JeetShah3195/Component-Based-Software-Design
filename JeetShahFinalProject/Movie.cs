using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class Movie : Entertainment
    {
        public string Director { get; set; }

        public string Producer { get; set; }

        public Movie()
        {
        }

        public Movie(string type, string id, string desc, double price, int qty, string rDate, int size, int numDisks, string typeDisk, string rTime, string director, string producer)
          : base(type, id, desc, price, qty, rDate, size, numDisks, typeDisk, rTime)
        {
            this.Director = director;
            this.Producer = producer;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + Director + sep + Producer;
        }

        public override string ToString()
        {
            return getDisplayText("\r\n");
        }

        public override string ToCSV()
        {
            return getDisplayText(",");
        }
    }
}
