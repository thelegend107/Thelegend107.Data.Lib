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
        private readonly AddressService _addressService;
        private readonly EducationService _educationService;
        private readonly WorkExperienceService _workExperienceService;
        private readonly SkillService _skillService;
        private readonly CertificateService _certificateService;
        private readonly LinkService _linkService;

        public MySQLTest()
        {
            IConfigurationRoot appSettings = new ConfigurationBuilder().AddJsonFile("local.settings.json").Build();
            string? connectionString = appSettings["datawarehouseMySqlDb"];

            if (connectionString == null)
                throw new ArgumentNullException("Connection string is missing");

            DatawarehouseContext dbContext = new DatawarehouseContext(connectionString);

            _userService = new UserService(dbContext);
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