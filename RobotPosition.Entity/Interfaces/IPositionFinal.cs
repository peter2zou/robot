namespace RobotPosition.Entity
{
    public interface IPositionFinal
    {
        int FinalXPosition { get; set; }
        int FinalYPosition { get; set; }
        char FinalOrientation { get; set; }
        bool Lost { get; set; }
    }
}
