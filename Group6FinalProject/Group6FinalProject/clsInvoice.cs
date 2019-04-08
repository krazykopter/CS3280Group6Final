using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6FinalProject
{
    public class ClsInvoice
    {
        public string InvoiceNum { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalCost { get; set; }
        //public List<string> items;  //not sure about this one currently?

        /// <summary>
        /// The to String override will dispaly the item description in the combo Box
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Invoice #" + InvoiceNum + " - " + InvoiceDate;
        }

    }
}
