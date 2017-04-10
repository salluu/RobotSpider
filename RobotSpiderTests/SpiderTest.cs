using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RobotSpider.Model;

namespace RobotSpiderTests
{
    [TestClass]
    public class SpiderTest
    {

        private Spider _spider;
        private IWall _wall;

        [TestInitialize]
        public void TestInitialize()
        {
            _wall = Substitute.For<IWall>();
           
            _wall.CheckRange(0,0).ReturnsForAnyArgs(true);

        }


        [TestMethod]
        public void Should_rotate_to_90_angle_from_left_to_left()
        {
            //Arrange
            _spider = new Spider(_wall)
            {
                CurrentDirection = Direction.Left,
                CurrentPosition = new Postion() { PostionX = 0, PositionY = 0 },
            };

            //Act
            _spider.Rotate(Direction.Left);           

            //Assert            
            Assert.AreEqual(_spider.CurrentDirection, Direction.Down);

        }


        [TestMethod]
        public void Should_rotate_to_90_angle_from_right_to_right()
        {
            //Arrange
            _spider = new Spider(_wall)
            {
                CurrentDirection = Direction.Right,
                CurrentPosition = new Postion() { PostionX = 0, PositionY = 0 },
            };

            //Act
            _spider.Rotate(Direction.Right);

            //Assert            
            Assert.AreEqual(_spider.CurrentDirection, Direction.Down);

        }

        [TestMethod]
        public void Should_rotate_to_90_angle_from_right_to_left()
        {
            //Arrange
            _spider = new Spider(_wall)
            {
                CurrentDirection = Direction.Right,
                CurrentPosition = new Postion() { PostionX = 0, PositionY = 0 },
            };

            //Act
            _spider.Rotate(Direction.Left);

            //Assert            
            Assert.AreEqual(_spider.CurrentDirection, Direction.Up);

        }

        [TestMethod]
        public void Should_rotate_to_90_angle_from_left_to_right()
        {
            //Arrange
            _spider = new Spider(_wall)
            {
                CurrentDirection = Direction.Left,
                CurrentPosition = new Postion() { PostionX = 0, PositionY = 0 },
            };

            //Act
            _spider.Rotate(Direction.Right);

            //Assert            
            Assert.AreEqual(_spider.CurrentDirection, Direction.Up);

        }

        [TestMethod]
        public void Should_validate_F_to_Same_direction()
        {
            //Arrange
            _spider = new Spider(_wall)
            {
                CurrentDirection = Direction.Right,
                CurrentPosition = new Postion() { PostionX = 0, PositionY = 0 },
            };

            //Act
            _spider.MoveForward(Direction.Same);
            
            //Assert            
            Assert.AreEqual(_spider.CurrentPosition.PostionX, 1);
            Assert.AreEqual(_spider.CurrentPosition.PositionY, 0);

        }

        [TestMethod]
        public void Should_validate_FLF_direction()
        {
            //Arrange
            _spider = new Spider(_wall)
            {
                CurrentDirection = Direction.Right,
                CurrentPosition = new Postion() { PostionX = 0, PositionY = 0 },
            };

            //Act
            _spider.MoveForward(Direction.Same);
            _spider.MoveForward(Direction.Left);

            //Assert            
            Assert.AreEqual(_spider.CurrentPosition.PostionX, 1);
            Assert.AreEqual(_spider.CurrentPosition.PositionY, 1);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_throw_argument_exception_when_spider_is_going_out_of_range()
        {
            //Arrange
            _wall.CheckRange(8, 4).Returns(x => { throw new ArgumentOutOfRangeException(); });
            _spider = new Spider(_wall)
            {
                CurrentDirection = Direction.Right,
                CurrentPosition = new Postion() { PostionX = 6, PositionY = 4 },
            };

            //Act
            _spider.MoveForward(Direction.Same);
            _spider.MoveForward(Direction.Same);
        

        }

        [TestMethod]
        public void Should_validate_FLFLFRFFLF_direction()
        {
            //Arrange
            _spider = new Spider(_wall)
            {
                CurrentDirection = Direction.Left,
                CurrentPosition = new Postion() { PostionX = 2, PositionY = 4 },
            };

            //Act
            _spider.MoveForward(Direction.Same);
            _spider.MoveForward(Direction.Left);
            _spider.MoveForward(Direction.Left);
            _spider.MoveForward(Direction.Right);
            _spider.MoveForward(Direction.Same);
            _spider.MoveForward(Direction.Left);

            //Assert            
            Assert.AreEqual(_spider.CurrentPosition.PostionX, 3);
            Assert.AreEqual(_spider.CurrentPosition.PositionY, 1);
            Assert.AreEqual(_spider.CurrentDirection, Direction.Right);

        }



    }
}
