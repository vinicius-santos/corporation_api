using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporationApi.Models.Respository
{
    interface ICorporationRepository
    {
        IEnumerable<Corporation> GetAll();
        Corporation Get(int id);
        bool Add(Corporation item);
        bool Remove(int id);
        bool Update(Corporation item);
    }
}
