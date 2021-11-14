using NUnit.Framework;
using SuperHeroLab.Data.Repository;

namespace SuperHeroLabTest
{
    public class HeroSearchRepositoryTest
    {
        private HeroSearchRepository _search;    

        [SetUp]
        public void Setup()
        {
            _search = new HeroSearchRepository();
        }

        [Test]
        public void GetData_ValidId_ReturnsSuccess()
        {
            int id = 644;
            var response = _search.GetData(id);
            Assert.AreEqual("success", response.Response);
            Assert.Pass();
        }

        [Test]
        public void GetData_InvalidId_ReturnsError()
        {
            int id = 999999999;
            var response = _search.GetData(id);
            Assert.AreEqual("error", response.Response);
            Assert.Pass();
        }
    }
}