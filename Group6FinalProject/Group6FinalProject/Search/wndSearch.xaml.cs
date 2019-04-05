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

namespace Group6FinalProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// 
    /// This class created by Brad Christensen
    /// 
    /// </summary>
    public partial class WndSearch : Window
    {
        /*
         * Credit for wndSearch.xaml layout:
         * Carson Crezee
         * I used the layout from wndMain.xaml created by Carson
         * because it gives the windows a consistent look.
         */

        /*
         * TODO: THE FOLLOWING TWO LINES OF CODE NEED
         * TO BE ADDED TO THE CONSTRUCTOR IN: "wndMain.xaml.cs"
         * // Make sure to close all additional windows in the application
         * Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
         * 
         * Because of the way this class is created in wndMain.xaml.cs, a new window
         * object will be created each time the "search for invoice" button is pressed.
         * Either the "new" key word needs to be used in wndMain.xaml.cs's constructor
         * and retained in an attribute or the instance of this class must be destroyed
         * each time so they don't build up in the background.
         * Based on his use of "hide()" it looks like we should use the first option.
         */

        #region Attributes
        private Window mainWindow;
        public static clsDataAccess db;
        #endregion

        #region Constructor
        // FIXME: THE CALL IN CLASS "wndMain.xaml.cs" IN METHOD "SearchMenuItem_Click()"
        // ON LINE Window searchWindow = new Search.WndSearch(); NEEDS TO PASS IN "this"
        // SO THAT I CAN SHOW THE MAIN WINDOW AGAIN ("onClose()")
        public WndSearch(Window mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            db = new clsDataAccess();
        }

        #endregion

        private void cboInvoiceNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: call method in clsSearchLogic to update displayed invoices
        }

        private void cboInvoiceDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: call method in clsSearchLogic to update displayed invoices
        }


        private void cboTotalCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: call method in clsSearchLogic to update displayed invoices
        }


        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
            // TODO: call method in clsSearchLogic that will clear the search
        }


        private void btnSelectInvoice_Click(object sender, RoutedEventArgs e)
        {
            // TODO: call a method in clsSearchLogic.cs that calls a method in clsMainLogic.cs
            // to set the invoice Number and display it on the main window.

            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void wdwSearch_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // only allowed to run if application isn't already closing down 
            // (prevent exception of accessing previously closed windows)
            if (mainWindow.IsVisible || this.IsVisible)
            {
                // we only have one instance of this window, make sure the user doesn't destroy it.
                e.Cancel = true;

                mainWindow.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
