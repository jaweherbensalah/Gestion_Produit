using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Chemical:Product  //chemical herite de product
    {
      //  public string City { get; set; }
        public string LabName { get; set; }
        public Address Address { get; set; }
        //     public string StreetAddress { get; set; }

        public override void GetMyType()
        {
            Console.WriteLine("chemical");
        }

    }
}
