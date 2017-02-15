using System.Web.Http;
using RobotPosition.Entity;
using RobotPosition.Service;
using System.Threading.Tasks;

namespace RobotPosition.WebAPI.Controllers
{
    public class GridController : ApiController
    {
        IRobotPositionService _service;
        public GridController(IRobotPositionService service)
        {
            _service = service;
        }

        //POST: grid
        [Route("grid")]
        [HttpPost]
        public async Task<IGridIdentifer> GetGridIdentiferAsync(GridCoordinate value)
        {
            return await _service.GetGridIdentiferAsync(value);
        }

        //public IGridIdentifer GetGridIdentifer(GridCoordinate value)
        //{
        //    return _service.GetGridIdentifer(value);
        //}


        // POST: grid/1/rover
        [Route("grid/{gridId}/rover")]
        [HttpPost]
        public async Task<IPositionFinal> GetFinalPostionAsync(int gridId, PositionStarting value)
        {
            return await _service.GetFinalPostionAsync(gridId, value);
        }

        //public IPositionFinal GetFinalPostion(int gridId, PositionStarting value)
        //{
        //    return _service.GetFinalPostion(gridId, value);
        //}

    }
}
