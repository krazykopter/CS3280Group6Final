using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*
    Michael W. Craig, W01092948
*/

namespace Group6FinalProject.Items
{
    // The purpose of this form is to update the def table, which contains all the items for the business
    class ClsItemsLogic
    {
        #region Attributes
        /// <summary>
        /// References the data access object
        /// used to make queries to the database
        /// </summary>
        private static clsDataAccess db = new clsDataAccess();
        #endregion

        #region Methods
        /// <summary>
        /// This method populates class attribute itemList with all of the items and returns it
        /// </summary>
        /// <returns>itemList</returns>
        public static ObservableCollection<ClsItem> populateItemGridBox()
        {
            try
            {
                ObservableCollection<ClsItem> itemList = new ObservableCollection<ClsItem>();
                DataSet ds = new DataSet();
                int iRetVal = 0;

                string sSQL = ClsItemsSQL.SelectItems();

                ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);

                for (int i = 0; i < iRetVal; i++)
                {
                    ClsItem oneItem = new ClsItem
                    {
                        ItemCode = ds.Tables[0].Rows[i][0].ToString(),
                        ItemDescription = ds.Tables[0].Rows[i][1].ToString(),
                        ItemPrice = Int32.Parse(ds.Tables[0].Rows[i][2].ToString())
                    };

                    itemList.Add(oneItem);
                }
                return itemList;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method checks to see if an item is on any invoices
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns>if the item is on any invoices, return true. Otherwise return false</returns>
        public static bool IsOnInvoice(string code)
        {
            try
            {
                int iRetVal = 0;

                string sSQL = ClsItemsSQL.SelectDistinctInvoice(code);

                db.ExecuteSQLStatement(sSQL, ref iRetVal);

                if(iRetVal < 1) // only return false if the return value is less than 1 (possible scalability issue if database size exceeds max int size)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an item code and returns which invoices that item appears in
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns>invoiceList</returns>
        public static string WhichInvoice(string itemCode)
        {
            try
            {
                ObservableCollection<ClsItem> itemList = new ObservableCollection<ClsItem>();
                DataSet ds = new DataSet();
                int iRetVal = 0;

                string invoiceList = "This item is contained in invoice(s): "; // beginning of the invoice list message

                string sSQL = ClsItemsSQL.SelectDistinctInvoice(itemCode);  // stores the SQL statement in a local string variable

                ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);             // executes the SQL statement and stores each invoice number as a row in the dataset

                for (int i = 0; i < iRetVal; i++)                           // cycle through each row in the dataset and add the 
                {
                    invoiceList += ds.Tables[0].Rows[i][0].ToString();      // add each invoice number to the string
                    invoiceList += " ";                                     // add a space between invoice numbers
                }
                return invoiceList;                                         // return the completed string to the calling object/method
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method creates a new item and stores it in the database
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cost"></param>
        /// <param name="desc"></param>
        public static void NewItem(string code, string desc, int cost)
        {
            try
            {
                string sSQL = ClsItemsSQL.InsertItem(code, desc, cost); // store the SQL statement in a local variable
                db.ExecuteNonQuery(sSQL);                               // execute the SQL statement
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method edits an item and updates the database
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        public static void EditItem(string code, string desc, int cost)
        {
            try
            {
                string sSQL = ClsItemsSQL.UpdateItem(code, desc, cost); // store the SQL statement in a local variable
                db.ExecuteNonQuery(sSQL);                               // execute the SQL statement
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method deletes an item
        /// </summary>
        /// <param name="itemCode"></param>
        public static void DeleteItem(string itemCode)
        {
            try
            {
                if (!IsOnInvoice(itemCode)) {                       // if the item is not on an invoice:
                    string sSQL = ClsItemsSQL.DeleteItem(itemCode); // store the SQL statement in a local variable
                    db.ExecuteNonQuery(sSQL);                       // execute the SQL statement
                }                                                   // this should be a redundant check
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }// end class
}// end namespace