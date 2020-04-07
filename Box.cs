using System;
using System.Collections.Generic;
using System.Text;

namespace ChapIce
{
    struct Box
    {
        public float bottom;
        public float top;
        public float left;
        public float right;

        private bool checkPointInside(in Box other)
        {
            bool leftBetween = left.IsBetween(other.left, other.right);
            bool rightBetween = right.IsBetween(other.left, other.right);
            bool upBetween = top.IsBetween(other.top, other.bottom);
            bool downBetween = bottom.IsBetween(other.top, other.bottom);

            if ((leftBetween || rightBetween) && (upBetween || downBetween))
            {
                return true;
            }

            return false;
        }

        private bool checkCrossIntersection(in Box other)
        {
            //TODO: write crooss-intersection method

            return false;
        }

        public bool IsIntersectWith(in Box other)
        {
            // 1 - one of points is inside other
            if (checkPointInside(in other))
                return true;

            // 2 - some other point is inside us
            if (other.checkPointInside(in this))
                return true;

            // 3 - Cross-intersection
            if (checkCrossIntersection(in other))
                return true;

            return false;
        }
    }
}
