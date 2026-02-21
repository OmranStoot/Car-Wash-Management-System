using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Car_Wash.Reports
{
    public partial class frmInvoiceReport : Form
    {
        private int _invoiceID;
        private string _companyName;
        private string _companyAddress;
        public frmInvoiceReport(int invoiceID, string companyName, string companyAddress)
        {
            InitializeComponent();
            _invoiceID = invoiceID;
            _companyName = companyName;
            _companyAddress = companyAddress;
        }

        private void frmInvoiceReport_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            var da = new InvoiceReportDataSetTableAdapters.InvoiceDetailsTableAdapter();
            var dt = new InvoiceReportDataSet.InvoiceDetailsDataTable();

            da.Fill(dt, _invoiceID);

            reportViewer1.LocalReport.ReportEmbeddedResource = "Car_Wash.Reports.InvoiceDetailsReport.rdlc";


            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("InvoiceDetailsDB", (System.Data.DataTable)dt)
            );


            reportViewer1.LocalReport.SetParameters(new[]
            {
                new ReportParameter("PCompanyName", _companyName),
                new ReportParameter("PCompanyAddress", _companyAddress)
            });

            reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }
    }
}
