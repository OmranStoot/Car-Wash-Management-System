using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Wash
{
    public class ClsValidation
    {
        public static bool IsInteger(string value)
        {
            return (int.TryParse(value, out _));
        }

        public static bool IsFloat(string value)
        {
            return (float.TryParse(value, out _));
        }

        public static void ClearControls(Control parent, DateTime? maxDate = null)
        {
            foreach (Control ctrl in parent.Controls)
            {
                switch (ctrl)
                {
                    case TextBox tb:
                        tb.Clear();
                        break;

                    case ComboBox cb:
                        cb.SelectedIndex = -1;
                        break;

                    case DateTimePicker dtp:
                        if (maxDate.HasValue)
                            dtp.Value = maxDate.Value;
                        else
                            dtp.Value = DateTime.Now;
                        break;
                }

                if (ctrl.HasChildren)
                    ClearControls(ctrl, maxDate);
            }
        }

        public static void AttachValidation(Control parent, ErrorProvider errorProvider)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                    ctrl.Validating += (s, e) => ValidateTextBox(s, e, errorProvider);

                if (ctrl.HasChildren)
                    AttachValidation(ctrl, errorProvider);
            }
        }

        private static void ValidateTextBox(object sender, CancelEventArgs e, ErrorProvider errorProvider)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;

            errorProvider.SetError(tb, null);

            // Required
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tb, "This field is required");
                return;
            }

            // Validation by Tag
            switch (tb.Tag?.ToString())
            {
                case "int":
                    if (!ClsValidation.IsInteger(tb.Text))
                    {
                        e.Cancel = true;
                            
                    }
                    break;

                case "decimal":
                    if (!ClsValidation.IsFloat(tb.Text))
                    {
                        e.Cancel = true;
                        errorProvider.SetError(tb, "Value must be a valid decimal number");
                    }
                    break;

                case "name":
                    if (tb.Text.Any(char.IsDigit))
                    {
                        e.Cancel = true;
                        errorProvider.SetError(tb, "Name must contain letters only");
                    }
                    break;
            }
        }
    }
}
