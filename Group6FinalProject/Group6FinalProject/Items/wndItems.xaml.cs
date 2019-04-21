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
        public WndItems()
        {
            try
            {
                InitializeComponent();
                updateWndItems(); // populates ItemsGridBox
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }            
        }
        #endregion
        #region Methods
        /// <summary>
        /// This method updates the textboxes with the current selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ItemsDataGrid.SelectedItem != null)
                {
                    var selection = ItemsDataGrid.SelectedItem;
                    var itemCode = ((ClsItem)selection).ItemCode;
                    var itemDesc = ((ClsItem)selection).ItemDescription;
                    var itemCost = ((ClsItem)selection).ItemPrice;

                    itemCodeTextBox.Text = itemCode;
                    itemDescTextBox.Text = itemDesc;
                    itemCostTextBox.Text = itemCost.ToString();

                    itemCodeTextBox.IsReadOnly = true;
                }
            }
            catch (Exception ex)
            {

                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method clears the textboxes
        /// </summary>
        private void clearItemSelection()
        {
            try
            {
                itemCodeTextBox.Text = "";
                itemDescTextBox.Text = "";
                itemCostTextBox.Text = "";

                itemCodeTextBox.IsReadOnly = false;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method clears the textboxes so a new item can be entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearSelection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clearItemSelection();
            }
            catch (Exception ex)
            {

                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method allows the user to create a new item and store it in the database after click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (itemCodeTextBox.Text != "" && itemDescTextBox.Text != "" && itemCostTextBox.Text != "")
                {
                    string itemCode = itemCodeTextBox.Text.ToString();
                    string itemDesc = itemDescTextBox.Text.ToString();
                    Int32.TryParse(itemCostTextBox.Text.ToString(), out int itemCost);

                    ClsItemsLogic.NewItem(itemCode, itemDesc, itemCost);

                    updateWndItems();
                }
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
                if (itemCodeTextBox.Text != "" && itemDescTextBox.Text != "" && itemCostTextBox.Text != "")
                {
                    string itemCode = itemCodeTextBox.Text.ToString();
                    string itemDesc = itemDescTextBox.Text.ToString();
                    int itemCost;
                    Int32.TryParse(itemCostTextBox.Text.ToString(), out itemCost);

                    ClsItemsLogic.EditItem(itemCode, itemDesc, itemCost);

                    updateWndItems();
                }
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
                string itemCode = itemCodeTextBox.Text.ToString();
                if (itemCodeTextBox.Text != "")
                {
                    if (!ClsItemsLogic.IsOnInvoice(itemCode))
                    {
                        ClsItemsLogic.DeleteItem(itemCode);
                        

                        updateWndItems();
                    }
                    else
                    {
                        string warningMessage = ClsItemsLogic.WhichInvoice(itemCode);
                        MessageBox.Show(warningMessage, "Could Not Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
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
                var itemList = ClsItemsLogic.populateItemGridBox();
                clearItemSelection();
                ItemsDataGrid.Items.Clear();

                foreach (ClsItem i in itemList)
                {
                    ItemsDataGrid.Items.Add(i);
                }
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
        private void wndItems_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (this.IsVisible)
                {
                    // reset the text of the textboxes
                    itemCodeTextBox.Text = "";
                    itemDescTextBox.Text = "";
                    itemCostTextBox.Text = "";

                    e.Cancel = true;                    
                    clsWindowManager.showMainWindow();
                }
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method does not allow non integer values in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemCostTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!Int32.TryParse(itemCostTextBox.Text, out int itemCost))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method does not allow integer values in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemDescTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                int wrongDesc;
                if (Int32.TryParse(itemDescTextBox.Text, out wrongDesc))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method only allows letters in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemCodeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        
    }// end partial class
}// end namespace