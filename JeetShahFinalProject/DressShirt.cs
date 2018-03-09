using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class DressShirt : Apparel
    {
        public double Neck { get; set; }

        public double Sleeve { get; set; }

        public DressShirt()
        {
        }

        public DressShirt(string type, string id, string desc, double price, int qty, string material, string color, string manufacturer, double neck, int sleeve)
          : base(type, id, desc, price, qty, material, color, manufacturer)
        {
            this.Neck = neck;
            this.Sleeve = sleeve;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + Neck + sep + Sleeve;
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
