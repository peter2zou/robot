namespace RobotPosition.Entity
{
    public interface IPositionStarting
    {
        int StartingXPosition { set; get; }
        int StartingYPosition { set; get; }
        char Orientation { set; get; }
        string Instructions { set; get; }
    }
}
