using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
namespace Data.Configurations
{
   public class AddressConfiguration:ComplexTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            this.Property(a => a.City).IsRequired();
            this.Property(a => a.StreetAddress).IsOptional().HasMaxLength(50);

        }
    }
}
