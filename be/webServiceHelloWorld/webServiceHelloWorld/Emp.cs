using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webServiceHelloWorld
{
    public class Emps
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }


        public int Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Country { get; set; }
    }
}