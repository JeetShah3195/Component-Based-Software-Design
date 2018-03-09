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
    public partial class frmDescription : Form
    {
        public frmDescription()
        {
            InitializeComponent();
        }
        
        // Loads form Description
        private void frmDescription_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                return;
            }
            drawProduct((Product)this.Tag);
        }

        // This method sets visibility for the textboxes/lables depending on the class it calls
        public void drawSet(bool bool1, bool bool2, bool bool3, bool bool4, bool bool5, bool bool6, bool bool7, bool bool8)
        {
            lblVar1.Visible = bool1;
            txtVar1.Visible = bool1;
            lblVar2.Visible = bool2;
            txtVar2.Visible = bool2;
            lblVar3.Visible = bool3;
            txtVar3.Visible = bool3;
            lblVar4.Visible = bool4;
            txtVar4.Visible = bool4;
            lblVar5.Visible = bool5;
            txtVar5.Visible = bool5;
            lblVar6.Visible = bool6;
            txtVar6.Visible = bool6;
            lblVar7.Visible = bool7;
            txtVar7.Visible = bool7;
            lblVar8.Visible = bool8;
            txtVar8.Visible = bool8;

        }
        // Clears out. drawSet set to false
        public void showClear()
        {
            drawSet(false, false, false, false, false, false, false, false);
            txtType.Text = "";
            txtID.Text = "";
            txtDesc.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            lblVar1.Text = "";
            lblVar2.Text = "";
            lblVar3.Text = "";
            lblVar4.Text = "";
            lblVar5.Text = "";
            lblVar6.Text = "";
            lblVar7.Text = "";
            lblVar8.Text = "";
        }
        //This method makes product form based on product type
        private void drawProduct(Product p)
        {
            txtType.Text = p.Type;
            txtID.Text = p.ID;
            txtDesc.Text = p.Desc;
            txtPrice.Text = p.Price.ToString("C");
            txtQuantity.Text = p.Qty.ToString();
            if (p.Type == "Book")
                drawBook(p);
            else if (p.Type == "Software")
                drawSoftware(p);
            else if (p.Type == "Music")
                drawMusic(p);
            else if (p.Type == "Movie")
                drawMovie(p);
            else if (p.Type == "Pants")
                drawPants(p);
            else if (p.Type == "TShirt")
                drawTShirt(p);
            else if (p.Type == "DressShirt")
            {
                drawDressShirt(p);
            }
            else
            {
                int num = (int)MessageBox.Show("Not found.");
            }
        }
        // Draw media based on type media
        private void drawMedia(Product p)
        {
            Media media = (Media)p;
            lblVar1.Text = "Release Date";
            txtVar1.Text = media.ReleaseDate;
        }
        
        // Draw Apparel based on type apparel
        private void drawApparel(Product p)
        {
            Apparel apparel = (Apparel)p;
            lblVar1.Text = "Color";
            txtVar1.Text = apparel.Color;
            lblVar2.Text = "Manufacturer";
            txtVar2.Text = apparel.Manufacturer;
            lblVar3.Text = "Material";
            txtVar3.Text = apparel.Material;
        }

        // Draw Disk based on type Disk
        private void drawDisk(Product p)
        {
            Disk disk = (Disk)p;
            drawMedia(p);
            lblVar2.Text = "Number of Disks";
            txtVar2.Text = disk.NumDisks.ToString();
            lblVar3.Text = "Data Size";
            txtVar3.Text = disk.Size.ToString();
            lblVar4.Text = "Type Disk";
            txtVar4.Text = disk.TypeDisk;
        }

        // Draw Entertainment based on type Entertainment
        private void drawEntertainment(Product p)
        {
            Entertainment entertainment = (Entertainment)p;
            drawDisk(p);
            lblVar5.Text = "Runtime";
            txtVar5.Text = entertainment.RunTime;
        }

        // Draw Book based on type Book
        private void drawBook(Product p)
        {
            Book book = (Book)p;
            drawSet(true, true, true, true, false, false, false, false);
            drawMedia(p);
            lblVar2.Text = "Pages";
            txtVar2.Text = book.NumPages.ToString();
            lblVar3.Text = "Author";
            txtVar3.Text = book.Author;
            lblVar4.Text = "Publisher";
            txtVar4.Text = book.Publisher;
        }

        // Draw Software based on type Software
        private void drawSoftware(Product p)
        {
            Software software = (Software)p;
            drawSet(true, true, true, true, true, false, false, false);
            drawDisk(p);
            lblVar5.Text = "Type Software";
            txtVar5.Text = software.TypeSoft;
        }

        // Draw Music based on type Music
        private void drawMusic(Product p)
        {
            Music music = (Music)p;
            drawSet(true, true, true, true, true, true, true, true);
            drawEntertainment(p);
            lblVar6.Text = "Artist";
            txtVar6.Text = music.Artist;
            lblVar7.Text = "Label";
            txtVar7.Text = music.Label;
            lblVar8.Text = "Genre";
            txtVar8.Text = music.Genre;
        }

        // Draw Movie based on type Movie
        private void drawMovie(Product p)
        {
            Movie movie = (Movie)p;
            drawSet(true, true, true, true, true, true, true, false);
            drawEntertainment(p);
            lblVar6.Text = "Director";
            txtVar6.Text = movie.Director;
            lblVar7.Text = "Producer";
            txtVar7.Text = movie.Producer;
        }

        // Draw Pants based on type Pants
        private void drawPants(Product p)
        {
            Pants pants = (Pants)p;
            drawSet(true, true, true, true, true, false, false, false);
            drawApparel(p);
            lblVar4.Text = "Waist";
            txtVar4.Text = pants.Waist.ToString();
            lblVar5.Text = "Inseam";
            txtVar5.Text = pants.Inseam.ToString();
        }

        // Draw DressShirt based on type DressShirt
        private void drawDressShirt(Product p)
        {
            DressShirt dressShirt = (DressShirt)p;
            drawSet(true, true, true, true, true, false, false, false);
            drawApparel(p);
            lblVar4.Text = "Neck";
            txtVar4.Text = dressShirt.Neck.ToString();
            lblVar5.Text = "Sleeve";
            txtVar5.Text = dressShirt.Sleeve.ToString();
        }

        // Draw TShirt based on type TShirt
        private void drawTShirt(Product p)
        {
            TShirt tshirt = (TShirt)p;
            drawSet(true, true, true, true, false, false, false, false);
            drawApparel(p);
            lblVar4.Text = "Size";
            txtVar4.Text = tshirt.Size.ToString();
        }
        
        // Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
