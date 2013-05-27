using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BatlleSpace.Helpers
{
    static class LoadHelper
    {
        public static Dictionary<TextureEnum, Texture2D> Textures;
        public static Dictionary<FontEnum, SpriteFont> Fonts;
        public static void Load(ContentManager content)
        {
            Textures = new Dictionary<TextureEnum, Texture2D>();
             Fonts = new Dictionary<FontEnum, SpriteFont>();



            Textures.Add(TextureEnum.Star, content.Load<Texture2D>(@"Textures\Star"));
            Textures.Add(TextureEnum.Asteroid, content.Load<Texture2D>(@"Textures\Asteroid"));
            Textures.Add(TextureEnum.Ship, content.Load<Texture2D>(@"Textures\Ship"));
            Textures.Add(TextureEnum.shoot, content.Load<Texture2D>(@"Textures\shoot"));
            Textures.Add(TextureEnum.Logo, content.Load<Texture2D>(@"Textures\photo"));

            Textures.Add(TextureEnum.Boom1 , content.Load<Texture2D>(@"Textures\Boom1"));
            Textures.Add(TextureEnum.Boom2, content.Load<Texture2D>(@"Textures\Boom2"));
            Textures.Add(TextureEnum.Boom3, content.Load<Texture2D>(@"Textures\Boom3"));
            Textures.Add(TextureEnum.Boom4, content.Load<Texture2D>(@"Textures\Boom4"));
            Textures.Add(TextureEnum.Boom5, content.Load<Texture2D>(@"Textures\Boom5"));
            Textures.Add(TextureEnum.Boom6, content.Load<Texture2D>(@"Textures\Boom6"));
            Textures.Add(TextureEnum.Boom7, content.Load<Texture2D>(@"Textures\Boom7"));
            Textures.Add(TextureEnum.Boom8, content.Load<Texture2D>(@"Textures\Boom8"));

            #region load fonts
            Fonts.Add(FontEnum.Arial22, content.Load<SpriteFont>(@"Fonts\Arial22"));
            Fonts.Add(FontEnum.Arial42, content.Load<SpriteFont>(@"Fonts\Arial42"));
            #endregion 
        }
    }

    public enum TextureEnum
    {
        Star,
        Asteroid,
        shoot,
        Ship,
        Boom1,
        Boom2,
        Boom3,
        Boom4,
        Boom5,
        Boom6,
        Boom7,
        Boom8,
        Logo
    }

    public enum FontEnum
    {
        Arial22,
        Arial42
    }
}