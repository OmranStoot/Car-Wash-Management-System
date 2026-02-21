using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Wash.Global_Classes;
using CarWash.BL;
using CarWash.PL;

namespace Car_Wash
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            string UserName = string.Empty, Password = string.Empty;
            if(ClsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
            if(ClsGlobal.company != null)
            {
                lblCompanyName.Text = ClsGlobal.company.CompanyName;
                lblAddress.Text = ClsGlobal.company.Address;
            }
            else
            {
                lblCompanyName.Text = "Car Wash System";
                lblAddress.Text = "Address";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ClsEmployer employer = ClsEmployer.FindByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if(employer != null)
            {
                if (chkRememberMe.Checked)
                    ClsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                else
                    ClsGlobal.RemoveStoredCredential();
                ClsGlobal.CurrentEmployer = employer;
                MessageBox.Show($"Welcome {txtUserName.Text.Trim()}", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainForm frm = new MainForm(this);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Focus();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chkShowPassword.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }
    }
}
