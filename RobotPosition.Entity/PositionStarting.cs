using System.ComponentModel.DataAnnotations;
namespace RobotPosition.Entity
{
    public class PositionStarting: IPositionStarting
    {
        [MaxLength(50)]
        public int StartingXPosition {get;set;}
        [MaxLength(50)]
        public int StartingYPosition {get;set;}
        public char Orientation {get;set;}
        [MaxLength(15)]
        public string Instructions {get;set;}
    }
}
