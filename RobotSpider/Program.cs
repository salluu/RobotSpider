using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using RobotSpider.Model;

namespace RobotSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            var wall = new Wall { Xaxis = 7, Yaxis = 15 };

            var spider = new Spider(wall)
            {
                CurrentDirection = Direction.Left,
                CurrentPosition = new Postion() {PostionX = 2, PositionY =4},
                
            };

            spider.MoveForward(Direction.Same);
            spider.MoveForward(Direction.Left);
            spider.MoveForward(Direction.Left);
            spider.MoveForward(Direction.Right);
            spider.MoveForward(Direction.Same);
            spider.MoveForward(Direction.Left);

            Console.WriteLine(string.Concat(spider.CurrentPosition.PostionX, " ",
                spider.CurrentPosition.PositionY, " ", spider.CurrentDirection));
        }
    }
}
