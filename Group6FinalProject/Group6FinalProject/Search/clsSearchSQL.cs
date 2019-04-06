using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6FinalProject.Search
{
    static class ClsSearchSQL
    {
        /// <summary>
        /// This SQL gets all data on all invoices in the database.
        /// </summary>
        /// <returns>All data for the given invoice.</returns>
        public static string SelectAllInvoices()
        {
            string sSQL = "SELECT * FROM Invoices";
            return sSQL;
        }

        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID.
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public static string SelectInvoiceById(string sInvoiceID)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;
            return sSQL;
        }

    }
}
