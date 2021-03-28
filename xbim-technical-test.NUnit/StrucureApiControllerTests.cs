using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using xbim_technical_test.Controllers;
using xbim_technical_test.Interfaces;
using xbim_technical_test.Models;

namespace xbim_technical_test.NUnit
{
    [TestFixture]
    public class StructureApiControllerTests
    {
        [Test]
        public void GivenMockedStructureThrowsError_WhenGettingData_ThenDoesNotReturnNullResult()
        {
            var mockedStructure = new Mock<IStructure>();
            mockedStructure.Setup(s => s.GetStructureData()).Throws(new NotImplementedException());
            var apiController = new StructureApiController(mockedStructure.Object);

            var result = apiController.GetData();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.FailedDependency));
        }
        
        [Test]
        public void GivenMockedStructureThrowsError_WhenGettingRooms_ThenDoesNotReturnNullResult()
        {
            var mockedStructure = new Mock<IStructure>();
            mockedStructure.Setup(s => s.GetStructureRooms()).Throws(new NotImplementedException());
            var apiController = new StructureApiController(mockedStructure.Object);

            var result = apiController.GetRooms();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.FailedDependency));
        }

        [Test]
        public void GivenMockedStructure_WhenGettingMetaData_ReturnsExpectedResult()
        {
            var apiController = new StructureApiController(GetMockedStructure());

            var result = apiController.GetData();
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void GivenMockedStructure_WhenGettingRooms_ReturnsExpectedResult()
        {
            var apiController = new StructureApiController(GetMockedStructure());

            var result = apiController.GetRooms();
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        #region TestHelpers

        private static IStructure GetMockedStructure()
        {
            var mock = new Mock<IStructure>();
            mock.Setup(s => s.GetStructureData()).Returns(GetTestStructureData);
            mock.Setup(s => s.GetStructureRooms()).Returns(GetTestCollectionStructureRooms);

            return mock.Object;
        }
        private static StructureData GetTestStructureData()
        {
            return new StructureData(1, 4, 2);
        }
        private static List<StructureRoom> GetTestCollectionStructureRooms()
        {
            return new List<StructureRoom>
            {
                new StructureRoom("Test Room 1", 100),
                new StructureRoom("Test Room 2", 150),
            };
        }

        #endregion
    }
}