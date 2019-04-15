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
            try
            {
                string sSQL = "SELECT * FROM ItemDesc";
                return sSQL;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets the price of an item for the given ItemCode. Used to populate the price box in new invoice window 
        /// </summary>
        /// <param name="itemCode">The Character that corresponds to the item identity</param>
        /// <returns>The cost for given item</returns>
        public static string SelectItemPrice(string itemCode)
        {
            try
            {
                string sSQL = "SELECT Cost FROM ItemDesc WHERE ItemCode = " + itemCode;
                return sSQL;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets all of the invoices to populate the "Select Invoice" combo box in the Edit Invoice tab of the Main window
        /// </summary>
        /// <returns>A list of all invoices</returns>
        public static string SelectAllInvoices()
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices";
                return sSQL;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID (populate combo box on edit page)
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the Invoice in question</param>
        /// <returns>All data for the given invoice</returns>
        public static string SelectInvoiceItems(string invoiceID)
        {
            try
            {
                //SELECT* FROM(Invoices LEFT JOIN LineItems ON Invoices.InvoiceNum = LineItems.InvoiceNum) LEFT JOIN ItemDesc ON LineItems.ItemCode = ItemDesc.ItemCode WHERE Invoices.InvoiceNum = 5001
                string sSQL = "SELECT LineItems.ItemCode, ItemDesc, Cost FROM (Invoices LEFT JOIN LineItems ON Invoices.InvoiceNum = LineItems.InvoiceNum) LEFT JOIN ItemDesc ON LineItems.ItemCode = ItemDesc.ItemCode WHERE Invoices.InvoiceNum = " + invoiceID;
                return sSQL;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Find the biggest previous number and add 1
        /// </summary>
        /// <returns></returns>
        public static string SelectNewInvoiceNumber()
        {
            try
            {
                string sSQL = "SELECT MAX(InvoiceNum)+1 FROM Invoices";
                return sSQL;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Execute Non-Query to create new invoice in db
        /// </summary>
        /// <returns></returns>
        public static string SaveNewInvoice(string invoiceNumber, string currentDate, int totalPrice)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices(InvoiceNum, InvoiceDate, TotalCost) VALUES" +
                "(" + invoiceNumber + ", '" + currentDate + "', " + totalPrice + ")";
                return sSQL;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Used for a non query to insert an item into a invoice in the db
        /// </summary>
        /// <returns></returns>
        public static string AddItemToInvoice(string invoiceNumber, int lineItemNumber, string itemCode)
        {
            try
            {
                string sSQL = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES" +
              "(" + invoiceNumber + ", " + lineItemNumber + ", '" + itemCode + "')";
                return sSQL;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Used for a non query to delete for given invoice number
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        public static string DeleteInvoiceLineItems(string invoiceNumber)
        {
            try
            {
                string sSQL = "DELETE FROM LineItems WHERE InvoiceNum = " + invoiceNumber;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Used for a non query to delete for given invoice number
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        public static string DeleteInvoice(string invoiceNumber)
        {
            try
            {
                string sSQL = "DELETE FROM Invoices WHERE InvoiceNum = " + invoiceNumber;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
