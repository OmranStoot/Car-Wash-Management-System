using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarWash.BL;

namespace Car_Wash
{
    public partial class frmReports : BaseSecureForm
    {
        protected override Permissions RequiredPermission => Permissions.ViewReports;

        public frmReports()
        {
            InitializeComponent();
        }


        private void frmReports_Load(object sender, EventArgs e)
        {
            _LoadTopSelling();
            _LoadRevenues();
            _LoadCostOfGoods();
            _LoadGP();
        }

        private void _LoadTopSelling()
        {
            dgvTopSelling.AutoGenerateColumns = false;
            DateTime startDate = dtpFromTopSelling.Value;
            DateTime endDate = dtpToTopSelling.Value;
            dgvTopSelling.DataSource = ClsReports.GetTopSellingServices(startDate, endDate);

        }

        private void _LoadRevenues()
        {
            dgvRevenues.AutoGenerateColumns = false;
            DateTime startDate = dtpFromReveue.Value;
            DateTime endDate = dtpToReveue.Value;
            DataTable dt = ClsReports.GetRevenues(startDate, endDate);
            dgvRevenues.DataSource = dt;

            decimal totalRevenue = ClsReports.CalculateTotalRevenue(dt);

            lblTotalRevenue.Text = totalRevenue.ToString("#,##0.00");
        }

        private void _LoadCostOfGoods()
        {
            dgvCostOfGoods.AutoGenerateColumns = false;
            DateTime startDate = dtpFromCoG.Value;
            DateTime endDate = dtpToCoG.Value;
            DataTable dt = ClsReports.GetCostOfGoods(startDate, endDate);
            dgvCostOfGoods.DataSource = dt;
            lblTotalCost.Text = ClsReports.CalculateTotalCosts(dt).ToString("#,##0.00");
        }

        private void _LoadGP()
        {
            DateTime startDate = dtpFromGP.Value;
            DateTime endDate = dtpToGP.Value;

            DataTable dtRevenue = ClsReports.GetRevenues(startDate, endDate);
            decimal totalRevenue = ClsReports.CalculateTotalRevenue(dtRevenue);
            txtRevenue.Text = totalRevenue.ToString("#,##0.00");

            DataTable dtCost = ClsReports.GetCostOfGoods(startDate, endDate);
            decimal totalCost = ClsReports.CalculateTotalCosts(dtCost);
            txtCoG.Text = totalCost.ToString("#,##0.00");

            decimal gp = totalRevenue - totalCost;
            txtGrossProfit.Text = gp.ToString("#,##0.00");

            txtRevenue.BackColor = Color.White;
            txtCoG.BackColor = Color.White;
            txtGrossProfit.BackColor = Color.White;

            if (gp > 0)
                txtGrossProfit.ForeColor = Color.Green;
            else if (gp < 0)
                txtGrossProfit.ForeColor = Color.Red;
            else
                txtGrossProfit.ForeColor = Color.Gray;
        }

        private void dtpFromTopSelling_ValueChanged(object sender, EventArgs e)
        {
            _LoadTopSelling();
        }

        private void dtpToTopSelling_ValueChanged(object sender, EventArgs e)
        {
            _LoadTopSelling();
        }

        private void dtpFromReveue_ValueChanged(object sender, EventArgs e)
        {
            _LoadRevenues();
        }

        private void dtpToReveue_ValueChanged(object sender, EventArgs e)
        {
            _LoadRevenues();
        }

        private void dtpFromCoG_ValueChanged(object sender, EventArgs e)
        {
            _LoadCostOfGoods();
        }

        private void dtpToCoG_ValueChanged(object sender, EventArgs e)
        {
            _LoadCostOfGoods();
        }

        private void dtpFromGP_ValueChanged(object sender, EventArgs e)
        {
            _LoadGP();
        }

        private void dtpToGP_ValueChanged(object sender, EventArgs e)
        {
            _LoadGP();
        }

    }
}

