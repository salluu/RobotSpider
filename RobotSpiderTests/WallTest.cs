using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotSpider.Model;

namespace RobotSpiderTests
{
    [TestClass]
    public class WallTest
    {

        private Wall _wall;

        [TestInitialize]
        public void TestInitialize()
        {
            _wall = new Wall {Xaxis = 7, Yaxis = 15};

        }


        [TestMethod]
        public void Should_return_true_when_locaotion_0_0()
        {
            //Act
            var result = _wall.CheckRange(0, 0);


            //Assert            
            Assert.IsTrue(result, "Its inside the range");
        }

        [TestMethod]
        public void Should_return_true_when_locaotion_is_on_maximum_points()
        {
            //Act
            var result = _wall.CheckRange(7, 15);


            //Assert            
            Assert.IsTrue(result, "Its inside the range");
        }


        [TestMethod]
        public void Should_return_true_when_locaotion_is_somewhere_in_middle()
        {
            //Act
            var result = _wall.CheckRange(5, 3);


            //Assert            
            Assert.IsTrue(result, "Its inside the range");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Should_throw_argument_exception_when__locaotion_is_below_minimum_range()
        {
            //Act
            var result = _wall.CheckRange(-1, 3);

        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Should_throw_argument_exception_when__locaotion_is_above_maximum_range()
        {
            //Act
            var result = _wall.CheckRange(-1, 3);

        }
    }
}
