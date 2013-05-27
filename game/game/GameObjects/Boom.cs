using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatlleSpace.Helpers;

namespace BatlleSpace.GameObjects
{
    class Boom1 : GameObject
    {
        private float rotationSpeed;
        public Boom1(Vector2 position, float scale) :

            base(position, scale, LoadHelper.Textures[TextureEnum.Boom1])
        {
            rotationSpeed = MathHelper.ToRadians(RandomHelper.Next(4) + 1);
        }

        public override void Update()
        {
            position.Y += 5;
            Rotate(rotationSpeed);
        }
    }
    class Boom2 : GameObject
    {
        private float rotationSpeed;
        public Boom2(Vector2 position, float scale) :

            base(position, scale, LoadHelper.Textures[TextureEnum.Boom2])
        {
            rotationSpeed = MathHelper.ToRadians(RandomHelper.Next(4) + 1);
        }

        public override void Update()
        {
            position.Y += 5;
            Rotate(rotationSpeed);
        }
    }
}



    