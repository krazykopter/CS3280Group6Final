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
        #region Methods
        /// <summary>
        /// This SQL selects the ItemCode, ItemDesc, and Cost from the ItemDesc table
        /// </summary>
        /// <returns>all the data for each column selected</returns>
        public static string SelectItems()
        {
            string sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
            return sSQL;
        }

        /// <summary>
        /// This SQL takes the itemCode as an argument and returns any invoice numbers that itemCode appears in
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns>sSQL</returns>
        public static string SelectDistinctInvoice(string itemCode)
        {
            string sSQL = "SELECT DISTINCT(InvoiceNum) FROM LineItems WHERE ItemCode = '" + itemCode + "'";
            return sSQL;
        }

        /// <summary>
        /// This SQL takes the itemCode, itemDesc, and cost as arguments and updates the item description and cost
        /// </summary>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        /// <param name="itemCode"></param>
        /// <returns>sSQL</returns>
        public static string UpdateItem(string itemCode, string itemDesc, int cost)
        {
            string sSQL = "UPDATE ItemDesc SET ItemDesc = '" + itemDesc + "', Cost = " + cost + " WHERE ItemCode = '" + itemCode + "'";
            return sSQL;
        }

        /// <summary>
        /// This SQL takes the arguments and creates a new item in the database
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        /// <returns>sSQL</returns>
        public static string InsertItem(string itemCode, string itemDesc, int cost)
        {
            string sSQL = "INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) Values('" + itemCode + "', '" + itemDesc + "', " + cost + ")";
            return sSQL;
        }

        /// <summary>
        /// takes the item code and deletes that item from the database
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns>sSQL</returns>
        public static string DeleteItem(string itemCode)
        {
            string sSQL = "DELETE FROM ItemDesc WHERE ItemCode = '" + itemCode + "'";
            return sSQL;
        }
        #endregion
    }// end class
}// end namespace