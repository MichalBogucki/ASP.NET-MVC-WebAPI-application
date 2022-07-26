using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCrud.Model;

namespace WebApplicationCrud.Repository
{
    public interface IClientRepository
    {
        Task InitializeClients();
        public Task<List<Client>> GetClients();
        public Task<Client> GetClientById(string id);
        void UpdateClientName(Client client);
        void AddClientById(Client client);
        void DeleteClientById(string id);
    }

    public class ClientRepository : IClientRepository
    {
        private readonly ILogger<ClientRepository> _logger;
        private List<Client> _clients = new List<Client>();

        public ClientRepository(ILogger<ClientRepository> logger)
        {
            _logger = logger;
        }

        public async Task InitializeClients()
        {
            _clients = new List<Client>
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

        public async Task<List<Client>> GetClients()
        {
            return _clients;
        }

        public async Task<Client> GetClientById(string id)
        {
            return _clients.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateClientName(Client client)
        {
            _clients.Find(x => x.Id == client.Id)!.Name = client.Name;
        }

        public void AddClientById(Client client)
        {
            _clients.Add(client);
        }

        public void DeleteClientById(string id)
        {
            var toBeDeleted = _clients.FirstOrDefault(x => x.Id == id);
            _clients.Remove(toBeDeleted);
        }
    }
}
