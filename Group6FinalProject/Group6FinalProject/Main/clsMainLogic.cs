using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Group6FinalProject.Main
{
    class ClsMainLogic
    {
        /// <summary>
        /// new database instance
        /// </summary>
        public static clsDataAccess db;

        public ClsMainLogic()
        {
            db = new clsDataAccess(); //setup database clsDataAcess w/ class
        }

        public static void PopulateItemComboBox()
        {
            try
            {
                // string sSQL = ClsMainSQL.
                string sSQL = ClsMainSQL.SelectAllItemNames();
                int iRet = 0;
                DataSet ds = new DataSet();

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);                

                for (int i = 0; i < iRet; i++)
                {
                    WndMain.main.NewInvoiceItemComboBox.Items.Add(ds.Tables[0].Rows[i][0]);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
