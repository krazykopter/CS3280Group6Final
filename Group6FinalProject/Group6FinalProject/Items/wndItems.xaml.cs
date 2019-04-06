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
        #region Compiler
        public WndItems(Window mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            db = new clsDataAccess();
            //err = new ClsHandleError();
        }
        #endregion
        #region Attributes
        private Window mainWindow;
        public static clsDataAccess db;
        //public static ClsHandleError err;
        #endregion

        #region Methods

        private void NewItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: 
            }
            catch (Exception ex)
            {

                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: 
            }
            catch (Exception ex)
            {

                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void deleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: 
            }
            catch (Exception ex)
            {

                ClsHandleError.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
