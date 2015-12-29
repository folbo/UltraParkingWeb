using System;
using System.Web.Http;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers.Api
{
    /// <summary>
    /// Controller to test web api features 
    /// </summary>
    [RoutePrefix("api/test")]
    public class TestController : BaseApiController
    {
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
    }

    public class SampleClassDTO
    {
        public string SampleString { get; set; }
        public int SampleInt { get; set; }
        public string[] SampleArray { get; set; }
        public Guid SampleGuid { get; set; }
    }
}
