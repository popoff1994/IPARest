using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestExcercise.Managers;
using RestExcercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestExcercise.Managers.Tests
{
    [TestClass()]
    public class IPAsManagerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            IPAsManager IPAS = new IPAsManager();
            string citra = "Citra";
            int proof = 0;
            int expectedResult = 3;
            //Act

            var ipaList = IPAS.GetAll(null, 0);

            //Assert
            //if (ipaList.Count > 0 && ipaList.Count < )
                //Assert.IsTrue(ipaList.Count > 0);
            Assert.AreEqual(expectedResult, ipaList.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            //Arrange
            IPAsManager IPAS = new IPAsManager();
            int id = 3;
            string expectedIPAName = "Citra";
            //Act
            var result = IPAS.GetById(id);

            //Assert
            Assert.AreEqual(expectedIPAName, result.Name);


        }

        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            IPAsManager IPAS = new IPAsManager();
            IPA ipa = new IPA(4, 2.0, "Special IPA", "brand");
           
            //Act
            var ipas = IPAS.Add(ipa);

            //Assert
            Assert.IsNotNull(ipas);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Arrange
            IPAsManager IPAS = new IPAsManager();
            string expectedResult = "Wipeout IPA";
            int id = 1;
            //Act
            
            var result = IPAS.Delete(id);
            //Assert
            Assert.AreEqual(expectedResult, result.Name);
            
        }
        
        [TestMethod()]
        public void UpdateTest()
        {
            //Arrange
            IPAsManager IPAs = new IPAsManager();
            IPA ipa = new IPA();
            ipa.Id = 1;
            ipa.Proof = 4.0;
            ipa.Name = "Special";
            ipa.Brand = "Carlsberg";

            string expectedIPA = "Special";
            //Act
            var result = IPAs.Update(1, ipa);

            //Assert
            Assert.AreEqual(expectedIPA, result.Name);
        }
    }
}