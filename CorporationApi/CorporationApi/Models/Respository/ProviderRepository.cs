using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorporationApi.Models.Respository
{
    public class ProviderRepository : IProviderRepository
    {
        private List<Provider> providers = new List<Provider>();
        private int _nextId = 1;
        public bool Add(Provider item)
        {
            if (item == null)
            {
                return false;
            }
            item.ID = _nextId++;
            providers.Add(item);
            return true;
        }

        public Provider Get(int id)
        {
            return providers.Find(p => p.ID == id);
        }

        public IEnumerable<Provider> GetAll()
        {
            return providers;
        }

        public bool Remove(int id)
        {
            try
            {
            providers.RemoveAll(p => p.ID == id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Provider item)
        {
            if (item == null)
            {
                return false;
            }
            int index = providers.FindIndex(p => p.ID == item.ID);
            if (index == -1)
            {
                return false;
            }
            providers.RemoveAt(index);
            providers.Add(item);
            return true;
        }
    }
}