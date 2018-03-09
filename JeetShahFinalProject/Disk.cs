using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class Disk : Media
    {
        // Instance fields
        public int Size { get; set; }

        public int NumDisks { get; set; }

        public string TypeDisk { get; set; }

        public Disk()
        {
        }

        // Constructor
        public Disk(string type, string id, string desc, double price, int qty, string rDate, int size, int numDisks, string typeDisk)
          : base(type, id, desc, price, qty, rDate)
        {
            this.Size = size;
            this.NumDisks = numDisks;
            this.TypeDisk = typeDisk;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + Size + sep + NumDisks + sep + TypeDisk;
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
