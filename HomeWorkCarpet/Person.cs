using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkCarpet
{
    public class Person
    {
        public int Id { get;private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public Carpet carpet { get; set; }

        public Person(int Id,string Name, string Phone, string Address, int Adet, int Area, int Price,Carpet carpet)
        {
            this.Id = Id;
            this.Name = Name;
            this.Phone = Phone;
            this.Address = Address;
            this.carpet =carpet;

        }
    }
}
