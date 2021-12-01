using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationCrud.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using WebApplicationCrud.Model;
using WebApplicationCrud.Repository;

namespace WebApplicationCrud.Controllers.Tests
{
    [TestClass()]
    public class ClientControllerTests
    {
        private static readonly Mock<ILogger<ClientController>> ClientControllerLogger = new Mock<ILogger<ClientController>>();
        private static readonly Mock<ILogger<ClientRepository>> ClientControllerRepository= new Mock<ILogger<ClientRepository>>();
        private static readonly IClientRepository ClientRepository = new ClientRepository(ClientControllerRepository.Object);

        private readonly ClientController _manager = new ClientController(ClientControllerLogger.Object, ClientRepository);

        [TestMethod()]
        public async Task GetTest()
        {
            var getResult = await _manager.Get();
            var expectedEmpty = "[]";
            Assert.AreEqual(expectedEmpty, getResult);
        }

        [TestMethod()]
        public async Task InitializeTest()
        {
            var getResult = await _manager.Initialize();
            var clients = JsonConvert.DeserializeObject<List<Client>>(getResult);

            Assert.IsNotNull(clients);
            Assert.AreEqual(2, clients.Count);
        }

        [TestMethod()]
        public async Task PutTest()
        {
            var empty = await _manager.Get();
            var client = new Client()
            {
                Id = "Id_3",
                Name = "name3"
            };

            await _manager.Put("id_3", client);
            var existingJson= await _manager.Get();
            var clients = JsonConvert.DeserializeObject<Client>(existingJson);

            var expectedEmpty = "[]";
            Assert.AreEqual(expectedEmpty, empty);
            Assert.AreEqual("Id_3", clients.Id);
            Assert.AreEqual("name3", clients.Name);
        }
    }
}