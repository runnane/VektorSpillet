using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VektorSpillet
{
    class PlayerObject
    {

        public Vector2 angle;
        public Vector2 location;
        public Vector2 chooser;
        private Color color;

        public Vector2 Destination
        {
            get
            {
                var v = new Vector2();
                v.X = location.X + angle.X;
                v.Y = location.Y + angle.Y;
                return v;
            }
        }

        public override string ToString()
        {
            return "Loc: " + location + ", Angle: " + angle + " Chooser: " + chooser;
        }
        public PlayerObject(ContentManager cm, Color clr, Vector2 startpos)
        {
            location = startpos;
            angle = new Vector2(0,0);
            color = clr;
            chooser = new Vector2(0,15);
        }

        public void ChangeChooser(bool way)
        {
          //  if ((DateTime.Now - lastchange).TotalMilliseconds < 500)
          //      return;
            if (way)
            {
                if ((int)chooser.X == 0 && (int)chooser.Y == 15) //0,15
                    chooser.X = 15;
                else if ((int)chooser.X == 15 && (int)chooser.Y == 15) //15,15
                    chooser.Y = 0;
                else if ((int)chooser.X == 15 && (int)chooser.Y == 0) // 15,0
                    chooser.Y = -15;
                else if ((int)chooser.X == 15 && (int)chooser.Y == -15) // 15,-15
                    chooser.X = 0;
                else if ((int)chooser.X == 0 && (int)chooser.Y == -15) //0,-15
                    chooser.X = -15;
                else if ((int)chooser.X == -15 && (int)chooser.Y == -15) //-15,-15
                    chooser.Y = 0;
                else if ((int)chooser.X == -15 && (int)chooser.Y == 0) // -15, 0
                    chooser.Y = 15;
                else if ((int)chooser.X == -15 && (int)chooser.Y == 15) //-15, 15
                    chooser.X = 0;
            }else
            {
                if ((int)chooser.X == 0 && (int)chooser.Y == 15) //0,15
                    chooser.X = -15;
                else if ((int)chooser.X == -15 && (int)chooser.Y == 15) //-15, 15
                    chooser.Y = 0;
                else if ((int)chooser.X == -15 && (int)chooser.Y == 0) // -15, 0
                    chooser.Y = -15;
                else if ((int)chooser.X == -15 && (int)chooser.Y == -15) //-15,-15
                    chooser.X = 0;
                else if ((int)chooser.X == 0 && (int)chooser.Y == -15) //0,-15
                    chooser.X = 15;
                else if ((int)chooser.X == 15 && (int)chooser.Y == -15) // 15,-15
                    chooser.Y = 0;
                else if ((int)chooser.X == 15 && (int)chooser.Y == 0) // 15,0
                    chooser.Y = 15;
                else if ((int)chooser.X == 15 && (int)chooser.Y == 15) //15,15
                    chooser.X = 0;
            }

          
        }

        public void Draw(SpriteBatch spriteBatch,bool myturn)
        {
            LineBatch.DrawLine(spriteBatch, color, location, Destination);
            if(myturn)
                  DrawChooser(spriteBatch);
          //  _p1.DrawChooser(_spriteBatch);

        }

        public void DrawChooser(SpriteBatch spriteBatch)
        {
            LineBatch.DrawLine(spriteBatch, Color.Yellow, Destination, Destination + chooser);
        }

        public void Choose()
        {
            location = location + angle;
            angle = angle + chooser;
        }




    }
}
