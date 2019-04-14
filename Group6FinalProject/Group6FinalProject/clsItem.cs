using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6FinalProject
{
    class ClsItem
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int ItemPrice { get; set; }

        /// <summary>
        /// The to String override will dispaly the item description in the combo Box
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ItemDescription;
        }
    }
}
