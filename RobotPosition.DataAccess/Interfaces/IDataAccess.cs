using RobotPosition.Entity;
using System.Threading.Tasks;

namespace RobotPosition.DataAccess
{
    public interface IDataService:IDataServiceAsync, IDataServiceSync
    {
    }
}
