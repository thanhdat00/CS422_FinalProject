using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("/api/orders")]
    [Produces("application/json")]
    [ApiController]
    public class OrdersController : Controller
    {
        //[HttpPost]
        //[ProducesResponseType(typeof(ErrorResource),400)]

        //public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
        //{
        //    return null;
        //}
    }
}
