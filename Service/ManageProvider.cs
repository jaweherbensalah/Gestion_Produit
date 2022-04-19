using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service
{
    public class ManageProvider
    {
     private List<Provider> Providers;
    public ManageProvider(List<Provider>providers)
    { this.Providers = providers; }
      
    public IEnumerable<Provider> GetProviderByName(string name)
        {
            return from provider in Providers
                   where provider.UserName != null && provider.UserName.Contains(name)
                   select provider;
        }
        public Provider GetFirstProviderByName(string name)
        {
            return GetProviderByName(name).FirstOrDefault();
        }

        public Provider GetProviderById(int id)
        {
            return (from provider in Providers
                    where provider.Id == id
                    select provider).Single();
        }


    }
}
