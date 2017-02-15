using System.Collections.Generic;
using System.Linq;
using RobotPosition.Entity;
using System.Threading.Tasks;

namespace RobotPosition.DataAccess
{
    public class DataService : IDataService
    {
        //This is just for demo purpose. for real one, it should be saved to repository.
        private static IDictionary<int, IGridCoordinate> gridDictionary = new Dictionary<int, IGridCoordinate>();
        private static IDictionary<int, IList<IPositionFinal>> offDictionary = new Dictionary<int, IList<IPositionFinal>>();
        public IGridIdentifer GetGridIdentifer(IGridCoordinate gridCoordinate)
        {
            int gridId = 0;
            if (gridDictionary.Values.Count > 0)
            {
                gridId = gridDictionary.FirstOrDefault(
                    grid => 
                    grid.Value.MaxXCoordinate == gridCoordinate.MaxXCoordinate 
                    && grid.Value.MaxYCoordinate == gridCoordinate.MaxYCoordinate
                ).Key;
            }
            if (gridId==0)
            {
                gridDictionary.Add(gridDictionary.Keys.Count() + 1, gridCoordinate);
                gridId = gridDictionary.Keys.Count;
            }
            return new GridIdentifer { GridID = gridId};
        }

        public async Task<IGridIdentifer> GetGridIdentiferAsync(IGridCoordinate gridCoordinate)
        {
            return await Task.FromResult(GetGridIdentifer(gridCoordinate));
        }


        public IGridCoordinate GetGridCoordinateByGridId(int gridId)
        {
            if (gridId > 0)
            {
                return gridDictionary[gridId];
            }
            return null;
        }

        public async Task<IGridCoordinate> GetGridCoordinateByGridIdAsync(int gridId)
        {
            return await Task.FromResult(GetGridCoordinateByGridId(gridId));
        }

        public bool SaveOffPosition(int gridId, IPositionFinal offPositionFinal)
        {
            bool result = false;
            if (offPositionFinal.Lost)
            {
                if (!offDictionary.ContainsKey(gridId))
                {
                    IList<IPositionFinal> list = new List<IPositionFinal>();
                    list.Add(offPositionFinal);
                    offDictionary.Add(gridId, list);
                    result = true;
                }
                else
                {
                    if (!IsOffPosition(gridId, offPositionFinal))
                    {
                        offDictionary[gridId].Add(offPositionFinal);
                        result = true;
                    }
                }
            }
            return result;
        }

        public async Task<bool> SaveOffPositionIAsync(int gridId, IPositionFinal offPositionFinal)
        {
            return await Task.FromResult(SaveOffPosition(gridId, offPositionFinal));
        }

        public bool IsOffPosition(int gridId, IPositionFinal offPositionFinal)
        {
            bool result = false;
            if (offDictionary.ContainsKey(gridId))
            {
                var offPosition = offDictionary[gridId].FirstOrDefault(
                    item => 
                    item.FinalXPosition == offPositionFinal.FinalXPosition 
                    && item.FinalYPosition == offPositionFinal.FinalYPosition 
                    && item.FinalOrientation == offPositionFinal.FinalOrientation 
                    && item.Lost
                    );
                result = offPosition != null;
            }
            return result;
        }

        public async Task<bool> IsOffPositionAsync(int gridId, IPositionFinal offPositionFinal)
        {
            return await Task.FromResult(IsOffPosition(gridId, offPositionFinal));
        }

    }
}
