using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using WebApplicationCrud.Model;

namespace WebApplicationCrud.Repository
{
    public interface IClientRepository
    {
        void InitializeClients();
        public List<Client> GetClients();
        public Client GetClientById(string id);
    }

    public class ClientRepository : IClientRepository
    {
        private readonly ILogger<ClientRepository> _logger;
        private List<Client> _clients;

        public ClientRepository(ILogger<ClientRepository> logger)
        {
            _logger = logger;
        }

        public void InitializeClients()
        {
            _clients =  new List<Client>
            {
                new Client
                {
                    Id = "id_1",
                    Name = "nameA"
                },
                new Client
                {
                    Id = "id_2",
                    Name = "nameb"
                }
            };
        }

        public List<Client> GetClients()
        {
            return _clients;
        }      
        
        public Client GetClientById(string id)
        {
            return _clients.FirstOrDefault(x=>x.Id == id);
        }

    }
}
