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

        //public static ClsHandleError err;

        ClsMainLogic clsMainLogic;

        public WndMain()
        {
            InitializeComponent();
            main = this;
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            //err = new ClsHandleError();

            clsMainLogic = new ClsMainLogic();
            clsWindowManager.MainWindow = main;
            searchWindow = new Search.WndSearch();
            clsWindowManager.SearchWindow = searchWindow;
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
                mainUserDisplayLabel.Content = "";

                NewInvoice_ItemComboBox.Items.Clear();

                var itemList = ClsMainLogic.PopulateItemComboBox();    //populate combo boxes

                foreach(ClsItem i in itemList)
                {
                    NewInvoice_ItemComboBox.Items.Add(i);
                }

                ClsMainLogic.CreateNewItemCollection();
                ShowNewInvoiceCanvas();
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                mainUserDisplayLabel.Content = "";

                Edit_AddItemComboBox.Items.Clear();
                Edit_SelectInvoiceComboBox.Items.Clear();

                var itemList = ClsMainLogic.PopulateItemComboBox();    //populate combo boxes

                foreach (ClsItem i in itemList)
                {
                    Edit_AddItemComboBox.Items.Add(i);
                }

                var invoiceList = ClsMainLogic.PopulateInvoiceComboBox();

                foreach(ClsInvoice i in invoiceList)
                {
                    Edit_SelectInvoiceComboBox.Items.Add(i);
                }

                ShowEditInvoiceCanvas();
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                mainUserDisplayLabel.Content = "";

                Delete_SelectInvoiceComboBox.Items.Clear(); //clear the previous list to avoid duplicates

                var invoiceList = ClsMainLogic.PopulateInvoiceComboBox();

                foreach (ClsInvoice i in invoiceList)
                {
                    Delete_SelectInvoiceComboBox.Items.Add(i);
                }

                ShowDeleteInvoiceCanvas();
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                Window itemsWindow = new Items.WndItems(main);
                itemsWindow.Visibility = Visibility.Visible;
                main.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method that handles the changing of the Invoice Selection Box & enabling of other UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_SelectInvoiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selection = Edit_SelectInvoiceComboBox.SelectedItem;

                if (selection != null)
                {
                    var invoiceID = ((Group6FinalProject.ClsInvoice)selection).InvoiceNum.ToString();

                    ClsMainLogic.CreateNewItemCollection();     //resets a new item collection to be used here

                    var itemsList = ClsMainLogic.PopulateItemsForInvoice(invoiceID);

                    foreach (ClsItem i in itemsList)
                    {
                        ClsMainLogic.InvoiceItemsList.Add(i);
                    }

                    Edit_DataGrid.ItemsSource = ClsMainLogic.InvoiceItemsList;

                    Edit_TotalPriceBox.Text = "$" + ClsMainLogic.CalculateInvoiceTotal();

                    Edit_AddItemComboBox.IsEnabled = true;
                }

                
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Hides all other Main Window Canvas' and shows New Invoice
        /// </summary>
        public static void ShowNewInvoiceCanvas()
        {
            try
            {
                main.NewInvoiceCanvas.Visibility = Visibility.Visible;
                main.EditInvoiceCanvas.Visibility = Visibility.Hidden;
                main.DeleteInvoiceCanvas.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Hides all other Main Window Canvas' and shows Edit Invoice
        /// </summary>
        public static void ShowEditInvoiceCanvas()
        {
            try
            {
                main.EditInvoiceCanvas.Visibility = Visibility.Visible;
                main.NewInvoiceCanvas.Visibility = Visibility.Hidden;
                main.DeleteInvoiceCanvas.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Hides all other Main Window Canvas' and shows Delete Invoice
        /// </summary>
        public static void ShowDeleteInvoiceCanvas()
        {
            try
            {
                main.DeleteInvoiceCanvas.Visibility = Visibility.Visible;
                main.NewInvoiceCanvas.Visibility = Visibility.Hidden;
                main.EditInvoiceCanvas.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Hides all other main window sub windows
        /// </summary>
        public static void ShowLandingPage()
        {
            try
            {
                main.DeleteInvoiceCanvas.Visibility = Visibility.Hidden;
                main.NewInvoiceCanvas.Visibility = Visibility.Hidden;
                main.EditInvoiceCanvas.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
                if (selection != null)
                {
                    var price = ((Group6FinalProject.ClsItem)selection).ItemPrice;
                    WndMain.main.NewInvoice_PriceBox.Text = "$" + Decimal.Round(price, 2);
                }
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                if (!string.IsNullOrEmpty(NewInvoice_ItemComboBox.Text))  //if the combo box contains a selection
                {
                    var selection = NewInvoice_ItemComboBox.SelectedItem;

                    ClsMainLogic.AddNewItem(selection);
                    NewInvoice_DataGrid.ItemsSource = ClsMainLogic.InvoiceItemsList;
                    NewInvoice_TotalPriceBox.Text = "$" + ClsMainLogic.CalculateInvoiceTotal();
                }

            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                if (!string.IsNullOrEmpty(Edit_AddItemComboBox.Text))  //if the combo box contains a selection
                {
                    var selection = Edit_AddItemComboBox.SelectedItem;

                    ClsMainLogic.AddNewItem(selection);
                    Edit_TotalPriceBox.Text = "$" + ClsMainLogic.CalculateInvoiceTotal();
                }
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                while (Edit_DataGrid.SelectedItems.Count > 0)          //this loop allows for multiple items to be deleted at once
                {
                    ClsMainLogic.InvoiceItemsList.RemoveAt(Edit_DataGrid.SelectedIndex);
                }

                Edit_TotalPriceBox.Text = "$" + ClsMainLogic.CalculateInvoiceTotal();
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Cancels the invoice and resets the data collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoice_CancelButton_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                NewInvoiceCancelFunction();
            }
            catch(Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// pulled out be a method so it can also be used to clear the screen when the user saves an invoice
        /// </summary>
        private void NewInvoiceCancelFunction()
        {
            try
            {
                ShowLandingPage();                          //return to the main screen
                ClsMainLogic.InvoiceItemsList.Clear();   //clear the list that populates the data grid
                NewInvoice_PriceBox.Text = "";              //reset price display box
                NewInvoice_TotalPriceBox.Text = "";         //reset order total display box
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// pulled out be a method so it can also be used to clear the screen when the user saves an invoice
        /// </summary>
        private void EditInvoiceCancelFunction()
        {
            try
            {
                ShowLandingPage();                          //return to the main screen
                ClsMainLogic.InvoiceItemsList.Clear();   //clear the list that populates the data grid
                Edit_TotalPriceBox.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// this method handles the clicks for the save button on the new invoice window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoice_SaveInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var date = newInvoiceDatePicker.Text;

                if(date == null)    //if date is not selected, then choose the current date
                {
                    date = DateTime.Now.ToShortDateString();
                }

                var invoiceNumber = ClsMainLogic.SaveNewInvoice(date);
                
                mainUserDisplayLabel.Content = "Invoice # " + invoiceNumber + " has been created!";
                NewInvoiceCancelFunction();         //clear the screen after save as well
            }
            catch(Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Gets the invoice number from the combo box and deletes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoice_DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {       
                var selection = Delete_SelectInvoiceComboBox.SelectedItem;                  //get the selected invoice number
                var invoiceNum = ((Group6FinalProject.ClsInvoice)selection).InvoiceNum;

                ClsMainLogic.DeleteInvoice(invoiceNum);                                     //send it to the business logic to complete

                mainUserDisplayLabel.Content = "Invoice # " + invoiceNum + " has been deleted!";

                ShowLandingPage();
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Deletes items in the new invoice datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoice_DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while(NewInvoice_DataGrid.SelectedItems.Count > 0)                          //this loop allows for multiple items to be deleted at once
                {
                    ClsMainLogic.InvoiceItemsList.RemoveAt(NewInvoice_DataGrid.SelectedIndex);
                }

                if (NewInvoice_TotalPriceBox.Text != "")
                {
                    NewInvoice_PriceBox.Text = "";
                }

                NewInvoice_TotalPriceBox.Text = "$" + ClsMainLogic.CalculateInvoiceTotal();   //recalculate the new total
            }
            catch(Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// handles the event of the save button being clicked in the edit menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //need to make SQL to UPDATE a previous invoice id
                var selection = Edit_SelectInvoiceComboBox.SelectedItem;
                var invoiceNum = ((Group6FinalProject.ClsInvoice)selection).InvoiceNum;
                var newTotal = ClsMainLogic.CalculateInvoiceTotal();

                ClsMainLogic.UpdateInvoiceInformation(invoiceNum, newTotal);

                EditInvoiceCancelFunction();        //clear the previous info and return to landing page

                mainUserDisplayLabel.Content = "Invoice # " + invoiceNum + " has been updated!";
            }
            catch(Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void Edit_CancelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditInvoiceCancelFunction();
            }
            catch(Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}