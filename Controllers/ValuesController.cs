using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace vk_callback_server.Controllers
{
    [Route("api/bot")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly VKConfiguration Config;
        public ValuesController(IOptions<VKConfiguration> options)
        {
            Config = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Message value)
        {
            if (Config.ConfirmationResponse != null)
            {
                if(value.Type == "confirmation" && value.GroupId == 179066803)
                {
                    return Ok(Config.ConfirmationResponse);
                }
            }
            try
            {
                Console.WriteLine($"{value.Type}:{value.GroupId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
            
            return Ok("ok");
        }
    }
}
