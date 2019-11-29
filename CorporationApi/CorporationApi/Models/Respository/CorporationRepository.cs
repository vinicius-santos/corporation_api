using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorporationApi.Models.Respository
{
    public class CorporationRepository : ICorporationRepository
    {
        private List<Corporation> corporations = new List<Corporation>();
        private int _nextId = 1;
        public bool Add(Corporation item)
        {
            if (item == null)
            {
                return false;
            }
            item.ID = _nextId++;
            corporations.Add(item);
            return true;
        }

        public Corporation Get(int id)
        {
            return corporations.Find(p => p.ID == id);
        }

        public IEnumerable<Corporation> GetAll()
        {
            return corporations;
        }

        public bool Remove(int id)
        {
            try
            {
            corporations.RemoveAll(p => p.ID == id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Corporation item)
        {
            if (item == null)
            {
                return false;
            }
            int index = corporations.FindIndex(p => p.ID == item.ID);
            if (index == -1)
            {
                return false;
            }
            corporations.RemoveAt(index);
            corporations.Add(item);
            return true;
        }
    }
}