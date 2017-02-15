using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RobotPosition.Entity;
using RobotPosition.DataAccess;
using System.Threading.Tasks;

namespace RobotPosition.DataAccess.Test
{
    [TestClass]
    public class DataService_UnitTest
    {
        IDataService dataService;
        [TestInitialize]
        public void TestInitialize()
        {
            dataService = new DataService();
        }

        [TestMethod]
        public void Test_DataService_GetGridIdentifer()
        {
            IGridCoordinate gridCoordinate1 = new GridCoordinate { MaxXCoordinate = 5, MaxYCoordinate = 3 };
            IGridIdentifer gridIdentifer1 = dataService.GetGridIdentifer(gridCoordinate1);
            Assert.AreEqual(1, gridIdentifer1.GridID);

            //Should be still 1 if the data is existing.
            IGridCoordinate gridCoordinate2 = new GridCoordinate { MaxXCoordinate = 5, MaxYCoordinate = 3 };
            IGridIdentifer gridIdentifer2 = dataService.GetGridIdentifer(gridCoordinate2);
            Assert.AreEqual(1, gridIdentifer2.GridID);

            IGridCoordinate gridCoordinate3 = new GridCoordinate { MaxXCoordinate = 5, MaxYCoordinate = 5 };
            IGridIdentifer gridIdentifer3 = dataService.GetGridIdentifer(gridCoordinate3);
            Assert.AreEqual(2, gridIdentifer3.GridID);
        }

        [TestMethod]
        public async Task Test_DataService_GetGridIdentiferAsync()
        {
            IGridCoordinate gridCoordinate1 = new GridCoordinate { MaxXCoordinate = 4, MaxYCoordinate = 3 };
            IGridIdentifer gridIdentifer1 = await dataService.GetGridIdentiferAsync(gridCoordinate1);
            Assert.AreEqual(3, gridIdentifer1.GridID);
            //Should be still 1 if the data is existing.
            IGridCoordinate gridCoordinate2 = new GridCoordinate { MaxXCoordinate = 4, MaxYCoordinate = 3 };
            IGridIdentifer gridIdentifer2 = await dataService.GetGridIdentiferAsync(gridCoordinate2);
            Assert.AreEqual(3, gridIdentifer2.GridID);
            IGridCoordinate gridCoordinate3 = new GridCoordinate { MaxXCoordinate = 4, MaxYCoordinate = 5 };
            var gridIdentifer3 = await dataService.GetGridIdentiferAsync(gridCoordinate3);
            Assert.AreEqual(4, gridIdentifer3.GridID);
        }

        [TestMethod]
        public void Test_DataService_GetGridCoordinateByGridId()
        {
            IGridCoordinate gridCoordinate = dataService.GetGridCoordinateByGridId(2);
            Assert.AreEqual(5, gridCoordinate.MaxXCoordinate);
            Assert.AreEqual(5, gridCoordinate.MaxYCoordinate);
        }

        [TestMethod]
        public async Task Test_DataService_GetGridCoordinateByGridIdAsync()
        {
            IGridCoordinate gridCoordinate = await dataService.GetGridCoordinateByGridIdAsync(2);
            Assert.AreEqual(5, gridCoordinate.MaxXCoordinate);
            Assert.AreEqual(5, gridCoordinate.MaxYCoordinate);
        }

        [TestMethod]
        public void Test_DataService_SaveOffPosition()
        {
            IPositionFinal offPositionFinal1 = new PositionFinal { FinalXPosition = 5, FinalYPosition = 0, FinalOrientation = 'E', Lost = true };
            var result1=dataService.SaveOffPosition(2, offPositionFinal1);
            Assert.IsTrue(result1);

            IPositionFinal offPositionFinal2 = new PositionFinal { FinalXPosition = 0, FinalYPosition = 5, FinalOrientation = 'N', Lost = false };
            var result2 = dataService.SaveOffPosition(2, offPositionFinal2);
            Assert.IsFalse(result2);

        }

        [TestMethod]
        public void Test_DataService_IsOffPosition()
        {
            IPositionFinal offPositionFinal1 = new PositionFinal { FinalXPosition = 5, FinalYPosition = 0, FinalOrientation = 'E', Lost = true };
            var result1 = dataService.IsOffPosition(2, offPositionFinal1);
            Assert.IsTrue(result1);

            IPositionFinal offPositionFinal2 = new PositionFinal { FinalXPosition = 0, FinalYPosition = 5, FinalOrientation = 'N', Lost = false };
            var result2 = dataService.IsOffPosition(2, offPositionFinal2);
            Assert.IsFalse(result2);

        }
        
    }
}
