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

/*
    Michael W. Craig, W01092948
*/

namespace Group6FinalProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class WndItems : Window
    {
        #region Constructor
        /// <summary>
        /// wndItems constructor
        /// </summary>
        /// <param name="mainWindow"></param>
        public WndItems(Window mainWindow)
        {
            try
            {
                InitializeComponent();

                this.mainWindow = mainWindow;
                db = new clsDataAccess();
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }            
        }
        #endregion
        #region Attributes
        /// <summary>
        /// reference to wndMain
        /// </summary>
        private Window mainWindow;

        /// <summary>
        /// References the data access object
        /// used to make queries to the database
        /// </summary>
        public static clsDataAccess db;
        #endregion
        #region Methods
        /// <summary>
        /// This method allows the user to create a new item and store it in the database after click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: Needs to allow the user to input an itemCode, cost, and ItemDesc and store it in the database
                // should check for valid itemCode options
                // should check for valid data types
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method allows the user to edit an existing item and update the database after click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: Should take the currently selected item from the datagrid and update user changes to the database
                
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method allows the user to attempt to delete an item. Deletes if the item isn't in an invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: should take the currently selected item from the datagrid
                // check to see if it exists within an invoice
                // Warn the user and not allow deletion if it is
                // delete the item from the database if it isn't in any invoices
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is used to refresh the list in the gridbox
        /// </summary>
        private void updateWndItems()
        {
            try
            {
                // TODO: Needs to update the gridbox with the current list of all items
                // the gridbox will need to be updated after every change (add, edit, delete)
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method keeps the user from destroying the wndItems object while reseting that window
        /// and returning the user to wndMain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // only allowed to run if application isn't already closing down 
                // (prevent exception of accessing previously closed windows)
                //    taken from wndSearch.xaml.cs
                if (mainWindow.IsVisible || this.IsVisible)
                {
                    mainWindow.Visibility = Visibility.Visible; // make mainWindow visible
                    this.Visibility = Visibility.Hidden;        // make this window hidden
                    //this.Hide(); could work as well

                    // TODO: call 

                    e.Cancel = true;                            // don't let the user destroy this object
                }
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }            
        }
        #endregion
    }
}