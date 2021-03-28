using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using xbim_technical_test.Interfaces;
using xbim_technical_test.Models;

namespace xbim_technical_test.Implementations
{
    public class HouseStructure : IStructure
    {
        private static readonly string _filePath = "Bims/SampleHouse4.ifc";
        private IfcStore Model { get; set; }
        
        public HouseStructure()
        {
            LoadFile(_filePath);
        }

        public HouseStructure(string filePath)
        {
            LoadFile(filePath);
        }

        private void LoadFile(string filePath)
        {
            try
            {
                Model = IfcStore.Open(filePath);
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong loading in the file");
            }
        }

        public StructureTypeEnum StructureTypeEnum => StructureTypeEnum.House;
        public StructureData GetStructureData()
        {
            var doors = Model.Instances.OfType<IIfcDoor>().Count();
            var walls = Model.Instances.OfType<IIfcWall>().Count();
            var windows = Model.Instances.OfType<IIfcWindow>().Count();

            return new StructureData(doors, walls, windows);
        }

        public List<StructureRoom> GetStructureRooms()
        {
            return Model.Instances.OfType<IIfcSpace>()
                .Select(x => new StructureRoom(x.Name,
                    GetAreaDecimal(x)))
                .ToList();
        }

        private decimal GetAreaDecimal(IIfcSpace space)
        {
            return Convert.ToDecimal(GetArea(space).Value);
        }
        
        private static IIfcValue GetArea(IIfcProduct product)
        {
            var area =
                product.IsDefinedBy.SelectMany(r => r.RelatingPropertyDefinition.PropertySetDefinitions)
                    .OfType<IIfcElementQuantity>()
                    .SelectMany(qset => qset.Quantities)
                    .OfType<IIfcQuantityArea>()
                    .FirstOrDefault()
                    .AreaValue;

            if (area != null)
            {
                return area;
            }

            return GetProperty(product, "Area");
        }
        
        private static IIfcValue GetProperty(IIfcProduct product, string name)
        {
            var area = product.IsDefinedBy.SelectMany(r => r.RelatingPropertyDefinition.PropertySetDefinitions)
                .OfType<IIfcPropertySet>()
                .SelectMany(pset => pset.HasProperties)
                .OfType<IIfcPropertySingleValue>()
                .Where(p => string.Equals(p.Name, name, System.StringComparison.OrdinalIgnoreCase) ||
                            p.Name.ToString().ToLower().Contains(name.ToLower()))
                .FirstOrDefault()
                .NominalValue;

            return area;
        }
    }
}