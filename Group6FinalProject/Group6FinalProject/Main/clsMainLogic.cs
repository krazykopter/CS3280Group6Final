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
                List<string> list = new List<string>();
                DataSet ds = new DataSet();
                int iRetVal = 0;

                string sSQL = ClsMainSQL.SelectAllItemNames();

                ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);

                cb.Items.Clear();   //clear out previous list

                for (int i = 0; i < iRetVal; i++)
                {
                    ClsItem ci = new ClsItem
                    {
                        itemCode = ds.Tables[0].Rows[i][0].ToString(),
                        itemDescription = ds.Tables[0].Rows[i][1].ToString(),
                        itemPrice = Decimal.Parse(ds.Tables[0].Rows[i][2].ToString())   //how to get actual decimal from database?
                    };

                    cb.Items.Add(ci);

                    //if (Decimal.TryParse(ds.Tables[0].Rows[i][2].ToString(), out var value))
                    //{
                    //    ci.itemPrice = value;
                    //}
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
                List<string> list = new List<string>();
                DataSet ds = new DataSet();
                int iRetVal = 0;

                string sSQL = ClsMainSQL.SelectAllInvoices();

                ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);

                cb.Items.Clear();   //clear out previous list

                for (int i = 0; i < iRetVal; i++)
                {
                    ClsInvoice ci = new ClsInvoice
                    {
                        invoiceNum = ds.Tables[0].Rows[i][0].ToString(),
                        invoiceDate = Convert.ToDateTime(ds.Tables[0].Rows[i][1].ToString()),
                        totalCost = decimal.Parse(ds.Tables[0].Rows[i][2].ToString())
                    };

                    cb.Items.Add(ci);
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

                WndMain.main.Edit_DeleteItemComboBox.Items.Clear(); //clear out previous list

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
