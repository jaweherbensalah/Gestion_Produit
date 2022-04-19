using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Data;


namespace Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private GestionProduitContext dataContext;
        public GestionProduitContext DataContext { get { return dataContext; } }

        // Get the current DataContext
        public GestionProduitContext Get()
        {
            if (DataContext != null) return DataContext;
            return dataContext = new GestionProduitContext();
        }

        // Constructor: create new instance of GestionProduitsContext
        public DatabaseFactory()
        {
            dataContext = new GestionProduitContext();
        }

        //Implement DisposeCore to free ressource allocated to DataContext
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }


}
