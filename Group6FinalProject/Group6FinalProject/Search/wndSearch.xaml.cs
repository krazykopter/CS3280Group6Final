using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Group6FinalProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// 
    /// This class created by Brad Christensen 
    /// </summary>
    public partial class WndSearch : Window
    {
        /*
         * Credit for wndSearch.xaml layout:
         * Carson Crezee
         * I used the layout from wndMain.xaml created by Carson
         * because it gives the windows a consistent look.
         */

        #region Attributes
        /// <summary>
        /// Reference to the main window (wndMain)
        /// </summary>
        private Window mainWindow;
        /// <summary>
        /// References the data access object
        /// used to make queries to the database
        /// </summary>
        private static clsDataAccess db;
        #endregion


        #region Constructor
        /// <summary>
        /// Search Window Constructor
        /// Passes reference of the Search Window and data access object to clsSearchLogic
        /// </summary>
        /// <param name="mainWindow"></param>
        public WndSearch(Window mainWindow)
        {
            try
            {
                InitializeComponent();

                this.mainWindow = mainWindow;
                db = new clsDataAccess();

                clsSearchLogic.setDB(this, db);
                clsSearchLogic.getAllInvoices();
            }
            catch (Exception ex)
            {
                // Top level method (I call other methods, other methods don't call me).
                // So handle the exception.
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion


        #region Methods
        /// <summary>
        /// Called when user selects a specific invoice number from the Search Window drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // update displayed invoices (if not being reset to "cboTotalCharge.SelectedIndex = -1")
                if (cboInvoiceNum.SelectedIndex > -1)
                {
                    clsSearchLogic.setInvoiceNum(cboInvoiceNum.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                // Top level method (I call other methods, other methods don't call me).
                // So handle the exception.
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Called when user selects a specific invoice date from the Search Window drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // update displayed invoices (if not being reset)
                if (cboInvoiceDate.SelectedIndex > -1)
                {
                    clsSearchLogic.setInvoiceDate(cboInvoiceDate.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                // Top level method (I call other methods, other methods don't call me).
                // So handle the exception.
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Called when user selects a specific invoice total charge from the Search Window drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTotalCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // update displayed invoices (if not being reset)
                if (cboTotalCharge.SelectedIndex > -1)
                {
                    clsSearchLogic.setTotalCost(cboTotalCharge.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                // Top level method (I call other methods, other methods don't call me).
                // So handle the exception.
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Called when user clicks the clear selection button on the Search Window
        /// Resets all drop down lists on the Search Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resetSearchWindow();
            }
            catch (Exception ex)
            {
                // Top level method (I call other methods, other methods don't call me).
                // So handle the exception.
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Called when user clicks the select invoice button on the Search Window
        /// Passes main window the users selected invoice object to be displayed there
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // reset the user prompt
                lblSelectionHelp.Visibility = Visibility.Hidden;

                // call a method in mainWindow and pass it the selected invoice object. (if a selection was made)
                if (dgdAllInvoices.SelectedIndex > -1)
                {
                    // FIXME (Carson): THIS METHOD NEEDS TO BE IMPLEMENTED IN THE MAIN WINDOW AND UNCOMMENTED
                    //mainWindow.displaySearchedInvoice((ClsInvoice) dgdAllInvoices.SelectedItem);

                    // COMMENT OUT, TESTING ONLY
                    // ClsInvoice test = (ClsInvoice) dgdAllInvoices.SelectedItem;

                    resetSearchWindow();

                    // display the main window instead of the search window
                    mainWindow.Visibility = Visibility.Visible;
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    // prompt the user to make a selection first
                    lblSelectionHelp.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                // Top level method (I call other methods, other methods don't call me).
                // So handle the exception.
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Called when user clicks the cancel button on the Search Window
        /// Returns the user to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resetSearchWindow();

                mainWindow.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                // Top level method (I call other methods, other methods don't call me).
                // So handle the exception.
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Called when user clicks the 'x' button in the upper right on the Search Window
        /// Hides the Search Screen rather than Closing it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wdwSearch_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // only allowed to run if application isn't already closing down 
                // (prevent exception of accessing previously closed windows)
                if (mainWindow.IsVisible || this.IsVisible)
                {
                    // we only have one instance of this window, make sure the user doesn't destroy it.
                    e.Cancel = true;

                    resetSearchWindow();

                    mainWindow.Visibility = Visibility.Visible;
                    this.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                // Top level method (I call other methods, other methods don't call me).
                // So handle the exception.
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Resets the drop down box list selections on the Search Window
        /// </summary>
        private void resetSearchWindow()
        {
            try
            {
                // reset the user prompt
                lblSelectionHelp.Visibility = Visibility.Hidden;

                // call method in clsSearchLogic that will clear the data grid
                clsSearchLogic.clearSelection();
                // reset the drop down box selections
                cboInvoiceNum.SelectedIndex = -1;
                cboInvoiceDate.SelectedIndex = -1;
                cboTotalCharge.SelectedIndex = -1;
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
