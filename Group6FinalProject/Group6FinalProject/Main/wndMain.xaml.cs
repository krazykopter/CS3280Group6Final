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

namespace Group6FinalProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class WndMain : Window
    {
        public WndMain()
        {
            InitializeComponent();
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
            catch(Exception ex)
            {
                throw ex;
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
                throw ex;
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
                throw ex;
            }
        }
    }
}
