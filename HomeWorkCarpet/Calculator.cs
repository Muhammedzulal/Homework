using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkCarpet
{
    internal class Calculator
    {
        // *Ücret hesaplama
        // *Teslim tarihi(adete göre)

        //Ücret hesabı(m²*20)
        public static int CalculatePrice(int Area)
        {
            return Area * 20;
        }
        //Teslim tarihi(adet*2)
        public static DateTime CalculateDeliveryDate(DateTime orderDate, int adet)
        {
            DateTime deliveryDate = orderDate.AddDays(adet * 2);
            return deliveryDate;
        }

    }
}
