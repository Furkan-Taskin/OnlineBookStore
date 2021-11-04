using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Book_Store
{
    public partial class ProductForm : Form
    {
        public static Book productBook;
        public static Magazine productMagazine;
        public static MusicCD productMusicCD;
        public enum ProductType { BOOK, MAGAZINE, MUSICCD }
        public static ProductType productType;
        private ShoppingCart shoppingCart;

        public ProductForm()
        {
            InitializeComponent();
             shoppingCart = ShoppingCart.Instance;

            switch (productType)
            {
                case ProductType.BOOK:
                    {
                        //productBook = new Book();
                        this.lblAuthor.Text = productBook.Author;
                        this.lblISBN.Text = productBook.IsbnNumber;
                        this.lblPage.Text = productBook.Page.ToString() + " pages";
                        this.lblProductName.Text = productBook.Name;
                        this.lblPublisher.Text = productBook.Publisher;
                        this.lblPrice.Text = "$" + productBook.Price.ToString();
                        this.pctProduct.Image = productBook.Image;
                        this.rchDescription.Text = productBook.Description;
                        break;
                    }
                case ProductType.MAGAZINE:
                    {
                        //productBook = new Book();
                        this.lblAuthor.Text = productMagazine.Issue;
                        this.lblISBN.Visible = false;
                        //this.lblISBN.Text = productMagazine.Type.ToString();
                        //this.lblPage.Text = productMagazine.Type.ToString();
                        this.lblPage.Visible = false;
                        this.lblProductName.Text = productMagazine.Name;
                        this.lblPublisher.Text = productMagazine.Type.ToString();                     
                        this.lblPrice.Text = "$" + productMagazine.Price.ToString();
                        this.pctProduct.Image = productMagazine.Image;
                        this.rchDescription.Text = productMagazine.Description;
                        break;
                    }
                case ProductType.MUSICCD:
                    {
                        //productBook = new Book();
                        this.lblAuthor.Text = productMusicCD.Singer;
                        this.lblISBN.Visible = false;
                        //this.lblISBN.Text = productMagazine.Type.ToString();
                        //this.lblPage.Text = productMagazine.Type.ToString();
                        this.lblPage.Visible = false;
                        this.lblProductName.Text = productMusicCD.Name;
                        this.lblPublisher.Text = productMusicCD.Type.ToString();                     
                        this.lblPrice.Text = "$" + productMusicCD.Price.ToString();
                        this.pctProduct.Image = productMusicCD.Image;
                        this.rchDescription.Text = productMusicCD.Description;
                        break;
                    }

            }

        }

        private void pctExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDecreament_Click(object sender, EventArgs e)
        {
            if(txtCount.Text == string.Empty)
            {
                return;
            }
            if (Convert.ToInt32(txtCount.Text) != 1)
            {
                int count = Convert.ToInt32(txtCount.Text);
                count--;
                txtCount.Text = count.ToString();
            }
        }

        private void btnIncrement_Click(object sender, EventArgs e)
        {
            if (txtCount.Text == string.Empty)
            {
                return;
            }
            int count = Convert.ToInt32(txtCount.Text);
            count++;
            txtCount.Text = count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCount.Text == string.Empty)
            {
                return;
            }
            switch (productType)
            {
                case ProductType.BOOK:
                    {
                        shoppingCart.AddProduct(productBook, Convert.ToInt32(txtCount.Text));
                        break;
                    }
                case ProductType.MAGAZINE:
                    {
                        shoppingCart.AddProduct(productMagazine, Convert.ToInt32(txtCount.Text));
                        break;
                    }
                case ProductType.MUSICCD:
                    {
                        shoppingCart.AddProduct(productMusicCD, Convert.ToInt32(txtCount.Text));
                        break;
                    }

            }
            this.Close();
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {
            if(txtCount.Text == "0")
            {
                txtCount.Text = "1";
            }
        }
    }
}
