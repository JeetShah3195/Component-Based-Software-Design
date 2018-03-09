using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class Media : Product
    {
        private DateTime releaseDate;

        public Media()
        {
        }

        public Media(string type, string id, string desc, double price, int qty, string rDate)
          : base(type, id, desc, price, qty)
        {
            this.ReleaseDate = rDate;
        }

        public string ReleaseDate
        {
            get
            {
                return releaseDate.ToShortDateString();
            }
            set
            {
                releaseDate = DateTime.Parse(value);
            }
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + this.ReleaseDate;
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
