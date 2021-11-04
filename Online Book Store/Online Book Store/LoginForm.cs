using System;
using System.Drawing;
using System.Windows.Forms;

namespace Online_Book_Store
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        

        private void lblSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignupForm signupForm = new SignupForm();
            signupForm.Show();
        }

        private void pctExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pctLogin_Click(object sender, EventArgs e)
        {
            DBOperation dBOperation = new DBOperation();
            User user = dBOperation.CheckUser(txtUsername.Text, txtPassword.Text);

            if (user != null)
            {
                this.Hide();
                notify = new NotifyIcon();
                notify.BalloonTipText = "Login Successful!";
                notify.BalloonTipTitle = "SUCCESS";
                notify.Visible = true;
                notify.Icon = SystemIcons.Information;
                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.ShowBalloonTip(1500);

                MainForm mainForm = new MainForm(user);
                mainForm.Show();

                if(user.IsAdmin)
                    Application.OpenForms["MainForm"].Controls["panelLeft"].Controls["btnAdminPanel"].Visible=true;
                else
                    Application.OpenForms["MainForm"].Controls["panelLeft"].Controls["btnAdminPanel"].Visible = false;

            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.White;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
            }
        }

        private void pctPasswordShow_Click(object sender, EventArgs e)
        {

            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
            }
            else if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
            }
        }
    }
}
