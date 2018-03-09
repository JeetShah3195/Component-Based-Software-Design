using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class Software : Disk
    {
        public string TypeSoft { get; set; }

        public Software()
        {
        }

        public Software(string type, string id, string desc, double price, int qty, string rDate, int size, int numDisks, string typeDisk, string typeSoft)
          : base(type, id, desc, price, qty, rDate, size, numDisks, typeDisk)
        {
            this.TypeSoft = typeSoft;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + TypeSoft;
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

