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

            var heir1 = new Heir
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1985, 7, 15),
                Address = "123 Main St",
                Relation = "Son",
                InheritanceShare = "50%",
                RelationType = RelationType.CHILD,
                Percent = 50,
                Mid = Guid.NewGuid(),
                Fid = Guid.NewGuid()
            };

            var heir2 = new Heir
            {
                FirstName = "Jane",
                LastName = "Doe",
                DateOfBirth = new DateTime(1988, 4, 20),
                Address = "456 Maple Ave",
                Relation = "Daughter",
                InheritanceShare = "50%",
                RelationType = RelationType.CHILD,
                Percent = 50,
                Mid = Guid.NewGuid(),
                Fid = Guid.NewGuid()
            };

            var heir3 = new Heir
            {
                FirstName = "Michael",
                LastName = "Smith",
                DateOfBirth = new DateTime(1960, 5, 10),
                Address = "789 Elm Rd",
                Relation = "Brother",
                InheritanceShare = "20%",
                RelationType = RelationType.SIBLING,
                Percent = 20,
                Mid = Guid.NewGuid(),
                Fid = Guid.NewGuid()
            };

            var heir4 = new Heir
            {
                FirstName = "Emily",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1975, 3, 25),
                Address = "321 Oak Ln",
                Relation = "Sister",
                InheritanceShare = "20%",
                RelationType = RelationType.SIBLING,
                Percent = 20,
                Mid = Guid.NewGuid(),
                Fid = Guid.NewGuid()
            };

            var heir5 = new Heir
            {
                FirstName = "David",
                LastName = "Brown",
                DateOfBirth = new DateTime(1990, 8, 5),
                Address = "654 Pine St",
                Relation = "Grandchild",
                InheritanceShare = "10%",
                RelationType = RelationType.GRAND_CHILD,
                Percent = 10,
                Mid = Guid.NewGuid(),
                Fid = Guid.NewGuid()
            };

            var heir6 = new Heir
            {
                FirstName = "Laura",
                LastName = "Taylor",
                DateOfBirth = new DateTime(1992, 12, 15),
                Address = "987 Cedar Blvd",
                Relation = "Grandchild",
                InheritanceShare = "10%",
                RelationType = RelationType.GRAND_CHILD,
                Percent = 10,
                Mid = Guid.NewGuid(),
                Fid = Guid.NewGuid()
            };

            var testator1 = new Testator
            {
                FirstName = "Robert",
                LastName = "Doe",
                DateOfBirth = new DateTime(1960, 10, 1),
                Address = "111 Testator Ave",
                WillType = WillType.Individual,
                RelationType = RelationType.MARRIED,
                ForcedInheritance = "70%",
                FreeInheritance = "30%",
                Date = DateTime.Now,
                Heirs = new List<Heir> { heir1, heir2 }
            };

            var testator2 = new Testator
            {
                FirstName = "Susan",
                LastName = "Doe",
                DateOfBirth = new DateTime(1965, 6, 30),
                Address = "222 Testator Blvd",
                WillType = WillType.Joint,
                RelationType = RelationType.MARRIED,
                ForcedInheritance = "50%",
                FreeInheritance = "50%",
                Date = DateTime.Now,
                Heirs = new List<Heir> { heir3, heir4, heir5, heir6 }
            };

        }
    }
}
