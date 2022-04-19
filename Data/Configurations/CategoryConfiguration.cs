using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
namespace Data.Configurations
{
   public class CategoryConfiguration:EntityTypeConfiguration<Category>
    { public CategoryConfiguration()
        {
            this.ToTable("MyCategories");
            this.HasKey(c => c.CategoryId);//on a configuré le champs categId comme clé primaire
            this.Property(c => c.Name).HasMaxLength(50).IsRequired();
        }
    }
}
