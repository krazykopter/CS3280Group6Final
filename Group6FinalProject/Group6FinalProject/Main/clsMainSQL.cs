using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public static  string SelectAllItems()
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
            string sSQL = "SELECT LineItems.ItemCode, ItemDesc, Cost FROM (Invoices LEFT JOIN LineItems ON Invoices.InvoiceNum = LineItems.InvoiceNum) LEFT JOIN ItemDesc ON LineItems.ItemCode = ItemDesc.ItemCode WHERE Invoices.InvoiceNum = " + invoiceID;
            return sSQL;
        }

        /// <summary>
        /// Find the biggest previous number and add 1
        /// </summary>
        /// <returns>biggest invoice number + 1</returns>
        public static string SelectNewInvoiceNumber()
        {
            string sSQL = "SELECT MAX(InvoiceNum)+1 FROM Invoices";
            return sSQL;
        }

        /// <summary>
        /// Execute Non-Query to create new invoice in db
        /// </summary>
        /// <param name="invoiceNumber">invoiec number</param>
        /// <param name="invoiceDate">crrent date</param>
        /// <param name="totalPrice"> total price</param>
        /// <returns>sql string for non query</returns>
        public static string SaveNewInvoice(string invoiceNumber, string invoiceDate, int totalPrice)
        {
            string sSQL = "INSERT INTO Invoices(InvoiceNum, InvoiceDate, TotalCost) VALUES" +
            "(" + invoiceNumber + ", '" + invoiceDate + "', " + totalPrice + ")";
            return sSQL;
        }

        /// <summary>
        /// Used for a non query to insert an item into a invoice in the db
        /// </summary>
        /// <param name="invoiceNumber">invoice number</param>
        /// <param name="lineItemNumber">line item number</param>
        /// <param name="itemCode">item letter code</param>
        /// <returns>sql string to add items</returns>
        public static string AddItemToInvoice(string invoiceNumber, int lineItemNumber, string itemCode)
        {
            string sSQL = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES" +
            "(" + invoiceNumber + ", " + lineItemNumber + ", '" + itemCode + "')";
            return sSQL;
        }

        /// <summary>
        /// Used for a non query to delete for given invoice number
        /// </summary>
        /// <param name="invoiceNumber">invoice number</param>
        /// <returns>sql string for delete non query</returns>
        public static string DeleteInvoiceLineItems(string invoiceNumber)
        {
            string sSQL = "DELETE FROM LineItems WHERE InvoiceNum = " + invoiceNumber;
            return sSQL;
        }

        /// <summary>
        /// Used for a non query to delete for given invoice number
        /// </summary>
        /// <param name="invoiceNumber">invoicenumber</param>
        /// <returns>sql string for delete non query</returns>
        public static string DeleteInvoice(string invoiceNumber)
        {
            string sSQL = "DELETE FROM Invoices WHERE InvoiceNum = " + invoiceNumber;
            return sSQL;
        }

        /// <summary>
        /// this method will allow for the invoice and items to be updated when saved in the edit window
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="newTotalPrice"></param>
        /// <returns>sql string to update invoice info</returns>
        public static string UpdateInvoiceTotalPrice(string invoiceNumber, int newTotalPrice)
        {
            string sSQL = "UPDATE Invoices SET TotalCost = " + newTotalPrice + " WHERE InvoiceNum = " + invoiceNumber;
            return sSQL;
        }

    }
}
