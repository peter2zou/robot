using System;
using System.Net.Http;
using RobotPosition.Entity;
using Newtonsoft.Json;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace RobotPosition.WebAPI.Test
{
    [TestClass]
    public class RobotPosition_WebAPI_UnitTest
    {
        private static Uri baseUri = new Uri("http://localhost:64659");
        [TestMethod]
        public void Test_RobotPositionWebAPI_EndPoint1_Grid()
        {
            IGridCoordinate gridCoordinate=new GridCoordinate { MaxXCoordinate = 5, MaxYCoordinate = 3 };
            string endPointURI = (new Uri(baseUri, "grid")).ToString();
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(endPointURI, GetStringContent(gridCoordinate)).Result;
                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    IGridIdentifer gridId = JsonConvert.DeserializeObject<GridIdentifer>(response.Content.ReadAsStringAsync().Result);
                    Assert.AreEqual(1,gridId.GridID);
                }
            }
        }

        [TestMethod]
        public void Test_RobotPositionWebAPI_EndPoint2_Grid_Id_Rover()
        {
            IGridCoordinate gridCoordinate = new GridCoordinate { MaxXCoordinate = 5, MaxYCoordinate = 3 };
            IPositionStarting positionStarting1 = new PositionStarting
            {
                StartingXPosition = 1,
                StartingYPosition = 1,
                Orientation = 'E',
                Instructions = "RFRFRFRF"
            };
            IPositionStarting positionStarting2 = new PositionStarting
            {
                StartingXPosition = 3,
                StartingYPosition = 2,
                Orientation = 'N',
                Instructions = "FRRFLLFFRRFLL"
            };
            IPositionStarting positionStarting3 = new PositionStarting
            {
                StartingXPosition = 0,
                StartingYPosition = 3,
                Orientation = 'W',
                Instructions = "LLFFFLFLFL"
            };
            string endPointURI = (new Uri(baseUri, "grid/1/rover")).ToString();
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(endPointURI, GetStringContent(positionStarting1)).Result;
                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    IPositionFinal positionFinal = JsonConvert.DeserializeObject<PositionFinal>(response.Content.ReadAsStringAsync().Result);
                    Assert.AreEqual(1, positionFinal.FinalXPosition);
                    Assert.AreEqual(1, positionFinal.FinalYPosition);
                    Assert.AreEqual('E', positionFinal.FinalOrientation);
                    Assert.AreEqual(false, positionFinal.Lost);
                }
                response = client.PostAsync(endPointURI, GetStringContent(positionStarting2)).Result;
                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    IPositionFinal positionFinal = JsonConvert.DeserializeObject<PositionFinal>(response.Content.ReadAsStringAsync().Result);
                    Assert.AreEqual(3, positionFinal.FinalXPosition);
                    Assert.AreEqual(3, positionFinal.FinalYPosition);
                    Assert.AreEqual('N', positionFinal.FinalOrientation);
                    Assert.AreEqual(true, positionFinal.Lost);
                }
                response = client.PostAsync(endPointURI, GetStringContent(positionStarting3)).Result;
                Assert.IsTrue(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    IPositionFinal positionFinal = JsonConvert.DeserializeObject<PositionFinal>(response.Content.ReadAsStringAsync().Result);
                    Assert.AreEqual(2, positionFinal.FinalXPosition);
                    Assert.AreEqual(3, positionFinal.FinalYPosition);
                    Assert.AreEqual('S', positionFinal.FinalOrientation);
                    Assert.AreEqual(false, positionFinal.Lost);
                }
            }
        }

        private HttpContent GetStringContent(Object myobject)
        {
            string postjson = JsonConvert.SerializeObject(myobject);
            return new StringContent(postjson, UnicodeEncoding.UTF8, "application/json");
        }
    }
}
