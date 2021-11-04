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
    public partial class MainForm : Form
    {
        private MyCartForm myCartForm;
        private User user;
        private bool check = true;
        private List<Product> allProducts = new List<Product>();

        public MainForm(User user)
        {
            InitializeComponent();
            labelName.Text = user.FullName;
            labelUsername.Text = user.UserName;
            timer.Start();


            this.user = user;
            allProducts = GetAllProducts();
        }

        private void pctExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm tt");
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private List<Product> foundedItems = new List<Product>();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                btnBooks_Click(null, null);
                txtSearch.Text = "Search";
                return;
            }

            pnlRed1.Visible = false;
            pnlRed2.Visible = false;
            pnlRed3.Visible = false;

            foreach (var item in allProducts)
            {
                if (item.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    foundedItems.Add(item);
                }
            }

            if (foundedItems.Count > 0)
                flwPanelProducts.Controls.Clear();

            foreach (var item in foundedItems)
            {
                if (item is Book)
                {
                    AddNewBookGroupToProductPanel(item);
                }
                else if (item is Magazine)
                {
                    AddNewMagazineGroupToProductPanel(item);
                }
                else if (item is MusicCD)
                {
                    AddNewMusicCDGroupToProductPanel(item);
                }
            }
            foundedItems.Clear();

        }

        private void pctLogout_Click(object sender, EventArgs e)
        {
            Application.OpenForms["LoginForm"].Show();

            this.Close();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = string.Empty;
            }
        }

        static int count = 0;
        private void AddNewBookGroupToProductPanel(Product _product)
        {
            Book product = (Book)_product;

            // lblProductName1
            // 
            Label lblProductName1 = new Label();
            lblProductName1.AutoSize = true;
            lblProductName1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblProductName1.ForeColor = System.Drawing.Color.White;
            lblProductName1.Location = new System.Drawing.Point(6, 202);
            lblProductName1.Name = "lblProductName" + product.Name;
            lblProductName1.Size = new System.Drawing.Size(90, 19);
            lblProductName1.TabIndex = 1;
            lblProductName1.Text = "Name: " + product.Name;
            // 
            // lblProductPrice1
            // 
            Label lblProductPrice1 = new Label();
            lblProductPrice1.AutoSize = true;
            lblProductPrice1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblProductPrice1.ForeColor = System.Drawing.Color.White;
            lblProductPrice1.Location = new System.Drawing.Point(6, 240);
            lblProductPrice1.Name = "lblProductPrice" + product.Name;
            lblProductPrice1.Size = new System.Drawing.Size(108, 19);
            lblProductPrice1.TabIndex = 2;
            lblProductPrice1.Text = "Price: $" + product.Price.ToString();

            // 
            // lblProductDescription
            // 
            Label lblProductDescription = new Label();
            lblProductDescription.AutoSize = true;
            lblProductDescription.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblProductDescription.ForeColor = System.Drawing.Color.White;
            lblProductDescription.Location = new System.Drawing.Point(6, 221);
            lblProductDescription.Name = "lblProductDescription" + product.Name;
            lblProductDescription.Size = new System.Drawing.Size(144, 19);
            lblProductDescription.TabIndex = 3;
            lblProductDescription.Text = "Author: " + product.Author;

            // 
            // pct1
            // 
            PictureBox pct1 = new PictureBox();
            pct1.Location = new System.Drawing.Point(6, 19);
            pct1.Name = product.Name;
            pct1.Size = new System.Drawing.Size(171, 180);
            pct1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pct1.Image = product.Image;
            //pct1.Load(product.ToString());
            pct1.TabIndex = 0;
            pct1.TabStop = false;
            pct1.Click += pct1_Click;
            // 

            // 
            // grpProduct1
            // 
            GroupBox grpProduct1 = new GroupBox();
            grpProduct1.Controls.Add(lblProductPrice1);
            grpProduct1.Controls.Add(lblProductName1);
            grpProduct1.Controls.Add(lblProductDescription);
            grpProduct1.Controls.Add(pct1);
            //grpProduct1.Location = new System.Drawing.Point(3, 3);
            grpProduct1.Name = "grpProduct" + count;
            grpProduct1.Size = new System.Drawing.Size(263, 276);
            grpProduct1.TabIndex = 0;
            grpProduct1.TabStop = false;
            grpProduct1.Cursor = System.Windows.Forms.Cursors.Hand;


            count++;

            Application.OpenForms["MainForm"].Controls["flwPanelProducts"].Controls.Add(grpProduct1);
        }

        private void AddNewMagazineGroupToProductPanel(Product _product)
        {
            Magazine product = (Magazine)_product;

            // lblProductName1
            // 
            Label lblProductName1 = new Label();
            lblProductName1.AutoSize = true;
            lblProductName1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblProductName1.ForeColor = System.Drawing.Color.White;
            lblProductName1.Location = new System.Drawing.Point(6, 202);
            lblProductName1.Name = "lblProductName" + product.Name;
            lblProductName1.Size = new System.Drawing.Size(90, 19);
            lblProductName1.TabIndex = 1;
            lblProductName1.Text = "Name: " + product.Name;
            // 
            // lblProductPrice1
            // 
            Label lblProductPrice1 = new Label();
            lblProductPrice1.AutoSize = true;
            lblProductPrice1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblProductPrice1.ForeColor = System.Drawing.Color.White;
            lblProductPrice1.Location = new System.Drawing.Point(6, 240);
            lblProductPrice1.Name = "lblProductPrice" + product.Name;
            lblProductPrice1.Size = new System.Drawing.Size(108, 19);
            lblProductPrice1.TabIndex = 2;
            lblProductPrice1.Text = "Price: $" + product.Price.ToString();

            // 
            // lblProductDescription
            // 
            Label lblProductDescription = new Label();
            lblProductDescription.AutoSize = true;
            lblProductDescription.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblProductDescription.ForeColor = System.Drawing.Color.White;
            lblProductDescription.Location = new System.Drawing.Point(6, 221);
            lblProductDescription.Name = "lblProductDescription" + product.Name;
            lblProductDescription.Size = new System.Drawing.Size(144, 19);
            lblProductDescription.TabIndex = 3;
            lblProductDescription.Text = "Issue: " + product.Issue;

            // 
            // pct1
            // 
            PictureBox pct1 = new PictureBox();
            pct1.Location = new System.Drawing.Point(6, 19);
            pct1.Name = product.Name;
            pct1.Size = new System.Drawing.Size(171, 180);
            pct1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pct1.Image = product.Image;
            //pct1.Load(product.ToString());
            pct1.TabIndex = 0;
            pct1.TabStop = false;
            pct1.Click += pct1_Click;

            // 

            // 
            // grpProduct1
            // 
            GroupBox grpProduct1 = new GroupBox();
            grpProduct1.Controls.Add(lblProductPrice1);
            grpProduct1.Controls.Add(lblProductName1);
            grpProduct1.Controls.Add(lblProductDescription);
            grpProduct1.Controls.Add(pct1);
            //grpProduct1.Location = new System.Drawing.Point(3, 3);
            grpProduct1.Name = "grpProduct" + count;
            grpProduct1.Size = new System.Drawing.Size(263, 276);
            grpProduct1.TabIndex = 0;
            grpProduct1.TabStop = false;
            grpProduct1.Cursor = System.Windows.Forms.Cursors.Hand;


            count++;

            Application.OpenForms["MainForm"].Controls["flwPanelProducts"].Controls.Add(grpProduct1);
        }

        private void AddNewMusicCDGroupToProductPanel(Product _product)
        {
            MusicCD product = (MusicCD)_product;

            // lblProductName1
            // 
            Label lblProductName1 = new Label();
            lblProductName1.AutoSize = true;
            lblProductName1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblProductName1.ForeColor = System.Drawing.Color.White;
            lblProductName1.Location = new System.Drawing.Point(6, 202);
            lblProductName1.Name = "lblProductName" + product.Name;
            lblProductName1.Size = new System.Drawing.Size(90, 19);
            lblProductName1.TabIndex = 1;
            lblProductName1.Text = "Name: " + product.Name;
            // 
            // lblProductPrice1
            // 
            Label lblProductPrice1 = new Label();
            lblProductPrice1.AutoSize = true;
            lblProductPrice1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblProductPrice1.ForeColor = System.Drawing.Color.White;
            lblProductPrice1.Location = new System.Drawing.Point(6, 240);
            lblProductPrice1.Name = "lblProductPrice" + product.Name;
            lblProductPrice1.Size = new System.Drawing.Size(108, 19);
            lblProductPrice1.TabIndex = 2;
            lblProductPrice1.Text = "Price: $" + product.Price.ToString();

            // 
            // lblProductDescription
            // 
            Label lblProductDescription = new Label();
            lblProductDescription.AutoSize = true;
            lblProductDescription.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblProductDescription.ForeColor = System.Drawing.Color.White;
            lblProductDescription.Location = new System.Drawing.Point(6, 221);
            lblProductDescription.Name = "lblProductDescription" + product.Name;
            lblProductDescription.Size = new System.Drawing.Size(144, 19);
            lblProductDescription.TabIndex = 3;
            lblProductDescription.Text = "Singer: " + product.Singer;

            // 
            // pct1
            // 
            PictureBox pct1 = new PictureBox();
            pct1.Location = new System.Drawing.Point(6, 19);
            pct1.Name = product.Name;
            pct1.Size = new System.Drawing.Size(171, 180);
            pct1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pct1.Image = product.Image;
            //pct1.Load(product.ToString());
            pct1.TabIndex = 0;
            pct1.TabStop = false;
            pct1.Click += pct1_Click;
            // 

            // 
            // grpProduct1
            // 
            GroupBox grpProduct1 = new GroupBox();
            grpProduct1.Controls.Add(lblProductPrice1);
            grpProduct1.Controls.Add(lblProductName1);
            grpProduct1.Controls.Add(lblProductDescription);
            grpProduct1.Controls.Add(pct1);
            //grpProduct1.Location = new System.Drawing.Point(3, 3);
            grpProduct1.Name = "grpProduct" + count;
            grpProduct1.Size = new System.Drawing.Size(263, 276);
            grpProduct1.TabIndex = 0;
            grpProduct1.TabStop = false;
            grpProduct1.Cursor = System.Windows.Forms.Cursors.Hand;


            count++;

            Application.OpenForms["MainForm"].Controls["flwPanelProducts"].Controls.Add(grpProduct1);
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Controls["flwPanelProducts"].Controls.Clear();

            DBProduct.UpdateBooksFromDatabase();
            List<Book> books = DBProduct.bookList;

            foreach (var item in books)
            {
                AddNewBookGroupToProductPanel(item);
            }

            pnlRed1.Visible = true;
            pnlRed2.Visible = false;
            pnlRed3.Visible = false;

            allProducts = GetAllProducts();
        }

        private void btnMagazine_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Controls["flwPanelProducts"].Controls.Clear();

            DBProduct.UpdateMagazinesFromDatabase();
            List<Magazine> magazines = DBProduct.magazineList;

            foreach (var item in magazines)
            {
                AddNewMagazineGroupToProductPanel(item);
            }

            pnlRed2.Visible = true;
            pnlRed1.Visible = false;
            pnlRed3.Visible = false;

            allProducts = GetAllProducts();
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Controls["flwPanelProducts"].Controls.Clear();

            DBProduct.UpdateMusicCDsFromDatabase();
            List<MusicCD> musicCDs = DBProduct.musicCDList;

            foreach (var item in musicCDs)
            {
                AddNewMusicCDGroupToProductPanel(item);
            }

            pnlRed3.Visible = true;
            pnlRed1.Visible = false;
            pnlRed2.Visible = false;

            allProducts = GetAllProducts();
        }

        private void pct1_Click(object sender, EventArgs e)
        {
            PictureBox pct = (PictureBox)sender;

            DBProduct.UpdateBooksFromDatabase();
            List<Book> books = DBProduct.bookList;

            Book book;

            foreach (var item in books)
            {
                if (item.Name == pct.Name)
                {
                    book = item;
                    ProductForm.productBook = book;
                    ProductForm.productType = ProductForm.ProductType.BOOK;
                    break;
                }
            }


            DBProduct.UpdateMagazinesFromDatabase();
            List<Magazine> magazines = DBProduct.magazineList;

            Magazine magazine;

            foreach (var item in magazines)
            {
                if (item.Name == pct.Name)
                {
                    magazine = item;
                    ProductForm.productMagazine = magazine;
                    ProductForm.productType = ProductForm.ProductType.MAGAZINE;
                    break;
                }
            }

            DBProduct.UpdateMusicCDsFromDatabase();
            List<MusicCD> musicCDs = DBProduct.musicCDList;

            MusicCD musicCD;

            foreach (var item in musicCDs)
            {
                if (item.Name == pct.Name)
                {
                    musicCD = item;
                    ProductForm.productMusicCD = musicCD;
                    ProductForm.productType = ProductForm.ProductType.MUSICCD;
                    break;
                }
            }

            ProductForm productForm = new ProductForm();
            productForm.ShowDialog();

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.White;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search";
                txtSearch.ForeColor = Color.Silver;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            Application.OpenForms["MainForm"].Controls["flwPanelProducts"].Controls.Clear();

            DBProduct.UpdateBooksFromDatabase();
            List<Book> books = DBProduct.bookList;

            foreach (var item in books)
            {
                AddNewBookGroupToProductPanel(item);
            }

            GetAllProducts();
        }

        private void btnMyCart_Click(object sender, EventArgs e)
        {

            myCartForm = new MyCartForm(this.user);
            myCartForm.Show();

            this.Hide();
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            this.Hide();

            AdminPanelForm adminPanelForm = new AdminPanelForm(user);
            adminPanelForm.Show();

        }

        private List<Product> GetAllProducts()
        {
            DBOperation dBOperation = new DBOperation();

            List<Product> allProducts = new List<Product>();
            allProducts.AddRange(dBOperation.GetBooksFromDatabase());
            allProducts.AddRange(dBOperation.GetMagazinesFromDatabase());
            allProducts.AddRange(dBOperation.GetMusicCDsFromDatabase());

            return allProducts;
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (isFirst == true)
            //{
            //    isFirst = false;
            //    return;
            //}

            //if (txtSearch.Text.Length == 0 && isFirst == false)
            //{
            //    btnBooks_Click(null, null);
            //    //isFirst = true;
            //}
        }
    }
}
