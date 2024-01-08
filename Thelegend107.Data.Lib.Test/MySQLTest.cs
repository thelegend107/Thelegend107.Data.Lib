using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Diagnostics;
using Thelegend107.MySQL.Data.Lib;
using Thelegend107.MySQL.Data.Lib.Entities;
using Thelegend107.MySQL.Data.Lib.Services;

namespace Thelegend107.Data.Lib.Test
{
    [TestClass]
    public class MySQLTest
    {
        private readonly UserService _userService;
        private readonly CustomerService _customerService;
        private readonly AddressService _addressService;
        private readonly EducationService _educationService;
        private readonly WorkExperienceService _workExperienceService;
        private readonly SkillService _skillService;
        private readonly CertificateService _certificateService;
        private readonly LinkService _linkService;

        private static DbContextOptions DbContextInit()
        {
            IConfigurationRoot appSettings = new ConfigurationBuilder().AddJsonFile("local.settings.json").Build();
            string? connectionString = appSettings["datawarehouseMySqlDb"];

            if (connectionString == null)
                throw new ApplicationException("Connection string is missing");

            DbContextOptions contextOptions = new DbContextOptionsBuilder<DatawarehouseContext>().UseMySQL(connectionString).Options;
            return contextOptions;
        }

        public MySQLTest()
        {
            DatawarehouseContext dbContext = new DatawarehouseContext(DbContextInit());

            _userService = new UserService(dbContext);
            _customerService = new CustomerService(dbContext);
            _addressService = new AddressService(dbContext);
            _educationService = new EducationService(dbContext);
            _workExperienceService = new WorkExperienceService(dbContext);
            _skillService = new SkillService(dbContext);
            _certificateService = new CertificateService(dbContext);
            _linkService = new LinkService(dbContext);
        }

        [TestMethod]
        public void Can_Get_User()
        {
            User? user = _userService.RetrieveUserById(1).Result;

            Debug.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Can_Get_Customer()
        {
            Customer? customer = _customerService.RetrieveCustomerByEmail("mma.ayoub@outlook.com").Result;

            Debug.WriteLine(JsonConvert.SerializeObject(customer, Formatting.Indented));
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void Can_Create_Customer()
        {
            Customer customer = new Customer() 
            {
                Company = "TheLegend107",
                FirstName = "Moe",
                LastName = "Ayoub",
                Email = "mma.ayoub@outlook.com",
                Password = "password",
                PhoneNumber = "1234567890",
                IsAdmin = true,
            };

            customer = _customerService.CreateNewCustomer(customer).Result;

            Debug.WriteLine(JsonConvert.SerializeObject(customer, Formatting.Indented));
            Assert.IsNotNull(customer.Id);
        }

        [TestMethod]
        public void Can_Get_Address()
        {
            Address? address = _addressService.RetrieveAddressById(1).Result;

            Debug.WriteLine(JsonConvert.SerializeObject(address, Formatting.Indented));
            Assert.IsNotNull(address);
        }

        [TestMethod]
        public void Can_Get_Educations()
        {
            IEnumerable<Education> educations = _educationService.RetrieveEducations(1).Result;

            Debug.WriteLine(JsonConvert.SerializeObject(educations, Formatting.Indented));
            Assert.IsNotNull(educations);
        }

        [TestMethod]
        public void Can_Get_WorkExperiences()
        {
            IEnumerable<WorkExperience> workExperiences = _workExperienceService.RetrieveWorkExperiences(1).Result;

            Debug.WriteLine(JsonConvert.SerializeObject(workExperiences, Formatting.Indented));
            Assert.IsNotNull(workExperiences);
        }

        [TestMethod]
        public void Can_Get_Skills()
        {
            IEnumerable<Skill> skills = _skillService.RetrieveSkills(1).Result;

            Debug.WriteLine(JsonConvert.SerializeObject(skills, Formatting.Indented));
            Assert.IsNotNull(skills);
        }

        [TestMethod]
        public void Can_Get_Certificates()
        {
            IEnumerable<Certificate> certificates = _certificateService.RetrieveCertifcates(1).Result;

            Debug.WriteLine(JsonConvert.SerializeObject(certificates, Formatting.Indented));
            Assert.IsNotNull(certificates);
        }

        [TestMethod]
        public void Can_Get_Links()
        {
            IEnumerable<Link> links = _linkService.RetrieveLinks(1).Result;

            Debug.WriteLine(JsonConvert.SerializeObject(links, Formatting.Indented));
            Assert.IsNotNull(links);
        }
    }
}