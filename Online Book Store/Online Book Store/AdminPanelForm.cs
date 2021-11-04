using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Book_Store
{
    public partial class AdminPanelForm : Form
    {
        private System.IO.Stream stream;

        public AdminPanelForm(User user)
        {
            InitializeComponent();

            this.labelName.Text = user.FullName;
            this.labelUsername.Text = user.UserName;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm tt");
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void pctLogout_Click(object sender, EventArgs e)
        {
            Application.OpenForms["LoginForm"].Show();

            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtImageURL.Text.Length <= 0)
            {
                MessageBox.Show("URL must be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBOperation dBOperation = new DBOperation();
            var request = WebRequest.Create(txtImageURL.Text);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Bitmap.FromStream(stream);
                Book book = new Book(txtBookName.Text, (float)Math.Round(Convert.ToDouble(txtPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtISBN.Text, txtAuthor.Text, txtPublisher.Text, Convert.ToInt32(txtPage.Text), txtDescription.Text);

                dBOperation.AddBookToDatabase(book, txtImageURL.Text);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAuthor.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtImageURL.Text = string.Empty;
            txtPage.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtPublisher.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtImageURL.Text.Length <= 0)
            {
                MessageBox.Show("URL must be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBOperation dBOperation = new DBOperation();
            var request = WebRequest.Create(txtImageURL.Text);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Bitmap.FromStream(stream);
                Book book = new Book(txtBookName.Text, (float)Convert.ToDouble(txtPrice.Text), pictureBox.Image,
                    txtISBN.Text, txtAuthor.Text, txtPublisher.Text, Convert.ToInt32(txtPage.Text), txtDescription.Text);

                dBOperation.UpdateBookToDatabase(book, txtImageURL.Text);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBOperation dBOperation = new DBOperation();

            //var request = WebRequest.Create(txtImageURL.Text);

            // using (var response = request.GetResponse())
            //using (var stream = response.GetResponseStream())
            //{
            PictureBox pictureBox = new PictureBox();
            //   pictureBox.Image = Bitmap.FromStream(stream);
            Book book = new Book(txtBookName.Text, 0, pictureBox.Image,
                " ", " ", " ", 0, " ");

            dBOperation.DeleteBookToDatabase(book);
            // }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["MainForm"].Show();
        }



        private void btnMagazineAdd_Click(object sender, EventArgs e)
        {
            if (txtMagazineImageURL.Text.Length <= 0)
            {
                MessageBox.Show("URL must be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBOperation dBOperation = new DBOperation();
            var request = WebRequest.Create(txtMagazineImageURL.Text);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Bitmap.FromStream(stream);
                Magazine magazine;
                switch (cmbMagazineType.SelectedItem.ToString())
                {
                    case "Actual":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.Actual, txtMagazineDescription.Text);
                        dBOperation.AddMagazineToDatabase(magazine, txtMagazineImageURL.Text);
                        break;
                    case "News":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.News, txtMagazineDescription.Text);
                        dBOperation.AddMagazineToDatabase(magazine, txtMagazineImageURL.Text);
                        break;
                    case "Sport":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.Sport, txtMagazineDescription.Text);
                        dBOperation.AddMagazineToDatabase(magazine, txtMagazineImageURL.Text);
                        break;
                    case "Computer":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.Computer, txtMagazineDescription.Text);
                        dBOperation.AddMagazineToDatabase(magazine, txtMagazineImageURL.Text);
                        break;
                    case "Technology":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.Technology, txtMagazineDescription.Text);
                        dBOperation.AddMagazineToDatabase(magazine, txtMagazineImageURL.Text);
                        break;

                }


            }
        }

        private void btnMagazineDelete_Click(object sender, EventArgs e)
        {
            DBOperation dBOperation = new DBOperation();

            PictureBox pictureBox = new PictureBox();

            Magazine magazine = new Magazine(txtMagazineName.Text, 0, pictureBox.Image,
                " ", Magazine.Types.Technology, " ");

            dBOperation.DeleteMagazineToDatabase(magazine);
        }

        private void btnMagazineUpdate_Click(object sender, EventArgs e)
        {
            if (txtMagazineImageURL.Text.Length <= 0)
            {
                MessageBox.Show("URL must be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBOperation dBOperation = new DBOperation();
            var request = WebRequest.Create(txtImageURL.Text);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Bitmap.FromStream(stream);
                Magazine magazine;
                switch (cmbMagazineType.SelectedItem.ToString())
                {
                    case "Actual":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.Actual, txtMagazineDescription.Text);
                        dBOperation.UpdateMagazineToDatabase(magazine, txtImageURL.Text);
                        break;
                    case "News":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.News, txtMagazineDescription.Text);
                        dBOperation.UpdateMagazineToDatabase(magazine, txtImageURL.Text);
                        break;
                    case "Sport":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.Sport, txtMagazineDescription.Text);
                        dBOperation.UpdateMagazineToDatabase(magazine, txtImageURL.Text);
                        break;
                    case "Computer":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.Computer, txtMagazineDescription.Text);
                        dBOperation.UpdateMagazineToDatabase(magazine, txtImageURL.Text);
                        break;
                    case "Technology":
                        magazine = new Magazine(txtMagazineName.Text, (float)Math.Round(Convert.ToDouble(txtMagazinePrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMagazineIssue.Text, Magazine.Types.Technology, txtMagazineDescription.Text);
                        dBOperation.UpdateMagazineToDatabase(magazine, txtImageURL.Text);
                        break;

                }
            }
        }

        private void btnMagazineClear_Click(object sender, EventArgs e)
        {
            txtMagazineDescription.Text = string.Empty;
            txtMagazineImageURL.Text = string.Empty;
            txtMagazineIssue.Text = string.Empty;
            txtMagazineName.Text = string.Empty;
            txtMagazinePrice.Text = string.Empty;
        }

        private void btnMusicCDAdd_Click(object sender, EventArgs e)
        {
            if (txtMusicCDImageURL.Text.Length <= 0)
            {
                MessageBox.Show("URL must be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBOperation dBOperation = new DBOperation();
            var request = WebRequest.Create(txtMusicCDImageURL.Text);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Bitmap.FromStream(stream);
                MusicCD musicCD;
                switch (cmbMusicCDType.SelectedItem.ToString())
                {

                    case "Country":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.Country, txtMusicCDDescription.Text);
                        dBOperation.AddMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Hard Rock":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.HardRock, txtMusicCDDescription.Text);
                        dBOperation.AddMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Heavy Metal":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.HeavyMetal, txtMusicCDDescription.Text);
                        dBOperation.AddMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Pop":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.Pop, txtMusicCDDescription.Text);
                        dBOperation.AddMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Rap":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.Rap, txtMusicCDDescription.Text);
                        dBOperation.AddMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Romance":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.Romance, txtMusicCDDescription.Text);
                        dBOperation.AddMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;

                }
            }
        }

        private void btnMusicCDUpdate_Click(object sender, EventArgs e)
        {
            if (txtMusicCDImageURL.Text.Length <= 0)
            {
                MessageBox.Show("URL must be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBOperation dBOperation = new DBOperation();
            var request = WebRequest.Create(txtMusicCDImageURL.Text);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Bitmap.FromStream(stream);
                MusicCD musicCD;
                switch (cmbMusicCDType.SelectedItem.ToString())
                {

                    case "Country":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.Country, txtMusicCDDescription.Text);
                        dBOperation.UpdateMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Hard Rock":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.HardRock, txtMusicCDDescription.Text);
                        dBOperation.UpdateMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Heavy Metal":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.HeavyMetal, txtMusicCDDescription.Text);
                        dBOperation.UpdateMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Pop":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.Pop, txtMusicCDDescription.Text);
                        dBOperation.UpdateMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Rap":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.Rap, txtMusicCDDescription.Text);
                        dBOperation.UpdateMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;
                    case "Romance":
                        musicCD = new MusicCD(txtMusicCDName.Text, (float)Math.Round(Convert.ToDouble(txtMusicCDPrice.Text), 2/* * 100f*/) /*/ 100f*/, pictureBox.Image,
                    txtMusicCDSinger.Text, MusicCD.Types.Romance, txtMusicCDDescription.Text);
                        dBOperation.UpdateMusicCDToDatabase(musicCD, txtMusicCDImageURL.Text);
                        break;

                }
            }
        }

        private void btnMusicCDClear_Click(object sender, EventArgs e)
        {
            txtMusicCDDescription.Text = string.Empty;
            txtMusicCDImageURL.Text = string.Empty;
            txtMusicCDName.Text = string.Empty;
            txtMusicCDPrice.Text = string.Empty;
            txtMusicCDSinger.Text = string.Empty;
        }

        private void btnMusicCDDelete_Click(object sender, EventArgs e)
        {
            DBOperation dBOperation = new DBOperation();

            PictureBox pictureBox = new PictureBox();

            MusicCD musicCD = new MusicCD(txtMusicCDName.Text, 0 /*/ 100f*/, pictureBox.Image,
                    " ", MusicCD.Types.Romance, " ");

            dBOperation.DeleteMusicCDToDatabase(musicCD);
        }
    }
}
