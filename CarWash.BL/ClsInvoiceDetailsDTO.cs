using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsInvoiceDetailsDTO
    {
        public DataTable Header { get; set; }
        public DataTable Services { get; set; } 
        public DataTable Payments { get; set; }

        public static ClsInvoiceDetailsDTO GetInvoiceDetails(int invocieID)
        {
            return new ClsInvoiceDetailsDTO
            {
                Header = ClsCashInvoiceData.GetInvoiceHeader(invocieID),
                Services = ClsCashInvoiceData.GetInvoiceServices(invocieID),
                Payments = ClsCashInvoiceData.GetInvoicePayments(invocieID)
            };
        }


    }
}
