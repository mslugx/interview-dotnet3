using System.Linq;
using System.Threading.Tasks;
using Autofac;
using GroceryStoreAPI.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryStoreAPI.UnitTest
{
    [TestClass]
    public class CustomerUnitTests: BaseUnitTest
    {
        private ICustomerService _customerService;

        [TestInitialize]
        public void Initialization()
        {
            InitializeBaseUnitTest();
            _customerService = _serviceContainer.Resolve<ICustomerService>();
            PopulateDb();   //populating database
            
        }

        [TestMethod]
        public async Task GetCustomers_Success()
        {
            var customerList = await _customerService.GetCustomers();
            Assert.AreEqual("Mary", customerList.First(op=>op.Name =="Mary").Name);
        }

        [TestMethod]
        [DataRow(1,"Bob")]
        [DataRow(2,"Mary")]
        public async Task GetCustomer_OK(int id, string name)
        {
            var customer = await _customerService.GetCustomer(id);
            Assert.AreEqual(name, customer.Name);
            Assert.AreEqual(id, customer.Id);
        }

        [TestMethod]
        [DataRow(55)]
        [DataRow(33)]
        public async Task GetCustomer_NotFound(int id)
        {
            var customer = await _customerService.GetCustomer(id);
            Assert.IsNull(customer);
        }
    }
}
