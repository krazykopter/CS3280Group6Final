using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Reflection;
using System.Data;


/* CARSON TO DO
 * ------------
 *  Move all code out of the UI
 *  Add total price on invoice page
*/

namespace Group6FinalProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    /// </summary>
    public partial class WndMain : Window
    {
        public static WndMain main;
        // CHANGE (ADDED):
        Window searchWindow;
        /* CHANGE (REMOVED):
        ClsMainLogic clsMainLogic;
        */

        public WndMain()
        {
            InitializeComponent();
            main = this;
            // CHANGE (ADDED): Make sure to close all additional windows in the application
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            /* CHANGE (REMOVED)
            clsMainLogic = new ClsMainLogic();
            */
            // CHANGE (ADDED):
            searchWindow = new Search.WndSearch(main);
        }

        /// <summary>
        /// Method to handle the click of the New Invoice Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClsMainLogic.PopulateItemComboBox(main.NewInvoice_ItemComboBox);    //populate combo boxes
                ClsMainLogic.NewInvoice_CreateNewItemCollection();
                ClsMainLogic.ShowNewInvoiceCanvas();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method to handle the click of the Edit Invoice Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClsMainLogic.PopulateItemComboBox(main.Edit_AddItemComboBox);               //populate Edit Add Item Combo Box
                ClsMainLogic.PopulateInvoiceComboBox(main.Edit_SelectInvoiceComboBox);      //populate Edit Select Invoice Combo Box
                ClsMainLogic.ShowEditInvoiceCanvas();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method to handle the click of the Delete Invoice Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClsMainLogic.PopulateInvoiceComboBox(main.Delete_SelectInvoiceComboBox);    //populate combo box
                ClsMainLogic.ShowDeleteInvoiceCanvas();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method to handle the click of the Update Table Menu Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window itemsWindow = new Items.WndItems();
                itemsWindow.Visibility = Visibility.Visible;
                main.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method to handle the click of the Search Menu Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /* CHANGE (REMOVED):
                Window searchWindow = new Search.WndSearch();
                */
                searchWindow.Visibility = Visibility.Visible;
                main.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method that handles the changing of the Invoice Selection Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_SelectInvoiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selection = Edit_SelectInvoiceComboBox.SelectedItem;
                var invoiceID = ((Group6FinalProject.ClsInvoice)selection).InvoiceNum.ToString();

                ClsMainLogic.PopulateItemsForInvoice(invoiceID, Edit_DeleteItemComboBox);

                //get the invoice number,
                // run query to fill in the item box & DATA GRID for selected invoice
                Edit_AddItemComboBox.IsEnabled = true;
                Edit_DeleteItemComboBox.IsEnabled = true;
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method to handle the changing of the New Invoice Item Combo Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoice_ItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selection = NewInvoice_ItemComboBox.SelectedItem;
                if(selection != null)
                {
                    var price = ((Group6FinalProject.ClsItem)selection).ItemPrice;
                    WndMain.main.NewInvoice_PriceBox.Text = "$" + Decimal.Round(price, 2);
                }
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This function adds the selected item from the combo box to the invoice & data grid ON THE NEW INVOICE PAGE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoice_AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClsMainLogic.NewInvoice_AddNewItem();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Adds the selected item from the combo box to the invoice & data grid ON THE EDIT INVOICE PAGE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //get the item id selected in the combo box
                //add item to the list that will populate the data grid            
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the item selected in the combo box from the invoice & data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItemEditWindowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //get the item id selected in the combo box
                //delete item from the list
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Gets the invoice number from the combo box and deletes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoiceButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //get invoice id from combo box
                // run query to delete the invoice
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method handles all exceptions that have risen from lower level methods
        /// </summary>
        /// <param name="sClass"> The class where the error occurred </param>
        /// <param name="sMethod"> The method where the error occurred </param>
        /// <param name="sMessage"> The error message from the exception </param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
