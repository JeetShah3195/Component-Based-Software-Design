using System;
using System.Collections;
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
    public partial class frmSearch : Form
    {
        ArrayList productList = new ArrayList();

        public frmSearch()
        {
            InitializeComponent();
        }

        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Text = "Search";
        }

        // Event handler for button Search
        // Search for product description based on a keyword search 
        //using SelectLikeDesc method.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search" && txtSearch.Text != "")
            {
                lstSearch.Items.Clear();
                productList = ProductDB.SelectLikeDesc(txtSearch.Text);
                if (productList.Count != 0)
                {
                    foreach (Product product in productList)
                    {
                        if (product != null)
                        {
                            lstSearch.Items.Add((object)product.ToString());
                            btnSearch.Text = "Copy ID to POS";
                        }
                    }
                }
                else
                {
                    int num = (int)MessageBox.Show("No records found.");
                }
            }
            else
            {
                if (!(btnSearch.Text == "Copy ID to POS"))
                    return;
                if (lstSearch.SelectedIndex >= 0)
                {
                    this.Tag = productList[lstSearch.SelectedIndex];
                    this.Close();
                }
                else
                {
                    int num = (int)MessageBox.Show("No item selected.");
                }
            }

        }

        //Exit form and uses tag property to get data
        private void btnExit_Click(object sender, EventArgs e)
        {
            productList = null;
            this.Tag = productList;
            this.Close();
        }
    }
}
