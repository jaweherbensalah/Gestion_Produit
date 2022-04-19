using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
namespace Data.Configurations
{
   public class ProductConfiguration:EntityTypeConfiguration<Product>
    {public ProductConfiguration()
        {
            this.HasMany(p => p.Providers)
             .WithMany(pr => pr.Products)
             .Map(
                 i =>
                 {
                     i.ToTable("Providings");
                     i.MapLeftKey("ProductKey");
                     i.MapRightKey("ProviderKey");

                 });
            this.HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);

            //Renommer le champs discriminator
            this.Map<Biological>(c =>
            {
                c.Requires("IsBiological").HasValue(1); //isBiological is the discriminator
            });
            this.Map<Chemical>(c =>
            {
                c.Requires("IsChemical").HasValue(0); //isBiological is the discriminator
            });
            this.Property(c => c.Description).HasMaxLength(50).IsOptional();
        }
    }
}
