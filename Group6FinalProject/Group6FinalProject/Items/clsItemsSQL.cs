using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Michael W. Craig, W01092948
*/

namespace Group6FinalProject.Items
{
    class ClsItemsSQL
    {
        /*
        The purpose of this form is to update the def table, which contains all the items for the business.
        
        each item consists of a code, cost, and description

        need to be able to add new items

        need to be able to edit existing items (cost and description)
            but not the item code. The item code is the primary key

        need to be able to delete existing items (But not if that item is on an invoice)
            need to warn the user with a message that tells the user which invoices that item is used on
        */

        /*
        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID.
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public string SelectInvoiceData(string sInvoiceID)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;
            return sSQL;
        }
        */
        // select ItemCode, ItemDesc, Cost from ItemDesc

        /// <summary>
        /// This SQL selects the ItemCode, ItemDesc, and Cost from the ItemDesc table
        /// </summary>
        /// <returns>all the data for each column selected</returns>
        public static string selectItems()
        {
            string sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
            return sSQL;
        }

        // select distinct(InvoiceNum) from LineItems where ItemCode = 'A'

        /// <summary>
        /// This SQL takes the itemCode as an argument and returns any invoice numbers that itemCode appears in
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public static string selectDistinctInvoice(string itemCode)
        {
            string sSQL = "SELECT distinct(InvoiceNum) FROM LineItems WHERE ItemCode = " + itemCode;
            return sSQL;
        }

        // Update ItemDesc Set ItemDesc = 'abcdef', Cost = 123 where ItemCode = 'A'

        /// <summary>
        /// This SQL takes the itemCode, itemDesc, and cost as arguments and updates the item description and cost
        /// </summary>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public static string updateItem(string itemCode, string itemDesc, int cost)
        {
            string sSQL = "UPDATE ItemDesc SET ItemDesc = " + itemDesc + ", Cost = " + cost + " WHERE ItemCode = " + itemCode;
            return sSQL;
        }

        // Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('ABC', 'blah', 321)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public static string insertItemDesc(string itemCode, string itemDesc, int cost)
        {
            string sSQL = "INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) Values('" + itemCode + "', '" + itemDesc + "', " + cost + ")";
            return sSQL;
        }

        // Delete from ItemDesc Where ItemCode = 'ABC'

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public static string deleteItemDesc(string itemCode)
        {
            string sSQL = "DELETE FROM ItemDesc WHERE ItemCode = '" + itemCode + "'";
            return sSQL;
        }
    }
}