namespace xbim_technical_test.Models
{
    public class StructureRoom
    {
        public StructureRoom(string name, decimal floorSpace)
        {
            Name = name;
            FloorSpace = floorSpace;
        }

        public string Name { get; }
        public decimal FloorSpace { get; }
    }
}