using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6FinalProject
{
    class ClsSQL
    {

        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the Invoice to rtreieve all data</param>
        /// <returns>All data for the given invoice</returns>
        public string SelectInvoiceData(string sInvoiceID)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;
            return sSQL;
        }

    }
}
