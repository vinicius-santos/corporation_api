using CorporationApi.Models;
using CorporationApi.Models.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace CorporationApi.Controllers
{
    public class ProviderController : ApiController
    {
        static readonly IProviderRepository repository = new ProviderRepository();

        [HttpGet]
        [Route("api/providers")]
        public IEnumerable<Provider> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("api/provider/{id}")]
        public Provider Get(int id)
        {
            try
            {
                Provider item = repository.Get(id);
                if (item == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                return item;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [Route("api/provider/save")]
        public HttpResponseMessage Post([FromBody] Provider provider)
        {
            bool isSave = false;
            try
            {
               
                if (ModelState.IsValid)
                {
                    isSave = repository.Add(provider);
                    if (isSave)
                    {
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                    else
                    {
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    }
                }
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }


        [HttpPut]
        [Route("api/provider/put/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] Provider provider)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    provider.ID = id;
                    if (repository.Update(provider) == false)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                }
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Route("api/provider/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Provider item = repository.Get(id);
                if (item == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                repository.Remove(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }

    }
}
