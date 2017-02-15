using RobotPosition.Entity;
using System.Threading.Tasks;

namespace RobotPosition.Service
{
    public interface IRobotPositionServiceAsync
    {
        Task<IGridIdentifer> GetGridIdentiferAsync(IGridCoordinate gridCoordinate);
        Task<IPositionFinal> GetFinalPostionAsync(int Key, IPositionStarting positionStarting);

    }
}
