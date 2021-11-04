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
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }


        //private void txtFullname_Click(object sender, EventArgs e)
        //{
        //    if (txtFullname.Text == "Full Name")
        //    {
        //        txtFullname.Text = string.Empty;
        //    }
        //}
        //private void txtUsername_Click(object sender, EventArgs e)
        //{
        //    if (txtUsername.Text == "Username")
        //    {
        //        txtUsername.Text = string.Empty;
        //    }
        //}

        //private void txtPassword_Click(object sender, EventArgs e)
        //{
        //    if (txtPassword.Text == "Password")
        //    {
        //        txtPassword.Text = string.Empty;
        //        txtPassword.PasswordChar = '*';
        //    }
        //}
        //private void txtMail_Click(object sender, EventArgs e)
        //{
        //    if (txtMail.Text == "Mail")
        //    {
        //        txtMail.Text = string.Empty;
        //    }
        //}
        //private void txtConfirmPassword_Click(object sender, EventArgs e)
        //{
        //    if (txtConfirmPassword.Text == "Re-Password")
        //    {
        //        txtConfirmPassword.Text = string.Empty;
        //        txtConfirmPassword.PasswordChar = '*';
        //    }
        //}

        //private void txtAddress_Click(object sender, EventArgs e)
        //{
        //    if (txtAddress.Text == "Address")
        //    {
        //        txtAddress.Text = string.Empty;
        //    }
        //}
        private void pctSignup_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text.Length > 0 && txtUsername.Text.Length > 0)
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    User user = new User(User.ID, txtFullname.Text, txtAddress.Text, txtMail.Text, txtUsername.Text, txtPassword.Text, false);

                    DBOperation dBOperation = new DBOperation();

                    if (dBOperation.AddUser(user))
                    {
                        notify = new NotifyIcon();
                        notify.BalloonTipText = "Registration Successful!";
                        notify.BalloonTipTitle = "SUCCESS";
                        notify.Visible = true;
                        notify.Icon = SystemIcons.Information;
                        notify.BalloonTipIcon = ToolTipIcon.Info;
                        notify.ShowBalloonTip(1500);
                    }
                }
                else
                {
                    MessageBox.Show("Passwords did not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Username or full name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            this.Close();
            Application.OpenForms["LoginForm"].Show();
        }

        private void pctExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtFullname_Enter(object sender, EventArgs e)
        {
            if (txtFullname.Text == "Full Name")
            {
                txtFullname.Text = "";
                txtFullname.ForeColor = Color.White;
            }
        }
        private void txtFullname_Leave(object sender, EventArgs e)
        {
            if (txtFullname.Text == "")
            {
                txtFullname.Text = "Full Name";
                txtFullname.ForeColor = Color.Silver;
            }
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
        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "Mail")
            {
                txtMail.Text = "";
                txtMail.ForeColor = Color.White;
            }
        }
        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (txtMail.Text == "")
            {
                txtMail.Text = "Mail";
                txtMail.ForeColor = Color.Silver;
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

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "Re-Password")
            {
                txtConfirmPassword.Text = "";
                txtConfirmPassword.ForeColor = Color.White;
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "")
            {
                txtConfirmPassword.Text = "Re-Password";
                txtConfirmPassword.ForeColor = Color.Silver;
            }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if (txtAddress.Text == "Address")
            {
                txtAddress.Text = "";
                txtAddress.ForeColor = Color.White;
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                txtAddress.Text = "Address";
                txtAddress.ForeColor = Color.Silver;
            }
        }

        private void pctPasswordShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
            else if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';

            }
        }
    }
}
