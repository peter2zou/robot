using RobotPosition.Entity;

namespace RobotPosition.Service
{
    public interface IRobotPositionServiceSync
    {
        IGridIdentifer GetGridIdentifer(IGridCoordinate gridCoordinate);
        IPositionFinal GetFinalPostion(int Key, IPositionStarting positionStarting);

    }
}
