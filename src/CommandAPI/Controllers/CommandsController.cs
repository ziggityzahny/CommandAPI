using System.Collections.Generic;
//Remember using this statement
using CommandAPI.Data; 
using CommandAPI.Models; 
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    //Route could be hard coded.  Instead it uses dynamic to refernence CommandsController
    //CommandsController is really just commands the controller is a postfix for convention
    [Route("api/[controller]")]
    [ApiController]    
    public class CommandsController : ControllerBase 
    {
        
        //Page 104 add
        //Add the follwoing code to our class
        private readonly ICommandAPIRepo _repository; 
        
        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository; 
        }

        //Page 107 add
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        //Page 110 add
        //Add the following code for our second ActionResult 
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id) 
        {
            var commandItem = _repository.GetCommandById(id); 
            if (commandItem == null)
            {
                return NotFound(); 
            }
            return Ok(commandItem);
        }

        //Page 104 remove 
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] {"this", "is", "hard", "coded"};
        //}
    }
}