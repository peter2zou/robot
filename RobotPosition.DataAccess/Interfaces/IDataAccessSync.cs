using RobotPosition.Entity;
using System.Threading.Tasks;

namespace RobotPosition.DataAccess
{
    public interface IDataServiceSync
    {
        IGridIdentifer GetGridIdentifer(IGridCoordinate gridCoordinate);
        IGridCoordinate GetGridCoordinateByGridId(int gridId);
        bool SaveOffPosition(int gridId, IPositionFinal offPositionFinal);
        bool IsOffPosition(int gridId, IPositionFinal offPositionFinal);
    }
}
