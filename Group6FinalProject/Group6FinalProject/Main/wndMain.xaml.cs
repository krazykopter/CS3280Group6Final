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

namespace Group6FinalProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class WndMain : Window
    {
        public static WndMain main;

        public WndMain()
        {
            InitializeComponent();
            main = this;
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
                NewInvoiceCanvas.Visibility = Visibility.Visible;
                EditInvoiceCanvas.Visibility = Visibility.Hidden;
                DeleteInvoiceCanvas.Visibility = Visibility.Hidden;
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
                EditInvoiceCanvas.Visibility = Visibility.Visible;
                NewInvoiceCanvas.Visibility = Visibility.Hidden;
                DeleteInvoiceCanvas.Visibility = Visibility.Hidden;
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
                DeleteInvoiceCanvas.Visibility = Visibility.Visible;
                NewInvoiceCanvas.Visibility = Visibility.Hidden;
                EditInvoiceCanvas.Visibility = Visibility.Hidden;
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
                Window searchWindow = new Search.WndSearch();
                searchWindow.Visibility = Visibility.Visible;
                main.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
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
