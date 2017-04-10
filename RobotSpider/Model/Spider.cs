using System.Runtime.InteropServices;

namespace RobotSpider.Model
{
    public class Spider 
    {

        public Direction CurrentDirection { get; set; }
        public Postion CurrentPosition { get; set; }
        private readonly IWall _wall;

        public Spider(IWall wall)
        {
            _wall = wall;
        }
        public void MoveForward(Direction direction)
        {
           
            Rotate(direction);
            switch (CurrentDirection)
            {
                case Direction.Up:
                    MoveSpider(0, 1);
                    break;

                case Direction.Right:
                    MoveSpider(1, 0);
                    break;

                case Direction.Down:
                    MoveSpider(0, -1);
                    break;

                case Direction.Left:
                    MoveSpider(-1, 0);
                    break;
            }
        }
        
        public void Rotate(Direction direction)
        {
            if (direction == Direction.Left)
            {
                switch (CurrentDirection)
                {
                    case Direction.Left:
                        CurrentDirection = Direction.Down;
                        break;
                    case Direction.Down:
                        CurrentDirection = Direction.Right;
                        break;
                    case Direction.Right:
                        CurrentDirection = Direction.Up;
                        break;
                    case Direction.Up:
                        CurrentDirection = Direction.Left;
                        break;
                }
            }

            if (direction == Direction.Right)
            {
                switch (CurrentDirection)
                {
                    case Direction.Left:
                        CurrentDirection = Direction.Up;
                        break;
                    case Direction.Down:
                        CurrentDirection = Direction.Left;
                        break;
                    case Direction.Right:
                        CurrentDirection = Direction.Down;
                        break;
                    case Direction.Up:
                        CurrentDirection = Direction.Right;
                        break;
                }
            }
        }

        public void MoveSpider(int x, int y)
        {
            var positionX = CurrentPosition.PostionX + x;
            var positionY = CurrentPosition.PositionY + y;

            if (_wall.CheckRange(positionX,positionY))
            {
                CurrentPosition.PostionX  = positionX;
                CurrentPosition.PositionY = positionY;
            }

        }

        
    }

}