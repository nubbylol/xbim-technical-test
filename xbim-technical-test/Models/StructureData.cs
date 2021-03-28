namespace xbim_technical_test.Models
{
    public class StructureData
    {
        public StructureData(int doors, int walls, int windows)
        {
            Doors = doors;
            Walls = walls;
            Windows = windows;
        }

        public int Doors { get; }
        public int Walls { get; }
        public int Windows { get; }
    }
}