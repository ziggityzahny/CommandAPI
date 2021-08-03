using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.AddControllers
{
    //Route could be hard coded.  Instead it uses dynamic to refernence CommandsController
    //CommandsController is really just commands the controller is a postfix for convention
    [Route("api/[controller]")]
    [ApiController]    
    public class CommandsController : ControllerBase 
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"this", "is", "hard", "coded"};
        }
    }
}