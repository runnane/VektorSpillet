using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VektorSpillet
{
    class Map
    {
        public static List<Vector2> vl = new List<Vector2>();
        public static List<Vector2> vl2 = new List<Vector2>();

        public static void Init()
        {
            vl.Add(new Vector2(15, 15));
            vl.Add(new Vector2(20, 150));
            vl.Add(new Vector2(30, 190));
            vl.Add(new Vector2(15, 280));
            vl.Add(new Vector2(45, 380));
            vl.Add(new Vector2(60, 420));
            vl.Add(new Vector2(120, 480));
            vl.Add(new Vector2(290, 500));
            vl.Add(new Vector2(500, 600));

            for (int i = 0; i < vl.Count; i++)
            {
                vl2.Add(vl[i] + new Vector2(50, -50));
            }

        }

        public static void DrawMap(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < vl.Count - 1; i++)
            {
                LineBatch.DrawLine(spriteBatch, Color.Black, vl[i], vl[i + 1]);
                LineBatch.DrawLine(spriteBatch, Color.Black, vl2[i], vl2[i + 1]);
            }
        }
    }
}
