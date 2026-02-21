using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Wash;
using Car_Wash.Global_Classes;
using CarWash.BL;

namespace CarWash.PL
{
    public partial class MainForm : Form
    {
        frmLogin _frmLogin;
        public MainForm(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }
        private int _targetTop;
        private const int Speed = 10;
        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null) return;

            panelSlide.Height = btn.Height;
            _targetTop = btn.Top;
            timer1.Interval = 15;
            timer1.Start();

            switch(btn.Name)
            {
                case "btnDashboard":
                    break;
                case "btnEmployer":
                    openChildForm(new Employer());
                    break;
                case "btnCustomer":
                    openChildForm(new frmCustomerList());
                    break;
                case "btnService":
                    openChildForm(new frmServiceList());
                    break;
                case "btnCash":
                    openChildForm(new frmCash());
                    break;
                case "btnInvoices":
                    openChildForm(new frmInvoicesList());
                    break;
                case "btnReports":
                    openChildForm(new frmReports());
                    break;
                case "btnSettings":
                    openChildForm(new frmSettings());
                    break;
                case "btnLogout":
                    ClsGlobal.CurrentEmployer = null;
                    this.Close();
                    _frmLogin.Show();
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int delta = _targetTop - panelSlide.Top;

            panelSlide.Top += Math.Sign(delta) * Math.Min(Math.Abs(delta), Speed);

            if (delta == 0)
                timer1.Stop();
        }

        private Form activeForm = null;

        public void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblRevenues.Text = ClsReports.GetRevenueLast7Days().ToString();
            lblCostOfGoodSold.Text = ClsReports.GetCostsLast7Days().ToString();
            lblGrossProfit.Text = (Convert.ToDecimal(lblRevenues.Text) - Convert.ToDecimal(lblCostOfGoodSold.Text)).ToString();

            if(Convert.ToDecimal(lblGrossProfit.Text) > 0)
            {
                lblGrossProfit.ForeColor = Color.Green;
                pbGP.Image = Car_Wash.Properties.Resources.up_25px;

            } 
            else if((Convert.ToDecimal(lblGrossProfit.Text) < 0))
            {
                lblGrossProfit.ForeColor = Color.Red;
                pbGP.Image = Car_Wash.Properties.Resources.down_25px;
            }
            else
            {
                lblGrossProfit.ForeColor = Color.Gray;
                pbGP.Image = Car_Wash.Properties.Resources.icons8_equal_25;
            }

            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            var emp = ClsGlobal.CurrentEmployer;
            if (emp == null)
                return;
            btnCustomer.Enabled = emp.HasPermissions(Permissions.ViewCustomers);
            btnEmployer.Enabled = emp.HasPermissions(Permissions.ManageEmployees);
            btnService.Enabled = emp.HasPermissions(Permissions.ManageServices);
            btnCash.Enabled = emp.HasPermissions(Permissions.CashOperations);
            btnInvoices.Enabled = emp.HasPermissions(Permissions.ViewInvoices);
            btnReports.Enabled = emp.HasPermissions(Permissions.ViewReports);
            btnSettings.Enabled = emp.HasPermissions(Permissions.Settings);
        }
    }
}
