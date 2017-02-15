using System.ComponentModel.DataAnnotations;
namespace RobotPosition.Entity
{
    public class PositionFinal: IPositionFinal
    {
        [MaxLength(50)]
        public int FinalXPosition {get;set;}
        [MaxLength(50)]
        public int FinalYPosition {get;set;}
        public char FinalOrientation { get;set;}
        public bool Lost {get;set;}
    }
}
