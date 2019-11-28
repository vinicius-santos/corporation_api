using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporationApi.Models.Respository
{
    interface IProviderRepository
    {
        IEnumerable<Provider> GetAll();
        Provider Get(int id);
        bool Add(Provider item);
        bool Remove(int id);
        bool Update(Provider item);
    }
}
