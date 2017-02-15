using RobotPosition.Entity;
using RobotPosition.DataAccess;
using System.Threading.Tasks;

namespace RobotPosition.Service
{
    public class RobotPositionService : IRobotPositionService
    {
        private IDataService _dataService;
        public RobotPositionService(IDataService dataService)
        {
            _dataService = dataService;
        }
        public IGridIdentifer GetGridIdentifer(IGridCoordinate gridCoordinate)
        {
            return _dataService.GetGridIdentifer(gridCoordinate);
        }

        public async Task<IGridIdentifer> GetGridIdentiferAsync(IGridCoordinate gridCoordinate)
        {
            return await _dataService.GetGridIdentiferAsync(gridCoordinate);
        }

        public IPositionFinal GetFinalPostion(int gridId, IPositionStarting positionStarting)
        {
            IGridCoordinate gridCoordinate = _dataService.GetGridCoordinateByGridId(gridId);
            IPositionFinal positionFinal = new PositionFinal
            {
                FinalXPosition = positionStarting.StartingXPosition,
                FinalYPosition = positionStarting.StartingYPosition,
                FinalOrientation = positionStarting.Orientation,
                Lost = false
            };
            char[] array = positionStarting.Instructions.ToCharArray();
            foreach (char instruction in array)
            {
                if (positionFinal.Lost)
                {
                    _dataService.SaveOffPosition(gridId, positionFinal);
                    break;
                }
                switch (instruction)
                {
                    case 'L':
                        LeftInstructionProcess(positionFinal);
                        break;
                    case 'R':
                        RightInstructionProcess(positionFinal);
                        break;
                    case 'F':
                        if (!_dataService.IsOffPosition(gridId, positionFinal))
                            ForwardInstructionProcess(positionFinal, gridCoordinate);
                        break;
                    default:
                        break;
                }
            }
            return positionFinal;
        }
    
        public async Task<IPositionFinal> GetFinalPostionAsync(int gridId, IPositionStarting positionStarting)
        {
            return await Task.FromResult(GetFinalPostion(gridId, positionStarting));
        }

        private void RightInstructionProcess(IPositionFinal positionFinal)
        {
            string rightDirections = "NESW";
            positionFinal.FinalOrientation = (rightDirections[(rightDirections.IndexOf(positionFinal.FinalOrientation) + 1) % 4]);
        }

        private void LeftInstructionProcess(IPositionFinal positionFinal)
        {
            string leftDirections = "NWSE";
            positionFinal.FinalOrientation = (leftDirections[(leftDirections.IndexOf(positionFinal.FinalOrientation) + 1) % 4]);
        }

        private void ForwardInstructionProcess(IPositionFinal positionFinal, IGridCoordinate gridCoordinate)
        {
            switch (positionFinal.FinalOrientation)
            {
                case 'N':
                    if (positionFinal.FinalYPosition + 1 > gridCoordinate.MaxYCoordinate)
                        positionFinal.Lost = true;
                    else
                        positionFinal.FinalYPosition += 1;
                    break;
                case 'S':
                    if (positionFinal.FinalYPosition - 1 < 0)
                        positionFinal.Lost = true;
                    else
                        positionFinal.FinalYPosition -= 1;
                    break;
                case 'E':
                    if (positionFinal.FinalXPosition + 1 > gridCoordinate.MaxXCoordinate)
                        positionFinal.Lost = true;
                    else
                        positionFinal.FinalXPosition += 1;
                    break;
                case 'W':
                    if (positionFinal.FinalXPosition - 1 < 0)
                        positionFinal.Lost = true;
                    else
                        positionFinal.FinalXPosition -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}
