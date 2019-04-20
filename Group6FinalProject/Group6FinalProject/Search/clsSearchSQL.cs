using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group6FinalProject.Search
{
    /// <summary>
    /// Contains all SQL statements needed for the Search Window 
    /// as strings to be retrieved and used in clsSearchLogic
    /// 
    /// This class created by Brad Christensen
    /// </summary>
    static class clsSearchSQL
    {
        #region Methods
        /// <summary>
        /// This SQL gets all data on all invoices in the database.
        /// </summary>
        /// <returns>SQL string to get: All data for all invoices.</returns>
        public static string SelectAllInvoices()
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices";
                return sSQL;
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID.
        /// </summary>
        /// <param name="sInvoiceID">The Invoice Number for the invoice to be retrieved.</param>
        /// <returns>SQL string to get: All data for the selected invoice.</returns>
        public static string SelectInvoiceById(string sInvoiceID)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;
                return sSQL;
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This SQL gets all data on any invoices for a given Invoice Number and Invoice Date.
        /// </summary>
        /// <param name="sInvoiceID">The Invoice Number for the invoice to be retrieved.</param>
        /// <param name="invoiceDate">The Invoice Date for the invoices to be retrieved.</param>
        /// <returns>SQL string to get: All data for the selected invoices.</returns>
        public static string SelectInvoiceByIdDate(string sInvoiceID, string invoiceDate)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID +
                    " AND InvoiceDate LIKE \'" + invoiceDate + "%\'";
                return sSQL;
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This SQL gets all data on any invoices for a given Invoice Number, Invoice Date, and invoice Total Cost.
        /// </summary>
        /// <param name="sInvoiceID">The Invoice Number for the invoice to be retrieved.</param>
        /// <param name="invoiceDate">The Invoice Date for the invoices to be retrieved.</param>
        /// <param name="totalCost">The invoice Total Cost for the invoices to be retrieved.</param>
        /// <returns>SQL string to get: All data for the selected invoices.</returns>
        public static string SelectInvoiceByIdDateCost(string sInvoiceID, string invoiceDate, string totalCost)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID +
                    " AND InvoiceDate LIKE \'" + invoiceDate + "%\'" +
                    " AND TotalCost = " + totalCost;
                return sSQL;
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This SQL gets all data on any invoices for a given Invoice Number and invoice Total Cost.
        /// </summary>
        /// <param name="sInvoiceID">The Invoice Number for the invoice to be retrieved.</param>
        /// <param name="totalCost">The invoice Total Cost for the invoices to be retrieved.</param>
        /// <returns>SQL string to get: All data for the selected invoices.</returns>
        public static string SelectInvoiceByIdCost(string sInvoiceID, string totalCost)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID +
                    " AND TotalCost = " + totalCost;
                return sSQL;
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This SQL gets all data on any invoices for a given Invoice Date.
        /// </summary>
        /// <param name="invoiceDate">The Invoice Date for the invoices to be retrieved.</param>
        /// <returns>SQL string to get: All data for the selected invoices.</returns>
        public static string SelectInvoiceByDate(string invoiceDate)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceDate LIKE \'" + invoiceDate + "%\'";
                return sSQL;
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This SQL gets all data on any invoices for a given Invoice Date and invoice Total Cost.
        /// </summary>
        /// <param name="invoiceDate">The Invoice Date for the invoices to be retrieved.</param>
        /// <param name="totalCost">The invoice Total Cost for the invoices to be retrieved.</param>
        /// <returns>SQL string to get: All data for the selected invoices.</returns>
        public static string SelectInvoiceByDateCost(string invoiceDate, string totalCost)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceDate LIKE \'" + invoiceDate + "%\'" +
                    " AND TotalCost = " + totalCost;
                return sSQL;
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This SQL gets all data on any invoices with a given Total Cost.
        /// </summary>
        /// <param name="totalCost">The invoice Total Cost for the invoices to be retrieved.</param>
        /// <returns>SQL string to get: All data for the selected invoices.</returns>
        public static string SelectInvoiceByCost(string totalCost)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + totalCost;
                return sSQL;
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
