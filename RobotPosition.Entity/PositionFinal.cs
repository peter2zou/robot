namespace RobotPosition.Entity
{
    public class PositionFinal: IPositionFinal
    {
        public int FinalXPosition {get;set;}
        public int FinalYPosition {get;set;}
        public char FinalOrientation { get;set;}
        public bool Lost {get;set;}
    }
}
