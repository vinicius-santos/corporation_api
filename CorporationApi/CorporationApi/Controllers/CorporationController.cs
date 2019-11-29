using CorporationApi.Models;
using CorporationApi.Models.Respository;
using Microsoft.AspNetCore.Cors;
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

        [Route("api/corporations")]
        public IEnumerable<Corporation> GetAll()
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

        [Route("api/corporation/{id}")]
        public Corporation Get(int id)
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
        [Route("api/corporation/save")]
        public IHttpActionResult Save([FromBody] Corporation corporation)
        {
            bool isSave = false;
            try
            {
                if (ModelState.IsValid)
                {
                    isSave = repository.Add(corporation);
                    if (isSave)
                    {
                        return Ok();
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
        public HttpResponseMessage Put(int id, [FromBody] Corporation corporation)
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
        public HttpResponseMessage Delete(int id)
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

