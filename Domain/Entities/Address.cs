using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{ [ComplexType]
    public class Address
    { public string StreetAddress { get; set; }
        public string City { get; set; }
    }
}
