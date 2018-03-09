using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeetShahFinalProject
{
    class Transaction
    {
        private List<Product> lineItems;
        private List<int> qtyOfProducts;

        public Transaction()
        {
            lineItems = new List<Product>();
            qtyOfProducts = new List<int>();
        }

        public Product ProductAt(int i)
        {
            return lineItems[i];
        }

        public int QtyOfProductsAt(int i)
        {
            return qtyOfProducts[i];
        }

        public void Add(Product p, int q)
        {
            lineItems.Add(p);
            qtyOfProducts.Add(q);
        }

        public void RemoveAt(int i)
        {
            lineItems.RemoveAt(i);
            qtyOfProducts.RemoveAt(i);
        }

        public void Clear()
        {
            lineItems.Clear();
            qtyOfProducts.Clear();
        }
    }
}

