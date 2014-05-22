using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace VektorSpillet
{
    static class VectorHelper
    {
        public static bool Intersects(Vector2 v1, Vector2 v2, Vector2 w1, Vector2 w2)
        {
            float n = (v1.Y - w1.Y) * (w2.X - w1.X) - (v1.X - w1.X) * (w2.Y - w1.Y);
            float d = (v2.X - v1.X) * (w2.Y - w1.Y) - (v2.Y - v1.Y) * (w2.X - w1.X);

            if (Math.Abs(d) < 0.0001)
                //Lines are parallel...
                return false;
            else
            {
                //Lines might cross...
                float sn = (v1.Y - w1.Y) * (v2.X - v1.X) - (v1.X - w1.X) * (v2.Y - v1.Y);

                float AB = n / d;
                if (AB > 0f && AB < 1f)
                {
                    float CD = sn / d;
                    if (CD > 0f && CD < 1f)
                    {
                        //Lines intersect...
                        return true;
                    }
                }

                //Lines didn't cross, because the intersection was beyond the end points of the lines...
            }

            //Lines do Not cross...
            return false;
        }
    }
}
