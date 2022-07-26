using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WebApplicationCrud.Extensions;
using WebApplicationCrud.Model;
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
        public async Task<object> Get()
        {
            _logger?.LogInformation("Get request triggered");
            var clients = await _clientRepository.GetClients();
            //var json = JsonConvert.SerializeObject(clients);
            return StatusCode(200, clients);
        }

        [HttpGet("Initialize")]
        public async Task<object> Initialize()
        {
            _logger?.LogInformation("Initialize request triggered");
            await _clientRepository.InitializeClients();
            var clients = await _clientRepository.GetClients();
            //var json = JsonConvert.SerializeObject(clients);
            return StatusCode(200, clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(string id)
        {
            _logger?.LogInformation($"Get {id} request triggered");
            var client = _clientRepository.GetClientById(id);
            //var json = JsonConvert.SerializeObject(clients);
            return StatusCode(200, client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<object> Post([FromBody] Client client)
        {
            _clientRepository.UpdateClientName(client);
            _logger?.LogInformation("Post request triggered");
            return StatusCode(HttpStatusCode.Created.ToInt(), client);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<object> Put([FromBody] Client client)
        {
            _clientRepository.AddClientById(client);
            _logger?.LogInformation("Put request triggered");
            return StatusCode(HttpStatusCode.Created.ToInt(), client);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(string id)
        {
            _clientRepository.DeleteClientById(id);
            _logger?.LogInformation("Delete request triggered");
            return StatusCode(HttpStatusCode.OK.ToInt(), "deleted");
        }

    }
}
