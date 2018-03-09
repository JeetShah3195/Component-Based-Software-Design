using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class Apparel : Product
    {
        // Instance fields
        public string Material { get; set; }

        public string Color { get; set; }

        public string Manufacturer { get; set; }

        public Apparel()
        {
        }

        // Constructor
        public Apparel(string type, string id, string desc, double price, int qty, string material, string color, string manufacturer)
          : base(type, id, desc, price, qty)
        {
            this.Material = material;
            this.Color = color;
            this.Manufacturer = manufacturer;
        }

        // Get display text
        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + Material + sep + Color + sep + Manufacturer;
        }

        //Apparel ToString
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

