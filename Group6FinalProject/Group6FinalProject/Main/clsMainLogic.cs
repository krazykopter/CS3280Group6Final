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

        public static ObservableCollection<ClsItem> InvoiceItemsList;    //this will be used to keep track of the list of items while it is being built, before it is saved

        public ClsMainLogic()
        {
            db = new clsDataAccess(); //setup database clsDataAcess w/ class
        }
       

        /// <summary>
        /// A simple method to create a collection to use while adding items to new invoice
        /// </summary>
        public static void CreateNewItemCollection()
        {
            if(InvoiceItemsList != null)
            {
                InvoiceItemsList.Clear();
            }
            InvoiceItemsList = new ObservableCollection<ClsItem>();
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
                        //ItemPrice = Decimal.Parse(ds.Tables[0].Rows[i][2].ToString())   //how to get actual decimal from database?
                        ItemPrice = Int32.Parse(ds.Tables[0].Rows[i][2].ToString())   //how to get actual decimal from database?
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
                        //ItemPrice = Decimal.Parse(ds.Tables[0].Rows[i][2].ToString())   //how to get actual decimal from database?
                        ItemPrice = Int32.Parse(ds.Tables[0].Rows[i][2].ToString())   //how to get actual decimal from database?
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
        public static void AddNewItem(object selection)
        {
            try
            {
                ClsItem ci = new ClsItem
                {
                    ItemCode = ((Group6FinalProject.ClsItem)selection).ItemCode,
                    ItemDescription = ((Group6FinalProject.ClsItem)selection).ItemDescription,
                    ItemPrice = ((Group6FinalProject.ClsItem)selection).ItemPrice
                };

                InvoiceItemsList.Add(ci);
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// this method calculates the total price of all objects in the invoice
        /// </summary>
        public static int CalculateInvoiceTotal()
        {   
            try
            {
                int totalAmount = 0;

                foreach (ClsItem i in InvoiceItemsList)
                {
                    totalAmount += i.ItemPrice;
                }

                return totalAmount;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// saves the newly created invoice and adds the items to it
        /// </summary>
        /// <returns>invoice number to be shown to user</returns>
        public static string SaveNewInvoice(string date)
        {
            try
            {
                //Pull the SQL Strings
                string invoiceNumSQL = ClsMainSQL.SelectNewInvoiceNumber();     //the biggest invoice number that exists + 1

                //Get all values needed
                string invoiceNum = db.ExecuteScalarSQL(invoiceNumSQL);                
                int totalPrice = CalculateInvoiceTotal();

                //get string to add the invoice database
                string newInvoiceSQL = ClsMainSQL.SaveNewInvoice(invoiceNum, date, totalPrice);
                db.ExecuteNonQuery(newInvoiceSQL);

                int lineItemNumber = 1;

                //go through each item in the list and write to the database under the same invoice number
                foreach(ClsItem i in InvoiceItemsList)
                {
                    string addSQL = ClsMainSQL.AddItemToInvoice(invoiceNum, lineItemNumber++, i.ItemCode);
                    db.ExecuteNonQuery(addSQL);
                }

                return invoiceNum;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// uses SQL to delete invoice in the entire database including line items
        /// </summary>
        /// <param name="invoiceNumber"></param>
        public static void DeleteInvoice(string invoiceNumber)
        {
            try
            {
                string delLineItems = ClsMainSQL.DeleteInvoiceLineItems(invoiceNumber);
                string delInvoice = ClsMainSQL.DeleteInvoice(invoiceNumber);

                db.ExecuteNonQuery(delLineItems);
                db.ExecuteNonQuery(delInvoice);
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static void UpdateInvoiceInformation(string invoiceNumber, int newTotalPrice)
        {
            try
            {
                string updateInvoice = ClsMainSQL.UpdateInvoiceTotalPrice(invoiceNumber, newTotalPrice);
                string deleteLineItems = ClsMainSQL.DeleteInvoiceLineItems(invoiceNumber);     //instead of trying to update them, just delete all and reload

                db.ExecuteNonQuery(updateInvoice);
                db.ExecuteNonQuery(deleteLineItems);

                int lineItemNumber = 1;

                //go through each item in the list and write to the database under the same invoice number
                foreach (ClsItem i in InvoiceItemsList)
                {
                    string addSQL = ClsMainSQL.AddItemToInvoice(invoiceNumber, lineItemNumber++, i.ItemCode);
                    db.ExecuteNonQuery(addSQL);
                }
            }

            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}