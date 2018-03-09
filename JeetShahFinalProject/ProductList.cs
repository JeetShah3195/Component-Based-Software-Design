using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeetShahFinalProject
{
    class ProductList : List<Product>
    {
        public void Add(string[] index)
        {
            if (index[0] == "Book")

                this.Add(new Book(index[0], index[1], index[2], double.Parse(index[3]), int.Parse(index[4]), index[5], int.Parse(index[6]), index[7], index[8]));

            else if (index[0] == "DressShirt")

                this.Add(new DressShirt(index[0], index[1], index[2], double.Parse(index[3]), int.Parse(index[4]), index[5], index[6], index[7], (double)int.Parse(index[8]), int.Parse(index[9])));

            else if (index[0] == "Movie")

                this.Add(new Movie(index[0], index[1], index[2], double.Parse(index[3]), int.Parse(index[4]), index[5], int.Parse(index[6]), int.Parse(index[7]), index[8], index[9], index[10], index[11]));

            else if (index[0] == "Music")

                this.Add(new Music(index[0], index[1], index[2], double.Parse(index[3]), int.Parse(index[4]), index[5], int.Parse(index[6]), int.Parse(index[7]), index[8], index[9], index[10], index[11], index[12]));

            else if (index[0] == "Pants")

                this.Add(new Pants(index[0], index[1], index[2], double.Parse(index[3]), int.Parse(index[4]), index[5], index[6], index[7], int.Parse(index[8]), int.Parse(index[9])));

            else if (index[0] == "Software")

                this.Add(new Software(index[0], index[1], index[2], double.Parse(index[3]), int.Parse(index[4]), index[5], int.Parse(index[6]), int.Parse(index[7]), index[8], index[9]));

            else if (index[0] == "TShirt")
            {
                this.Add(new TShirt(index[0], index[1], index[2], double.Parse(index[3]), int.Parse(index[4]), index[5], index[6], index[7], index[8]));
            }

            else
            {
                int num = (int)MessageBox.Show("Unknown type");


            }
        }
        public override string ToString()
        {
            string str = "";
            foreach (Product product in this)
                str = str + product.ToString() + "\r\n\r\n";
            return str;
        }

        public string ToCSV()
        {
            string str = "";
            foreach (Product product in this)
                str = str + product.ToCSV() + "\r\n";
            return str;
        }

        public int readFromFile(string fileName)
        {
            int num = 0;
            StreamReader streamReader = new StreamReader(fileName);
            string str;
            while ((str = streamReader.ReadLine()) != null)
            {
                this.Add(str.Split(','));
                ++num;
            }
            streamReader.Close();
            return num;
        }

        public int writeToFile(string fileName)
        {
            int num = 0;
            StreamWriter streamWriter = new StreamWriter(fileName);
            foreach (Product product in this)
            {
                streamWriter.WriteLine(product.ToCSV());
                ++num;
            }
            streamWriter.Close();
            return num;
        }

        public int writeToBinary(string fileName)
        {
            int num = 0;
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write));
            foreach (Product product in this)
            {
                binaryWriter.Write(product.ToCSV());
                ++num;
            }
            binaryWriter.Close();
            return num;
        }

        public int readFromBinary(string fileName)
        {
            int num = 0;
            BinaryReader binaryReader = new BinaryReader(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read));
            while (binaryReader.PeekChar() != -1)
            {
                this.Add(binaryReader.ReadString().Split(','));
                ++num;
            }
            binaryReader.Close();
            return num;
        }
    }

}

