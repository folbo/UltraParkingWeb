using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Swagger.Annotations;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.Queries.API;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers.Api
{
    [RoutePrefix("api/project")]
    public class ParkingController : BaseApiController
    {
        /// <summary>
        /// zwraca informacje parkingu o podanym ID
        /// </summary>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ParkingDTO))]
        public HttpResponseMessage ById(Guid id)
        {
            var parking = Please.Give(new GetParkingById(id));
            if (parking == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK,parking);


        }

        /// <summary>
        ///  zwraca wszystke parkingi
        /// </summary>
        /// <returns></returns>
        [Route("all")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<ParkingDTO>))]
        public IEnumerable<ParkingDTO> All()
        {
            return Please.Give(new AllParkings());
        }
        
        /// <summary>
        ///  zwraca wszystke parkingi w podanym obszarze
        /// </summary>
        /// <returns></returns>
        [Route("inArea")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<ParkingDTO>))]
        public IEnumerable<ParkingDTO> InArea(GetParkingsInArea model)
        {
            return Please.Give(model);
        }

        /*
        /// <summary>
        ///     Metoda tworzy nowy projekt
        /// </summary>
        /// <param name="createProject"></param>
        /// <returns></returns>
        [Route("add")]
        [ResponseType(typeof(ProjectDTO))]
        public HttpResponseMessage Create(CreateProject createProject)
        {
            var newId = createProject.NewId = Guid.NewGuid();
            Please.Do(createProject);

            var projectDTO = Please.Give(new ProjectWithAllComments(newId));
            return Request.CreateResponse(HttpStatusCode.Created, projectDTO);
        }

        /// <summary>
        ///     Metoda edytuje projekt z podanym Id
        /// </summary>
        /// <param name="editProject"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("edit")]
        [ResponseType(typeof(void))]
        public HttpResponseMessage Edit(EditProject editProject)
        {
            Please.Do(editProject);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        ///     metoda usuwa projekt o podanym Id
        /// </summary>
        /// <param name="deleteProject"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [ResponseType(typeof(void))]
        public HttpResponseMessage Delete(DeleteProject deleteProject)
        {
            Please.Do(deleteProject);

            return Request.CreateResponse(HttpStatusCode.OK);
        }*/
    }
}
