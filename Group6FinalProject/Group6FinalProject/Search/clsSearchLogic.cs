using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6FinalProject.Search
{
    static class clsSearchLogic
    {

        /*
         * TODO: THE FOLLOWING TWO LINES OF CODE NEED
         * 
         * clsMainLogic needs a "searchInvoiceNum" attribute that can be set from clsSearchLogic
         * and is preset to a nonsense value like null in case a valid invoice was not selected.
         * 
         * clsMainLogic must call one of clsMainLogic.cs's methods to pass in and display the searched for
         * invoice as the search window is closed/hidden.
         * 
         * if clsMainLogic were a static class, I could reference these directly, otherwise, I need
         * a reference passed into wndSearch.xaml.cs then I need to pass that reference along to this
         * class.
         */

        /*
         * This class will retrieve a sql statement as a string from clsSearchSQL.cs
         * then use an instance of the DBO to retrieve the needed data 
         */

        #region Attributes
        private static WndSearch WndSearch1;

        
        #endregion


        #region Methods
        public static void getAllInvoices()
        {
            string sql = clsSearchSQL.SelectAllInvoices();



            //displayInvoices(lInvoices);

        }
        #endregion

        private static void displayInvoices(List<ClsInvoice> lInvoices)
        {
            
        }


    }
}
