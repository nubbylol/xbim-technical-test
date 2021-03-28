using System.Collections.Generic;
using xbim_technical_test.Models;

namespace xbim_technical_test.Interfaces
{
    public interface IStructure
    {
        StructureTypeEnum StructureTypeEnum { get; }
        StructureData GetStructureData();
        List<StructureRoom> GetStructureRooms();
    }
}