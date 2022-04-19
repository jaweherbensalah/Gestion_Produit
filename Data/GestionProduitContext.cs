using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;
using Data.Configurations;
using Data.CustomConvention;

namespace Data
{
    public class GestionProduitContext:DbContext
    {

        public GestionProduitContext() : base("name=GestionProduitCtx")
        { Database.SetInitializer<GestionProduitContext>(new DropCreateDatabaseIfModelChanges<GestionProduitContext>());
       //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
      //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }


        //ajout des DbSets pour Client & Facture:
        public DbSet<Client> Clients { get; set; }
        public DbSet<Facture> Factures { get; set; }



        //on va implémenter la fonction de config: OnModelCreating:!!!
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {  //Appel des classe de configuration
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
           
           


            modelBuilder.Conventions.Add<DateTime2Convention>();
            //puis on crée une classe de migration:


        }
    }
}

