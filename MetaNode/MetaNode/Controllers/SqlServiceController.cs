using MetaNode.Models;
using MetaNode.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaNode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlServiceController : ControllerBase
    {
        private readonly ILogger<SqlServiceController> logger;
        private readonly TableService tableService;

        public SqlServiceController(ILogger<SqlServiceController> logger, TableService tableService)
        {
            this.logger = logger;
            this.tableService = tableService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTableAsync(CreateTableQuery query)
        {
            try
            {
                await tableService.CreateTableAsync(query.TableName);
                return Ok(new { Res = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { Res = false, Error = e.Message });
            }
        }
    }
}
