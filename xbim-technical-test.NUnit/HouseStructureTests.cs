using System.Linq;
using NUnit.Framework;
using xbim_technical_test.Implementations;

namespace xbim_technical_test.NUnit
{
    [TestFixture]
    public class HouseStructureTests
    {
        [Test]
        public void GivenIfcFile_WhenGettingRooms_ThenReturnsExpectedRooms()
        {
            var structure = new HouseStructure("TestFiles/SampleHouse4.ifc");
            
            var result = structure.GetStructureRooms();
            var room = result.First();
            
            Assert.That(result, Is.Not.Null);
            Assert.That(room.Name, Is.Not.EqualTo(string.Empty));
            Assert.That(room.FloorSpace, Is.GreaterThan(0));
        }

        [Test]
        public void GivenIfcFile_WhenGettingData_ThenReturnsExpectedData()
        {
            var structure = new HouseStructure("TestFiles/SampleHouse4.ifc");
            var result = structure.GetStructureData();
            
            Assert.That(result, Is.Not.Null);
            Assert.Greater(result.Doors, 0);
            Assert.Greater(result.Windows, 0);
            Assert.Greater(result.Walls, 0);
        }
    }
}