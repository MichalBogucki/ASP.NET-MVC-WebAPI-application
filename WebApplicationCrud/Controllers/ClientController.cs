using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplicationCrud.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientRepository _clientRepository;

        public ClientController(ILogger<ClientController> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Get request triggered");
            var clients = _clientRepository.GetClients();
            var json = JsonConvert.SerializeObject(clients);
            return json;
        }    
        
        [HttpGet("Initialize")]
        public string Initialize()
        {
            _logger.LogInformation("Initialize request triggered");
            _clientRepository.InitializeClients();
            var clients = _clientRepository.GetClients();
            var json = JsonConvert.SerializeObject(clients);
            return json;
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            _logger.LogInformation($"Get {id} request triggered");
            var client = _clientRepository.GetClientById(id);
            var json = JsonConvert.SerializeObject(client);
            return json;
        }

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _logger.LogInformation("Post request triggered");
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _logger.LogInformation("Put request triggered");
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            _logger.LogInformation("Delete request triggered");
        }
    }
}
