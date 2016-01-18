using System;
using System.Linq;
using System.Web.Http;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Infrastructure.Data;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers.Api
{
    /// <summary>
    /// Controller to test web api features 
    /// </summary>
    [RoutePrefix("api/test")]
    public class TestController : BaseApiController
    {
        private readonly CoreDbContext _data;

        public TestController(CoreDbContext data)
        {
            _data = data;
        }

        /// <summary>
        /// Method answer only to authorized requests 
        /// </summary>
        /// <returns>string ok</returns>
        [Authorize]
        [Route("AuthTest")]
        [HttpGet]
        public string AuthTest()
        {
            return "ok";
        }

        /// <summary>
        /// sample method to get some data from serwer 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("sample")]
        [HttpGet]
        public SampleClassDTO Sample()
        {
            return new SampleClassDTO
            {
                SampleString = "sample string",
                SampleInt = 42,
                SampleArray = new[] { "sample string1", "sample string2" },
                SampleGuid = Guid.NewGuid()
            };
        }


        /// <summary>
        /// Metoda zwalnia wszystkie miejsca parkingowe
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("releasePlaces")]
        [HttpGet]
        public void ReleasePlaces()
        {
            var parkingsId = _data.Parkings.Select(parking => parking.Id).ToArray();
            foreach (var id in parkingsId)
            {
                var parking = Please.Give(new ParkingAggregate(id));
                foreach (var place in parking.Places)
                {
                    place.MarkAsFree();
                }
            }
            _data.SaveChanges();
        }
    }

    public class SampleClassDTO
    {
        public string SampleString { get; set; }
        public int SampleInt { get; set; }
        public string[] SampleArray { get; set; }
        public Guid SampleGuid { get; set; }
    }
}
