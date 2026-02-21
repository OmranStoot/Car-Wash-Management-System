using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Wash.Global_Classes;
using CarWash.BL;
using static Car_Wash.frmCashCustomer;
using static Car_Wash.frmCashService;

namespace Car_Wash
{
    public partial class frmCash : BaseSecureForm
    {
        protected override Permissions RequiredPermission => Permissions.CashOperations;

        private ClsCashInvoice _currentInvoice = null;
        private int _customerID = -1, _vehicaleTypeID = -1;
        private List<SelectedServiceDTO> _selectedServices = new List<SelectedServiceDTO>();
        private DataTable _dtCashPreview;
        

        private void BuildCashPreviewTable()
        {
            _dtCashPreview = new DataTable();

            _dtCashPreview.Columns.Add("CustomerName", typeof(string));
            _dtCashPreview.Columns.Add("CarModel", typeof(string));
            _dtCashPreview.Columns.Add("VehicleTypeName", typeof(string));
            _dtCashPreview.Columns.Add("VehicleClass", typeof(int));
            _dtCashPreview.Columns.Add("ServiceName", typeof(string));
            _dtCashPreview.Columns.Add("ServicePrice", typeof(decimal));
            _dtCashPreview.Columns.Add("FinalPrice", typeof(decimal));
            _dtCashPreview.Columns.Add("ServiceID", typeof(int));

        }
        public frmCash()
        {
            InitializeComponent();
        }

        private void ResetCashForm()
        {
            _customerID = -1;
            _vehicaleTypeID = -1;
            _selectedServices.Clear();

            dgvCash.DataSource = null;

            lblTransNo.Text = "";
            lblTotalPrice.Text = "";

            btnAddCustomer.Enabled = true;
            btnAddService.Enabled = false;

            btnSubmit.Visible = true;

            btnPayment.Visible = false;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            
            openChildForm(new frmCashCustomer());
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCashService(_customerID, _vehicaleTypeID));
        }


        private void CustomerForm_CustomerSelected(object sender, CustomerSelectedEventArgs e)
        {
            _customerID = e.CustomerID;
            _vehicaleTypeID = e.VehicleTypeID;
            panelCash.Height = 1;
            btnAddService.Enabled = true;
        }

        public void ServiceForm_ServicesSelected(object sender, ServicesSelectedEventArgs e)
        {
            _selectedServices = e.Services;
            panelCash.Height = 1;
            btnAddCustomer.Enabled = false;
            btnSubmit.Enabled = true;
            BuildCashPreviewTable();

            ClsCustomer customer = ClsCustomer.Find(_customerID);
            ClsVehicaleType vehicaleType = ClsVehicaleType.Find(_vehicaleTypeID);

            foreach (var s in e.Services)
            {
                _dtCashPreview.Rows.Add(
                    customer.Name,
                    customer.CarModel,
                    vehicaleType.Name,
                    vehicaleType.Class,
                    s.ServiceName,
                    s.Price,
                    s.Price * Convert.ToInt32(vehicaleType.@Class),
                    s.ServiceID
                );
            }
            dgvCash.DataSource = _dtCashPreview;
            _ReCalculateTotal();
            btnAddCustomer.Enabled = false;
        }

        private Form activeForm = null;

        private void frmCash_Load(object sender, EventArgs e)
        {
            dgvCash.AutoGenerateColumns = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_customerID <= 0 || _vehicaleTypeID <= 0 || _selectedServices.Count == 0)
            {
                MessageBox.Show("بيانات غير مكتملة.");
                return;
            }

            decimal totalAmount = 0;
            ClsVehicaleType vehicaleType = ClsVehicaleType.Find(_vehicaleTypeID);
            int vClass = Convert.ToInt32(vehicaleType.@Class);

            foreach (var service in _selectedServices)
            {
                totalAmount += (service.Price * vClass);
            }

            string transNo = ClsCashInvoice.GenerateTransNo();
            _currentInvoice = new ClsCashInvoice(
                ClsGlobal.CurrentEmployer.EmployerID.Value
            )
            {
                TransNo = transNo,
                Cid = _customerID,
                Vid = _vehicaleTypeID,
                InvoiceDate = DateTime.Now,
                Status = "Open",
                TotalAmount = totalAmount
            };
            if (_currentInvoice.Save())
            {
                foreach (var service in _selectedServices)
                {
                    if (service.ServiceID <= 0 || !ClsService.Exists(service.ServiceID))
                    {
                        MessageBox.Show($"ServiceID غير صالح: {service.ServiceID}");
                        continue;
                    }
                    decimal finalPrice = service.Price * vClass;
                    _currentInvoice.AddService(service.ServiceID,finalPrice);
                }

                lblTransNo.Text = transNo;
                lblTotalPrice.Text = _currentInvoice.TotalAmount.ToString("N2");

                btnSubmit.Visible = false;
                btnPayment.Visible = true;
                btnAddService.Enabled = false;

                MessageBox.Show("تم إنشاء الفاتورة بنجاح.");
            }
            else
            {
                MessageBox.Show("فشل حفظ الفاتورة، يرجى التحقق من قاعدة البيانات.");
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            frmPaymentSettle frm = new frmPaymentSettle(_currentInvoice.InvoiceID.Value);
            frm.Show();
            ResetCashForm();
        }

        private void _ReCalculateTotal()
        {
            decimal total = 0;

            foreach (DataRow row in _dtCashPreview.Rows)
                total += Convert.ToDecimal(row["FinalPrice"]);
            lblTotalPrice.Text = total.ToString("N2");
        }
        private void dgvCash_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            if (dgvCash.Columns[e.ColumnIndex].Name != "btnDeleteService") return;

            if (MessageBox.Show(
                "Are you sure you want to remove this service?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            int serviceID = Convert.ToInt32(dgvCash.Rows[e.RowIndex].Cells["ServiceID"].Value);

            _dtCashPreview.Rows.RemoveAt(e.RowIndex);

            var serviceToRemove =  _selectedServices
                .FirstOrDefault(s => s.ServiceID == serviceID);

            if(serviceToRemove != null) 
                _selectedServices.Remove(serviceToRemove);

            _ReCalculateTotal();

            
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            if (childForm is frmCashCustomer customerForm)
                customerForm.CustomerSelected += CustomerForm_CustomerSelected;
            if (childForm is frmCashService serviceForm)
                serviceForm.ServicesSelected += ServiceForm_ServicesSelected;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelCash.Height = 200;
            panelCash.Controls.Add(childForm);
            panelCash.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


    }
}
