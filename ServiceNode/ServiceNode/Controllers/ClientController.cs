using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceNode.DatabaseContext;
using ServiceNode.Models;
using ServiceNode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceNode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientDbContext clientDbContext;
        private readonly TokenService tokenService;
        private readonly ILogger<ClientController> logger;

        public ClientController(ClientDbContext clientDbContext, TokenService tokenService, ILogger<ClientController> logger)
        {
            this.clientDbContext = clientDbContext;
            this.tokenService = tokenService;
            this.logger = logger;
        }

        [HttpPost]
        [Route("Regist")]
        public async Task<IActionResult> RegistAsync(Client clientInfo)
        {
            try
            {
                await clientDbContext.Clients.AddAsync(clientInfo);
                await clientDbContext.SaveChangesAsync();
                return Ok(new { Res = true });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(new { Res = false, Error = "User Name has existed!" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Client clientInfo)
        {
            try
            {
                var client = await clientDbContext.Clients.FindAsync(clientInfo.Id);
                if(client == null)
                {
                    throw new Exception("User Not Found!");
                }
                if(client.Password != clientInfo.Password)
                {
                    throw new Exception("Incorrect Password!");
                }
                var token = await tokenService.AddTokenAsync(new Token(client.Id, 24));
                return Ok(new { Res = true, Token = token });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(new { Res = false, Error = e.Message });
            }
        }
    }
}
