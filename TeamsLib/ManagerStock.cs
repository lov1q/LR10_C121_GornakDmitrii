using LR10_C121_GornakDmitrii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsLib
{
    public class ManagerStock
    {
        public static Stock stock {  get; set; }

        static ManagerStock ()
        {
            stock = new Stock ();
        }
    }
}
