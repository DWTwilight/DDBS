using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceNode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceNode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlServiceController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTableAsync(CreateTableQuery query)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
