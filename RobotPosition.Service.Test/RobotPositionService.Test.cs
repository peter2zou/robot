using RobotPosition.Entity;
using RobotPosition.DataAccess;
using RobotPosition.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotPosition.Service.Test
{
    [TestClass]
    public class RobotPositionService_UnitTest
    {
        [TestMethod]
        public void Test_RobotPositionService_GetGridIdentifer()
        {
            IDataService dataService = new DataService();
            IRobotPositionService service = new RobotPositionService(dataService);
            IGridCoordinate gridCoordinate = new GridCoordinate { MaxXCoordinate = 5, MaxYCoordinate = 3 };
            IGridIdentifer gridIdentifer = service.GetGridIdentifer(gridCoordinate);
            Assert.AreEqual(1,gridIdentifer.GridID);
        }

        [TestMethod]
        public void Test_RobotPositionService_GetFinalPostion()
        {

            IDataService dataService = new DataService();
            IRobotPositionService service = new RobotPositionService(dataService);
            IPositionStarting positionStarting1 = new PositionStarting
            {
                  StartingXPosition=1,
                  StartingYPosition=1,
                  Orientation='E',
                  Instructions="RFRFRFRF"
            };
            IPositionFinal positionFinal1=service.GetFinalPostion(1, positionStarting1);
            Assert.AreEqual(1, positionFinal1.FinalXPosition);
            Assert.AreEqual(1, positionFinal1.FinalYPosition);
            Assert.AreEqual('E', positionFinal1.FinalOrientation);
            Assert.AreEqual(false, positionFinal1.Lost);
            
            IPositionStarting positionStarting2 = new PositionStarting
            {
                StartingXPosition = 3,
                StartingYPosition = 2,
                Orientation = 'N',
                Instructions = "FRRFLLFFRRFLL"
            };
            IPositionFinal positionFinal2 = service.GetFinalPostion(1, positionStarting2);
            Assert.AreEqual(3, positionFinal2.FinalXPosition);
            Assert.AreEqual(3, positionFinal2.FinalYPosition);
            Assert.AreEqual('N', positionFinal2.FinalOrientation);
            Assert.AreEqual(true, positionFinal2.Lost);
            
            IPositionStarting positionStarting3 = new PositionStarting
            {
                StartingXPosition = 0,
                StartingYPosition = 3,
                Orientation = 'W',
                Instructions = "LLFFFLFLFL"
            };
            IPositionFinal positionFinal3 = service.GetFinalPostion(1, positionStarting3);
            Assert.AreEqual(2, positionFinal3.FinalXPosition);
            Assert.AreEqual(3, positionFinal3.FinalYPosition);
            Assert.AreEqual('S', positionFinal3.FinalOrientation);
            Assert.AreEqual(false, positionFinal3.Lost);
        }


    }
}
