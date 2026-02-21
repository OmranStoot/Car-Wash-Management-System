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

namespace Car_Wash
{
    public partial class BaseSecureForm : Form
    {
        protected virtual Permissions RequiredPermission
            => Permissions.None;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); 

            if(RequiredPermission == Permissions.None)
                return;

            if(ClsGlobal.CurrentEmployer == null || !ClsGlobal.CurrentEmployer.HasPermissions(RequiredPermission))
            {
                MessageBox.Show("You do not have permission to access this screen", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

    }
}
