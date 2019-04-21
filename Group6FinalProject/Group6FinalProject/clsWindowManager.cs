using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Group6FinalProject
{
    /// <summary>
    /// Makes main window visible and search window hidden
    /// </summary>
    static class clsWindowManager
    {
        #region Properties
        /// <summary>
        /// References the main window to be displayed
        /// </summary>
        public static Window MainWindow { get; set; }

        /// <summary>
        /// References the search window to be hidden
        /// </summary>
        public static Window SearchWindow { get; set; }

        /// <summary>
        /// References the search window to be hidden
        /// </summary>
        public static Window ItemWindow { get; set; }

        /// <summary>
        /// reference to the invoice selected by the user
        /// </summary>
        private static ClsInvoice selectedInvoice;
        #endregion

        #region Methods
        /// <summary>
        /// Used to give main window access to the selected invoice
        /// </summary>
        public static ClsInvoice SelectedInvoice
        {
            get
            {
                return selectedInvoice;
            }
            set
            {
                selectedInvoice = value;
            }
        }

        /// <summary>
        /// Used to hide SearchWindow and display MainWindow
        /// </summary>
        public static void showMainWindow()
        {
            try
            {
                // only allowed to run if application isn't already closing down 
                // (prevent exception of accessing previously closed windows)
                if (MainWindow.IsVisible || SearchWindow.IsVisible || ItemWindow.IsVisible)
                {
                    SearchWindow.Visibility = Visibility.Hidden;
                    ItemWindow.Visibility = Visibility.Hidden;
                    MainWindow.Visibility = Visibility.Visible;

                    if(Search.WndSearch.searchMenuCalled == true)
                    {
                        Main.WndMain.SimulateEditButton();
                    }
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