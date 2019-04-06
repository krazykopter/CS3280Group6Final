using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*
    Michael W. Craig, W01092948
*/

namespace Group6FinalProject.Items
{
    // The purpose of this form is to update the def table, which contains all the items for the business
    class ClsItemsLogic
    {
        /*
        GUI:
            - created with all controls needed to complete the requirements
        Interface:
            - put appropriate comments in the sections of stubbed out code to explain
              how the data will be passed around
        
        need a method that checks to ensure an invoice is not being edited

        need a method that checks to ensure a new invoice is not being created (or functionality added to other check method)

        need a datagrid (or something like it) to list all the items in a list format

        need to be able to add new items

        need to be able to edit existing items (cost and description)
            but not the item code. The item code is the primary key

        need to be able to delete existing items (But not if that item is on an invoice)
            need to warn the user with a message that tells the user which invoices that item is used on
        
        When the user closes the update def table form, make sure to update the drop-down box as to reflect any changes made by the user

        update the current invoice, because it's item name (description) might have been updated

        */
        #region Compiler

        #endregion
        #region Attributes

        #endregion
        #region Methods
        // I think these two checks are performed by clsMainLogic and that wndMain is supposed to have a menu option to open the wndItems form
        // refer to Group Assignment, the second to last paragraph starting with "The last form needed is..."
        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// This method checks to see if an invoice is being edited
        /// </summary>
        /// <returns>if a invoice is being edited, returns true</returns>
        bool IsInvoiceEdit()
        {
            try
            {
                // TODO: Needs to check if WndMain.main.EditInvoiceCanvas.Visibility = Visibility.Visible
                // if set to hidden, return false. Otherwise, return true
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method checks to see if a new invoice is being created
        /// </summary>
        /// <returns>if a new invoice is being created, returns true</returns>
        bool IsNewInvoice()
        {
            try
            {
                // TODO: Needs to check if WndMain.main.NewInvoiceCanvas.Visibility = Visibility.Visible;
                // if set to hidden, return false. Otherwise, return true
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This method checks to see if an item is on any invoices
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns>if the item is on any invoices, return true. Otherwise return false</returns>
        bool IsOnInvoice(string itemCode)
        {
            try
            {
                // TODO: Needs to pass the itemCode in to check whether or not it is on an invoice
                // Check through every invoice, the first time it appears in an invoice, return true. Otherwise, return false
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method creates a new item
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        void NewItem(string itemCode, string itemDesc, int cost)
        {
            try
            {
                // TODO: takes the itemCode, itemDesc, and cost from the form and passes them into the clsItemsSQL
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method edits an item
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        void EditItem(string itemCode, string itemDesc, int cost)
        {
            try
            {
                // TODO: takes itemCode, itemDesc, and cost from the form and edits stores the new itemDesc and new cost
                // TODO: call the clsItemsSQL code to update this item
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method deletes an item
        /// </summary>
        /// <param name="itemCode"></param>
        void DeleteItem(string itemCode)
        {
            try
            {
                IsOnInvoice(itemCode); // TODO: implement in if statement to encapsulate the code
                // TODO: call the clsItemsSQL code to delete this item
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}