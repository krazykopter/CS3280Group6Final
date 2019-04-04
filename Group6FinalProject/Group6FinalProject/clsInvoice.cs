using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6FinalProject
{
    class ClsInvoice
    {
        public string invoiceNum;
        public DateTime invoiceDate;
        public decimal totalCost;
        //public List<string> items;  //not sure about this one currently?

        /// <summary>
        /// The to String override will dispaly the item description in the combo Box
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Invoice #" + invoiceNum + " - " + invoiceDate;
        }

    }
}
