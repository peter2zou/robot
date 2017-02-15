using RobotPosition.Entity;
using System.Threading.Tasks;

namespace RobotPosition.DataAccess
{
    public interface IDataServiceAsync
    {
        Task<IGridIdentifer> GetGridIdentiferAsync(IGridCoordinate gridCoordinate);
        Task<IGridCoordinate> GetGridCoordinateByGridIdAsync(int gridId);
        Task<bool> SaveOffPositionIAsync(int gridId, IPositionFinal offPositionFinal);
        Task<bool> IsOffPositionAsync(int gridId, IPositionFinal offPositionFinal);
    }
}
