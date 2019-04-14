using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace Group6FinalProject.Main
{
    class ClsMainLogic
    {
        /// <summary>
        /// new database instance
        /// </summary>
        public static clsDataAccess db;

        public static ObservableCollection<ClsItem> NewInvoiceItemsList;    //this will be used to keep track of the list of items while it is being built, before it is saved

        public ClsMainLogic()
        {
            db = new clsDataAccess(); //setup database clsDataAcess w/ class
        }
        

        /// <summary>
        /// Hides all other Main Window Canvas' and shows New Invoice
        /// </summary>
        public static void ShowNewInvoiceCanvas()
        {
            WndMain.main.NewInvoiceCanvas.Visibility = Visibility.Visible;
            WndMain.main.EditInvoiceCanvas.Visibility = Visibility.Hidden;
            WndMain.main.DeleteInvoiceCanvas.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Hides all other Main Window Canvas' and shows Edit Invoice
        /// </summary>
        public static void ShowEditInvoiceCanvas()
        {
            WndMain.main.EditInvoiceCanvas.Visibility = Visibility.Visible;
            WndMain.main.NewInvoiceCanvas.Visibility = Visibility.Hidden;
            WndMain.main.DeleteInvoiceCanvas.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Hides all other Main Window Canvas' and shows Delete Invoice
        /// </summary>
        public static void ShowDeleteInvoiceCanvas()
        {
            WndMain.main.DeleteInvoiceCanvas.Visibility = Visibility.Visible;
            WndMain.main.NewInvoiceCanvas.Visibility = Visibility.Hidden;
            WndMain.main.EditInvoiceCanvas.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// A simple method to create a collection to use while adding items to new invoice
        /// </summary>
        public static void NewInvoice_CreateNewItemCollection()
        {
            if(NewInvoiceItemsList != null)
            {
                NewInvoiceItemsList.Clear();
            }
            NewInvoiceItemsList = new ObservableCollection<ClsItem>();
        }

        /// <summary>
        /// this function will fill any combo box that requires a list of all items from the DB
        /// </summary>
        public static List<ClsItem> PopulateItemComboBox()
        {
            try
            {
                List<ClsItem> itemList = new List<ClsItem>();
                DataSet ds = new DataSet();
                int iRetVal = 0;

                string sSQL = ClsMainSQL.SelectAllItems();

                ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);

                for (int i = 0; i < iRetVal; i++)
                {
                    ClsItem ci = new ClsItem
                    {
                        ItemCode = ds.Tables[0].Rows[i][0].ToString(),
                        ItemDescription = ds.Tables[0].Rows[i][1].ToString(),
                        ItemPrice = Decimal.Parse(ds.Tables[0].Rows[i][2].ToString())   //how to get actual decimal from database?
                    };

                    itemList.Add(ci);
                }

                return itemList;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Populate combo box that need a list of all invoices
        /// </summary>
        public static List<ClsInvoice> PopulateInvoiceComboBox()
        {
            try
            {
                List<ClsInvoice> invoiceList = new List<ClsInvoice>();

                DataSet ds = new DataSet();
                int iRetVal = 0;

                string sSQL = ClsMainSQL.SelectAllInvoices();

                ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);

                for (int i = 0; i < iRetVal; i++)
                {
                    ClsInvoice ci = new ClsInvoice
                    {
                        InvoiceNum = ds.Tables[0].Rows[i][0].ToString(),
                        InvoiceDate = Convert.ToDateTime(ds.Tables[0].Rows[i][1].ToString()),
                        TotalCost = decimal.Parse(ds.Tables[0].Rows[i][2].ToString())
                    };

                    invoiceList.Add(ci);
                }

                return invoiceList;
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
        public static List<ClsItem> PopulateItemsForInvoice(string invoiceID)
        {
            try
            {
                List<ClsItem> itemsList = new List<ClsItem>();

                DataSet ds = new DataSet();
                int iRetVal = 0;

                string sSQL = ClsMainSQL.SelectInvoiceItems(invoiceID);

                ds = db.ExecuteSQLStatement(sSQL, ref iRetVal);

                for (int i = 0; i < iRetVal; i++)
                {
                    ClsItem ci = new ClsItem
                    {
                        ItemCode = ds.Tables[0].Rows[i][0].ToString(),
                        ItemDescription = ds.Tables[0].Rows[i][1].ToString(),
                        ItemPrice = Decimal.Parse(ds.Tables[0].Rows[i][2].ToString())   //how to get actual decimal from database?
                    };
                    itemsList.Add(ci);
                }

                return itemsList;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// /// Populates the data grid using a Collection as the user adds item to the new invoice
        /// </summary>
        /// <param name="selection">object used to find info in combo box</param>
        public static void NewInvoice_AddNewItem(object selection)
        {
            try
            {
                ClsItem ci = new ClsItem
                {
                    ItemCode = ((Group6FinalProject.ClsItem)selection).ItemCode,
                    ItemDescription = ((Group6FinalProject.ClsItem)selection).ItemDescription,
                    ItemPrice = ((Group6FinalProject.ClsItem)selection).ItemPrice
                };

                NewInvoiceItemsList.Add(ci);
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
