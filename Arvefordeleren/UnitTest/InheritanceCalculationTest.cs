using Arvefordeleren_ClassLibrary.Enums;
using Arvefordeleren_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestAPI
{
    [TestClass]
    public sealed class InheritanceCalculationTest
    {
        [TestInitialize]
        public void Initialize() // Arrange
        {
            var asset1 = new Asset
            {
                Name = "Family House",
                SeparateEstate = "Yes"
            };

            var asset2 = new Asset
            {
                Name = "Vacation Cabin",
                SeparateEstate = null
            };

            var asset3 = new Asset
            {
                Name = "Car",
                SeparateEstate = "No"
            };

            var asset4 = new Asset
            {
                Name = "Jewelry Collection",
                SeparateEstate = "Yes"
            };


            var testator1 = new Testator
            {
                FirstName = "Robert",
                LastName = "Doe",
                WillType = WillType.Individual,
                RelationType = RelationType.MARRIED
            };

            var testator2 = new Testator
            {
                FirstName = "Susan",
                LastName = "Doe",
                WillType = WillType.Joint,
                RelationType = RelationType.MARRIED
            };

            var heir1 = new Heir
            {
                FirstName = "John",
                LastName = "Doe",
                RelationType = RelationType.CHILD,
                Percent = 50,
                Mid = testator1.Id,
                Fid = testator2.Id
            };

            var heir2 = new Heir
            {
                FirstName = "Jane",
                LastName = "Doe",
                RelationType = RelationType.CHILD,
                Percent = 50,
                Mid = testator1.Id,
                Fid = testator2.Id
            };

            var heir3 = new Heir
            {
                FirstName = "Michael",
                LastName = "Smith",
                RelationType = RelationType.SIBLING,
                Percent = 20,
                Mid = testator1.Id,
            };

            var heir4 = new Heir
            {
                FirstName = "Emily",
                LastName = "Johnson",
                RelationType = RelationType.SIBLING,
                Percent = 20,
                Mid = testator1.Id,
            };

            var heir5 = new Heir
            {
                FirstName = "David",
                LastName = "Brown",
                RelationType = RelationType.GRAND_CHILD,
                Percent = 10,
                Fid = testator2.Id
            };

            var heir6 = new Heir
            {
                FirstName = "Laura",
                LastName = "Taylor",
                RelationType = RelationType.GRAND_CHILD,
                Percent = 10,
                Fid = testator2.Id
            };
            testator1.Persons = new List<Person> { testator2, heir1, heir2, heir3, heir4 };
            testator2.Persons = new List<Person> { testator1, heir5, heir6 };
        }
    }
}
