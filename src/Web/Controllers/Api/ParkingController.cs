using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Swashbuckle.Swagger.Annotations;
using Ultra.Core.Domain.Commands.Admin.Parking;
using Ultra.Core.Domain.Commands.Client;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.Queries.API;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers.Api
{
    [RoutePrefix("api/parking")]
    public class ParkingController : BaseApiController
    {
        /// <summary>
        ///     Zwraca informacje parkingu o podanym ID
        /// </summary>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof (ParkingDTO))]
        public HttpResponseMessage ById(Guid id)
        {
            var parking = Please.Give(new GetParkingById(id));
            if (parking == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, parking);
        }

        /// <summary>
        ///     Zwraca wszystke parkingi
        /// </summary>
        /// <returns></returns>
        [Route("all")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof (IEnumerable<ParkingDTO>))]
        public IEnumerable<ParkingDTO> All()
        {
            return Please.Give(new AllParkings());
        }

        /// <summary>
        ///     Zwraca wszystke parkingi w podanym obszarze
        /// </summary>
        /// <returns></returns>
        [Route("inArea")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof (IEnumerable<ParkingDTO>))]
        public IEnumerable<ParkingDTO> InArea(GetParkingsInArea model)
        {
            return Please.Give(model);
        }

        /// <summary>
        ///     Rezerwuje miejsce parkingowe na danym parkingu
        /// </summary>
        /// <returns></returns>
        [Route("bookPlace")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof (ParkingPlaceDTO))]
        [SwaggerResponse(422, Type = typeof (void))]
        [Authorize]
        public HttpResponseMessage Book(BookPlace command)
        {
            command.UserId = Guid.Parse(User.Identity.GetUserId());
            Please.Do(command);
            var place = command.ReturnValue;
            return place == null
                ? Request.CreateResponse((HttpStatusCode) 422)
                : Request.CreateResponse(HttpStatusCode.OK, place);
        }

        /// <summary>
        /// Oznacza miejsce odpowiednim statusem. Wymaga aspecjalnych uprawnień
        /// </summary>
        /// <param name="command"></param>
        [Route("markAs")]
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public void MarkAs(MarkPlaceAs command)
        {
            Please.Do(command);
        }
    }
}