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
    class shoot : GameObject
    {
        private ShooterEnum owner;

        public ShooterEnum Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public shoot(Vector2 position, float scale, ShooterEnum owner)
            : base(position, scale, LoadHelper.Textures[TextureEnum.shoot])
        {
            this.owner = owner;
            height *= 3;
        }
        public override void Update()
        {
            if (owner == ShooterEnum.Player)
                position.Y -= 20;
            else
                position.Y += 20;


            base.Update();
        }

    // public bool OnScreen { get; set; }
    }
    public enum ShooterEnum
    {
        Player,
        Computer
    }
}