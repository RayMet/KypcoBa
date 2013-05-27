using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatlleSpace.Helpers;

namespace BatlleSpace.GameObjects
{
    class Ship : GameObject
    {

        public Ship(Vector2 position, float scale)
            : base(position, scale, LoadHelper.Textures[TextureEnum.Ship])
        {
        }


        public void Move(int dx, int dy)
        {
            if (position.X + dx > 0 && position.X + dx + width < BatlleSpace.Width)
                position.X += dx;

            if (position.Y + dy > 0 && position.Y + dy + height < BatlleSpace.Height)
                position.Y += dy;
        }

        public void Place(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

    }
}