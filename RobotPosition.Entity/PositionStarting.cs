namespace RobotPosition.Entity
{
    public class PositionStarting: IPositionStarting
    {
        public int StartingXPosition {get;set;}
        public int StartingYPosition {get;set;}
        public char Orientation {get;set;}
        public string Instructions {get;set;}
    }
}
