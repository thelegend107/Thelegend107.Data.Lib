using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Diagnostics;
using Thelegend107.Data.Lib.Entities;
using Thelegend107.Data.Lib.Services;

namespace Thelegend107.Data.Lib.Test
{
    [TestClass]
    public class DataTest
    {
        private readonly UserService _userService;
        private readonly CustomerService _customerService;
        private readonly AddressService _addressService;
        private readonly EducationService _educationService;
        private readonly WorkExperienceService _workExperienceService;
        private readonly SkillService _skillService;
        private readonly CertificateService _certificateService;
        private readonly LinkService _linkService;

        private enum DbType
        {
            SQLServer,
            PostgreSQL
        }

        private static DbContextOptions DbContextInit(DbType dbType)
        {
            IConfigurationRoot appSettings = new ConfigurationBuilder().AddJsonFile("local.settings.json").Build();
            
            string? connectionString = string.Empty;
            DbContextOptions? contextOptions = null;
            switch (dbType)
            {
                case DbType.SQLServer:
                    connectionString = appSettings["datawarehouseSqlDb"];
                    contextOptions = new DbContextOptionsBuilder<DatawarehouseContext>().UseSqlServer(connectionString).Options;
                    break;
                case DbType.PostgreSQL:
                    connectionString = appSettings["datawarehousePostgreSqlDb"];
                    contextOptions = new DbContextOptionsBuilder<DatawarehouseContext>().UseNpgsql(connectionString).Options;
                    break;
                default:
                    connectionString = appSettings["datawarehousePostgreSqlDb"];
                    contextOptions = new DbContextOptionsBuilder<DatawarehouseContext>().UseNpgsql(connectionString).Options;
                    break;
            }

            return contextOptions;
        }

        public DataTest()
        {
            DatawarehouseContext dbContext = new DatawarehouseContext(DbContextInit(DbType.PostgreSQL));

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
        public void Can_1_Create_Customer()
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
        public void Can_2_Get_Customer()
        {
            Customer? customer = _customerService.RetrieveCustomer("mma.ayoub@outlook.com").Result;

            Debug.WriteLine(JsonConvert.SerializeObject(customer, Formatting.Indented));
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void Can_3_Delete_Customer()
        {
            bool isDeleted = _customerService.DeleteCustomer("mma.ayoub@outlook.com").Result;
            Assert.IsTrue(isDeleted);
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