using System.ComponentModel.DataAnnotations;
namespace RobotPosition.Entity
{
    public class GridCoordinate:IGridCoordinate
    {
        [MaxLength(50)]
        public int MaxXCoordinate {set;get;}
        [MaxLength(50)]
        public int MaxYCoordinate {set;get;}
    }
}
