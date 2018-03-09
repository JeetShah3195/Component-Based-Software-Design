using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeetShahFinalProject
{
    public partial class frmMain : Form
    {
        private Transaction trans;

        public frmMain()
        {
            InitializeComponent();
        }
        //Event handler for button Get Description
        private void btnGetDescription_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text != "")
            {

                Product product = ProductDB.SelectProduct(txtProductID.Text);
                Product product2 = null;

                if (product != null)
                {
                    MessageBox.Show("Product: " + product.ToString());
                    if (product.Type == "Movie")
                        product2 = ProductDB.SelectMovie(product.ID);
                    if (product.Type == "Music")
                        product2 = ProductDB.SelectMusic(product.ID);
                    if (product.Type == "Software")
                        product2 = ProductDB.SelectSoftware(product.ID);
                    if (product.Type == "Pants")
                        product2 = ProductDB.SelectPants(product.ID);
                    if (product.Type == "DressShirt")
                        product2 = ProductDB.SelectDressShirt(product.ID);
                    if (product.Type == "TShirt")
                        product2 = ProductDB.SelectTShirt(product.ID);
                    if (product.Type == "Book")
                        product2 = ProductDB.SelectBook(product.ID);
                }

                if (product2 != null)
                {
                    Form frm = new frmDescription();
                    frm.Tag = product2;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Product: " + txtProductID.Text + " not found. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Product ID is empty. Please enter in a valid Product ID.");
            }
        }
        // Event handler for button Add Product
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            int qty = 0;
            try
            {
                if (txtProductID.Text != "")
                {
                    if (txtQuantity.Text != "" && Convert.ToInt32(txtQuantity.Text) > 0)
                    {
                        try
                        {
                            qty = Convert.ToInt32(txtQuantity.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return;
                        }
                        Product p = ProductDB.SelectProduct(txtProductID.Text);
                        if (p != null)
                        {
                            double total = p.Price * qty;
                            lstScreen.Items.Add((p.ID + "  " + p.Desc + "  " + qty + " @ " + p.Price.ToString("C") + " -> " + total.ToString("C")));
                            trans.Add(p, qty);
                            txtProductID.Clear();
                            txtQuantity.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantity is empty or less than 0. Please enter in a value greater than 0.");
                    }

                }
                else
                {
                    MessageBox.Show("Product ID is empty. Please enter in a valid Product ID.");
                }
            }
            catch
            {
                MessageBox.Show("Not a valid format. Format Error");
            }

        }

        // Event handler for button Remove Product
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (lstScreen.SelectedIndex >= 0)
            {
                trans.RemoveAt(lstScreen.SelectedIndex);
                lstScreen.Items.RemoveAt(lstScreen.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Unable to remove product, no product selected. Please select a product.");
            }
        }

        // Event handler for button Cancel sale
        private void btnCancel_Click(object sender, EventArgs e)
        {
            trans.Clear();
            lstScreen.Items.Clear();
        }
        // Event handler for button Enter Sale
        private void btnEnter_Click(object sender, EventArgs e)
        {
            double subtotal = 0.0;
            double tax = 0.06;
            if (lstScreen.Items.Count > 0)
            {
                for (int i = 0; i < lstScreen.Items.Count; i++)
                {
                    subtotal += trans.ProductAt(i).Price * trans.QtyOfProductsAt(i);
                }

                tax = tax * subtotal;
                double total = tax + subtotal;

                ProductDB.InsertTrans(subtotal, tax, total);
                int transID = ProductDB.SelectMaxTrans();

                string receiptStr = "Jeet's Mart Recipt\r\n\r\n\r\n" +
                    DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString() + "\r\n\r\n\r\n";

                for (int i = 0; i < lstScreen.Items.Count; i++)
                {
                    int qty = trans.ProductAt(i).Qty - trans.QtyOfProductsAt(i);
                    ProductDB.InsertLineItem(transID, trans.ProductAt(i).ID, trans.QtyOfProductsAt(i), trans.ProductAt(i).Price);
                    ProductDB.UpdateProduct(trans.ProductAt(i).ID, qty);
                    receiptStr += trans.ProductAt(i).ID + "  " + trans.ProductAt(i).Desc + "  " + trans.QtyOfProductsAt(i) + " @ "
                        + trans.ProductAt(i).Price.ToString("C") + " -> "
                        + (trans.ProductAt(i).Price * trans.QtyOfProductsAt(i)).ToString("C") + "\r\n";
                }

                receiptStr += "\r\nSubtotal\t\t\t\t" + subtotal.ToString("C") + "\r\nTax\t\t\t\t" + tax.ToString("C") + "\r\nTotal\t\t\t\t" + total.ToString("C");
                txtReceipt.Text = receiptStr;
                trans.Clear();
                lstScreen.Items.Clear();
            }
            else
            {
                MessageBox.Show("lstScreen is empty. Add products before entering in a sale.");
                return;
            }
        }

        // Event handler for button Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form form = new frmSearch();
            form.ShowDialog();
            if (form.Tag != null)
            {
                txtProductID.Text = ((Product)form.Tag).ID;
            }
            else
            {
                return;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.trans = new Transaction();
        }

        private void txtReceipt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
