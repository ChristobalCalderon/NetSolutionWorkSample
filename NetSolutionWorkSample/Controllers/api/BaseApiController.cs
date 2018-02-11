using Microsoft.AspNetCore.Mvc;
using NetSolutionWorkSample.Entity;
using NetSolutionWorkSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetSolutionWorkSample.Controllers.api
{
    public class BaseApiController : Controller
    {
        protected async Task<IActionResult> CreateResponse<T>(Task<T> client)
        {
            try
            {
                return Ok(await client);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting data: {httpRequestException.Message}");
            }
        }

    }
}
