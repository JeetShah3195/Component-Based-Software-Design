using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class Product
    {
        public string ID { get; set; }

        public string Desc { get; set; }

        public double Price { get; set; }

        public int Qty { get; set; }

        public string Type { get; set; }

 

        public Product()
        {
        }

        public Product(string type, string id, string desc, double price, int qty)
        {
            this.ID = id;
            this.Desc = desc;
            this.Price = price;
            this.Qty = qty;
            this.Type = type;
        }

        public virtual string getDisplayText(string sep)
        {
            return Type + sep + ID + sep + Desc + sep + Price + sep + Qty;
        }

        public override string ToString()
        {
            return getDisplayText("\r\n");
        }

        public virtual string ToCSV()
        {
            return getDisplayText(",");
        }
    }
}
