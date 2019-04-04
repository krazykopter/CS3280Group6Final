using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6FinalProject.Main
{
    class ClsMainSQL
    {
        /// <summary>
        /// This SQL gets all items in the database to populate the new invoice & edit invoice combo Boxes
        /// </summary>
        /// <returns>All data for the given invoice</returns>
        public static  string SelectAllItemNames()
        {
            string sSQL = "SELECT * FROM ItemDesc";
            return sSQL;
        }

        /// <summary>
        /// This SQL gets the price of an item for the given ItemCode. Used to populate the price box in new invoice window 
        /// </summary>
        /// <param name="itemCode">The Character that corresponds to the item identity</param>
        /// <returns>The cost for given item</returns>
        public static string SelectItemPrice(string itemCode)
        {
            string sSQL = "SELECT Cost FROM ItemDesc WHERE ItemCode = " + itemCode;
            return sSQL;
        }

        /// <summary>
        /// This SQL gets all of the invoices to populate the "Select Invoice" combo box in the Edit Invoice tab of the Main window
        /// </summary>
        /// <returns>A list of all invoices</returns>
        public static string SelectAllInvoices()
        {
            string sSQL = "SELECT * FROM Invoices";
            return sSQL;
        }

        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID (populate combo box on edit page)
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the Invoice in question</param>
        /// <returns>All data for the given invoice</returns>
        public static string SelectInvoiceItems(string invoiceID)
        {
            //SELECT* FROM(Invoices LEFT JOIN LineItems ON Invoices.InvoiceNum = LineItems.InvoiceNum) LEFT JOIN ItemDesc ON LineItems.ItemCode = ItemDesc.ItemCode WHERE Invoices.InvoiceNum = 5001
            string sSQL = "SELECT ItemDesc FROM (Invoices LEFT JOIN LineItems ON Invoices.InvoiceNum = LineItems.InvoiceNum) LEFT JOIN ItemDesc ON LineItems.ItemCode = ItemDesc.ItemCode WHERE Invoices.InvoiceNum = " + invoiceID;
            return sSQL;
        }

    }
}
