using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Group6FinalProject.Search
{
    /// <summary>
    /// Main Business Logic for Search window
    /// Retrieves a SQL statement as a string from clsSearchSQL.cs
    /// then uses an instance of the DBO to retrieve the needed
    /// list of invoices and displays them
    /// 
    /// This class created by Brad Christensen
    /// </summary>
    static class clsSearchLogic
    {
        #region Attributes
        /// <summary>
        /// References the Search Window
        /// </summary>
        private static WndSearch WndSearch1;
        /// <summary>
        /// References the data access object
        /// used to make queries to the database
        /// </summary>
        private static clsDataAccess db;
        /// <summary>
        /// List of invoices to be displayed in the Search Window data grid
        /// </summary>
        private static List<ClsInvoice> lInvoices;
        /// <summary>
        /// The invoice number used to search the database for a specific invoice
        /// </summary>
        private static string invoiceNum = "";
        /// <summary>
        /// The invoice date used to search the database for all invoices from a certain day
        /// </summary>
        private static string invoiceDate = "";
        /// <summary>
        /// The total cost of an invoice, used to search the database for all invoices with that total
        /// </summary>
        private static string totalCost = "";
        #endregion


        #region Methods
        /// <summary>
        /// This method sets the Search Window reference, data access object reference,
        /// and initializes the invoice list. It is called first, from the Search Window constructor.
        /// </summary>
        /// <param name="newWndSearch">Reference to the Search Window object</param>
        /// <param name="newDb">Reference to the Data Access Object</param>
        public static void setDB(WndSearch newWndSearch, clsDataAccess newDb)
        {
            try
            {
                WndSearch1 = newWndSearch;
                db = newDb;
                lInvoices = new List<ClsInvoice>();
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Used to reset the attributes that correspond to the selection drop down
        /// values in the Search Window
        /// </summary>
        public static void clearSelection()
        {
            try
            {
                string sql;

                // reset all invoice attributes
                invoiceNum = "";
                invoiceDate = "";
                totalCost = "";

                // display all invoices
                sql = clsSearchSQL.SelectAllInvoices();
                populateInvoiceList(sql);
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Called when an invoice number is selected in the Search Window drop down list
        /// Updates the data grid accordingly
        /// </summary>
        /// <param name="newInvoiceNum">Invoice Number selected in the Search Window drop down list</param>
        public static void setInvoiceNum(string newInvoiceNum)
        {
            try
            {
                invoiceNum = newInvoiceNum;

                customInvoiceList();
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Called when a date is selected in the Search Window drop down list
        /// Updates the data grid accordingly
        /// </summary>
        /// <param name="newInvoiceDate">Date selected in the Search Window drop down list</param>
        public static void setInvoiceDate(string newInvoiceDate)
        {
            try
            {
                string sDateOnly = "";

                // coming in the date looks like "4/23/2018 12:00:00 AM" cut off the time
                // to show all purchases made that day
                for (int i = 0; i < newInvoiceDate.Length; i++)
                {
                    if (newInvoiceDate[i] == ' ')
                    {
                        break;
                    }
                    sDateOnly += newInvoiceDate[i];
                }

                invoiceDate = sDateOnly;

                customInvoiceList();
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Called when a total cost is selected in the Search Window drop down list
        /// Updates the data grid accordingly
        /// </summary>
        /// <param name="newTotalCost">Total Cost selected in the Search Window drop down list</param>
        public static void setTotalCost(string newTotalCost)
        {
            try
            {
                totalCost = newTotalCost;

                customInvoiceList();
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Called when a new value is selected from a Search Window drop down box
        /// Retrieves a SQL query string accordingly and passes it to populateInvoiceList()
        /// </summary>
        private static void customInvoiceList()
        {
            try
            {
                string sql;

                // determine which invoice attributes have been set
                // if only invoice number has been set
                if (invoiceNum != "" && invoiceDate == "" && totalCost == "")
                {
                    sql = clsSearchSQL.SelectInvoiceById(invoiceNum);
                }
                else if (invoiceNum != "" && invoiceDate != "" && totalCost == "")
                {
                    sql = clsSearchSQL.SelectInvoiceByIdDate(invoiceNum, invoiceDate);
                }
                else if (invoiceNum != "" && invoiceDate != "" && totalCost != "")
                {
                    sql = clsSearchSQL.SelectInvoiceByIdDateCost(invoiceNum, invoiceDate, totalCost);
                }
                else if (invoiceNum != "" && invoiceDate == "" && totalCost != "")
                {
                    sql = clsSearchSQL.SelectInvoiceByIdCost(invoiceNum, totalCost);
                }
                else if (invoiceNum == "" && invoiceDate != "" && totalCost == "")
                {
                    sql = clsSearchSQL.SelectInvoiceByDate(invoiceDate);
                }
                else if (invoiceNum == "" && invoiceDate != "" && totalCost != "")
                {
                    sql = clsSearchSQL.SelectInvoiceByDateCost(invoiceDate, totalCost);
                }
                else if (invoiceNum == "" && invoiceDate == "" && totalCost != "")
                {
                    sql = clsSearchSQL.SelectInvoiceByCost(totalCost);
                }
                else
                {
                    sql = clsSearchSQL.SelectAllInvoices();
                }

                populateInvoiceList(sql);
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Creates a SQL query string to get all invoices and passes it to populateInvoiceList()
        /// </summary>
        public static void getAllInvoices()
        {
            try
            {
                string sql;

                sql = clsSearchSQL.SelectAllInvoices();
                populateInvoiceList(sql);

                // now populate the drop-down boxes using the same complete list of invoices
                populateDropDownBoxes();
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Populates a list of invoices based on current invoice number, date, and total cost selections
        /// Passes the list to displayInvoices()
        /// </summary>
        /// <param name="sql">The SQL query used to populate a list of invoices</param>
        private static void populateInvoiceList(string sql)
        {
            try
            {
                DataSet ds;
                // number of return values
                int iRet = 0;

                ds = db.ExecuteSQLStatement(sql, ref iRet);

                // make sure the list is empty first
                lInvoices.Clear();

                // add all invoices from the table to the invoices list
                for (int i = 0; i < iRet; i++)
                {
                    ClsInvoice invoice = new ClsInvoice();
                    invoice.InvoiceNum = ds.Tables[0].Rows[i][0].ToString();
                    invoice.InvoiceDate = Convert.ToDateTime(ds.Tables[0].Rows[i][1]);
                    invoice.TotalCost = Convert.ToDecimal(ds.Tables[0].Rows[i][2]);
                    lInvoices.Add(invoice);
                }

                // display the populated list of invoices
                displayInvoices();
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Displays all invoices from the list of invoices created by populateInvoiceList()
        /// in the data grid on the Search Window
        /// </summary>
        private static void displayInvoices()
        {
            try
            {
                // clear out the data grid before updating
                WndSearch1.dgdAllInvoices.ItemsSource = null;
                WndSearch1.dgdAllInvoices.Columns.Clear();

                WndSearch1.dgdAllInvoices.AutoGenerateColumns = false;

                // credit: https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.datagrid.columns?view=netframework-4.7.2
                //Create a new column to add to the DataGrid
                DataGridTextColumn textcol1 = new DataGridTextColumn();
                //Create a Binding object to define the path to the DataGrid.ItemsSource property
                //The column inherits its DataContext from the DataGrid, so you don't set the source
                Binding bINum = new Binding("InvoiceNum");
                //Set the properties on the new column
                textcol1.Binding = bINum;
                textcol1.Header = "Invoice Number";
                //Add the column to the DataGrid
                WndSearch1.dgdAllInvoices.Columns.Add(textcol1);

                DataGridTextColumn textcol2 = new DataGridTextColumn();
                Binding bIDate = new Binding("InvoiceDate");
                textcol2.Binding = bIDate;
                textcol2.Header = "Invoice Date";
                WndSearch1.dgdAllInvoices.Columns.Add(textcol2);

                DataGridTextColumn textcol3 = new DataGridTextColumn();
                Binding bTCost = new Binding("TotalCost");
                textcol3.Binding = bTCost;
                textcol3.Header = "Total Cost";
                WndSearch1.dgdAllInvoices.Columns.Add(textcol3);

                WndSearch1.dgdAllInvoices.ItemsSource = lInvoices;
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Populates the drop down selection boxes on the Search Window used to narrow the list
        /// of invoices shown in the data grid.
        /// </summary>
        private static void populateDropDownBoxes()
        {
            try
            {
                // create lists of invoice dates and total costs to be ordered for display
                List<DateTime> lDates = new List<DateTime>();
                List<decimal> lTotalCosts = new List<decimal>();

                // iterate through the list of invoices and add them to the combo boxes
                foreach (ClsInvoice invoice in lInvoices)
                {
                    // display the invoice number in cboInvoiceNum
                    WndSearch1.cboInvoiceNum.Items.Add(invoice.InvoiceNum);

                    // populate lists to be ordered for date and cost
                    lDates.Add(invoice.InvoiceDate);
                    lTotalCosts.Add(invoice.TotalCost);
                }

                // get rid of any duplicates in the lists
                lDates = lDates.Distinct().ToList();
                lTotalCosts = lTotalCosts.Distinct().ToList();

                // order the lists
                lDates.Sort();
                lTotalCosts.Sort();

                // populate the invoice date combo box
                foreach (DateTime iDate in lDates)
                {
                    // display the invoice date in cboInvoiceDate
                    WndSearch1.cboInvoiceDate.Items.Add(iDate);
                }

                // populate the total cost combo box
                foreach (decimal tCost in lTotalCosts)
                {
                    // display the total cost in cboInvoiceNum
                    WndSearch1.cboTotalCharge.Items.Add(tCost);
                }
            }
            catch (Exception ex)
            {
                //Low level method. Just throw the exception using a readable stack trace.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
