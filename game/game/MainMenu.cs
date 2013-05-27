using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatlleSpace.Helpers;
using BatlleSpace.GameObjects;
using Microsoft.Xna.Framework.Input;


namespace BatlleSpace
{
    class MainMenu
    {
        private int selected = 0;
        private bool arrowPressed = true;
        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (!arrowPressed)
            {
                if (keyboard.IsKeyDown((Keys.Up)))
                    selected = selected == 0 ? 1 : 0;
                if (keyboard.IsKeyDown((Keys.Down)))
                    selected = selected == 0 ? 1 : 0;
            }
            if (keyboard.IsKeyDown((Keys.Enter)))
            {
                BatlleSpace.State = selected == 0 ? GameState.Game : GameState.Exit;
               // if (BatlleSpace.State == GameState.Game)
                 //   AudioManager.StartMainTheme();

            }

            if (keyboard.IsKeyUp((Keys.Up)) && keyboard.IsKeyUp((Keys.Down)))
                arrowPressed = false;
            else arrowPressed = true;


        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);
            spritebatch.Draw(LoadHelper.Textures[TextureEnum.Logo], new Rectangle(0, 0, BatlleSpace.Width, BatlleSpace.Height), Color.White);
            spritebatch.End();
            spritebatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);
            spritebatch.DrawString(LoadHelper.Fonts[FontEnum.Arial42],
                        "Batlle Space",
                       new Vector2(150, 300), Color.White);


            spritebatch.DrawString(LoadHelper.Fonts[FontEnum.Arial22],
            "Play game",
           new Vector2(200, 460), selected == 0 ? Color.Violet : Color.DarkViolet);
            spritebatch.DrawString(LoadHelper.Fonts[FontEnum.Arial22],
            "Exit",
           new Vector2(200, 500), selected == 1 ? Color.Violet : Color.DarkViolet);


            spritebatch.End();
        }
    }
}