using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkCarpet
{
    public class Carpet
    {
        public int Amount { get; private set; }
        public int Area { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public int Price { get; private set; }
        public Carpet(int Amount, int Area, DateTime OrderDate, DateTime DeliveryDate, int Price)
        {
            this.Amount = Amount;
            this.Area = Area;
            this.OrderDate = OrderDate;
            this.DeliveryDate = DeliveryDate;
            this.Price = Price;
        }
    }
}
