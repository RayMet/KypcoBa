using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatlleSpace.Helpers;
using BatlleSpace.GameObjects;


namespace BatlleSpace.GameObjects
{
    class Asteroid : GameObject
    {
        private float rotationSpeed;
        public Asteroid(Vector2 position, float scale) :
            
            base(position, scale, LoadHelper.Textures[TextureEnum.Asteroid])
        {
            rotationSpeed = MathHelper.ToRadians(RandomHelper.Next(4) + 1);
        }

        public override void Update()
        {
            position.Y += 5;
            Rotate(rotationSpeed);
        }

       // public bool OnScreen { get; set; }
    }
}
