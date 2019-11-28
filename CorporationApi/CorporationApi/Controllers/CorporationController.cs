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
    public class CorporationController : ApiController
    {

        static readonly ICorporationRepository repository = new CorporationRepository();

        [HttpGet]
        [Route("api/corporations")]
        [ResponseType(typeof(List<Corporation>))]
        public IEnumerable<Corporation> GetAllCorporations()
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
        [Route("api/corporation/{id}")]
        [ResponseType(typeof(Corporation))]
        public Corporation GetCorporation(int id)
        {
            try
            {
                Corporation item = repository.Get(id);
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
        [Route("api/corporation/post")]
        [ResponseType(typeof(HttpResponse))]
        public HttpResponseMessage PostCorporation([FromBody] Corporation item)
        {
            bool isSave = false;
            try
            {
                if (ModelState.IsValid)
                {
                    isSave = repository.Add(item);
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
        [Route("api/corporation/put/{id}")]
        [ResponseType(typeof(HttpResponse))]
        public HttpResponseMessage PutCorporation(int id, [FromBody] Corporation corporation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    corporation.ID = id;
                    if (repository.Update(corporation) == false)
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
        [Route("api/corporation/delete/{id}")]
        [ResponseType(typeof(HttpResponse))]
        public HttpResponseMessage DeleteCorporation(int id)
        {
            try
            {
                Corporation item = repository.Get(id);
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

