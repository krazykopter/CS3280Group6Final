using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Group6FinalProject
{
    public class ClsHandleError
    {
        /// <summary>
        /// This method handles all exceptions that have risen from lower level methods
        /// </summary>
        /// <param name="sClass"> The class where the error occurred </param>
        /// <param name="sMethod"> The method where the error occurred </param>
        /// <param name="sMessage"> The error message from the exception </param>
        public void HandleError(string sClass, string sMethod, string sMessage)
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
