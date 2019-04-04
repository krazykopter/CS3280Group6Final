using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Controls;

namespace Group6FinalProject.Main
{
    class ClsMainLogic
    {
        /// <summary>
        /// new database instance
        /// </summary>
        public static clsDataAccess db;

        public ClsMainLogic()
        {
            db = new clsDataAccess(); //setup database clsDataAcess w/ class
        }

        /// <summary>
        /// this function will fill any combo box that requires a list of all items from the DB
        /// </summary>
        /// <param name="cb">The ComboBox to be filled</param>
        public static void PopulateItemComboBox(ComboBox cb)
        {
            try
            {
                // string sSQL = ClsMainSQL.
                string sSQL = ClsMainSQL.SelectAllItemNames();
                int iRet = 0;
                DataSet ds = new DataSet();

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);                

                for (int i = 0; i < iRet; i++)
                {
                    cb.Items.Add(ds.Tables[0].Rows[i][0]);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Populate combo box that need a list of all invoices
        /// </summary>
        public static void PopulateInvoiceComboBox(ComboBox cb)
        {
            try
            {
                string sSQL = ClsMainSQL.SelectAllInvoices();
                int iRet = 0;
                DataSet ds = new DataSet();

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    cb.Items.Add(ds.Tables[0].Rows[i][0]);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }            
        }

        /// <summary>
        /// Populate items on the edit invoice page
        /// </summary>
        /// <param name="invoiceID">Deteremines which invoice to pull items from</param>
        public static void PopulateItemsForInvoice(string invoiceID)
        {
            try
            {
                string sSQL = ClsMainSQL.SelectInvoiceItems(invoiceID);
                int iRet = 0;
                DataSet ds = new DataSet();

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    WndMain.main.Edit_DeleteItemComboBox.Items.Add(ds.Tables[0].Rows[i][0]);
                }

            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



    }
}
