using System;

namespace RobotSpider.Model
{
    public class Wall : IWall
    {
        public int Xaxis;
        public int Yaxis;

        public bool CheckRange(int positionX, int positionY)
        {
            if (positionX < 0 || positionX > Xaxis) throw new ArgumentOutOfRangeException(nameof(positionX));
            if (positionY < 0 || positionY > Yaxis) throw new ArgumentOutOfRangeException(nameof(positionY));

            return true;
        }
    }
}