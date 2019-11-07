using System;
using Microsoft.AspNetCore.Mvc;

namespace TemperatureMonitoring.Api.Controllers
{

    [Route("api/version")]
    [ApiController]
    public class VersionController : ControllerBase
    {

        /// <summary>
        /// Shows miscellaneous information about the api.
        /// </summary>
        /// <example>
        /// GET: api/version
        /// </example>
        /// <returns>
        /// Misc information about the api.
        /// </returns>
        [HttpGet]
        public OkObjectResult Get()
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            var buildDate = new DateTime(2000, 1, 1)
                            .AddDays(version.Build).AddSeconds(version.Revision * 2);
            var displayableVersion = $"v{version} ({buildDate})";

            return Ok($"Color chan api: {displayableVersion}");
        }
    }
}