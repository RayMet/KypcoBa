using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatlleSpace.Helpers;
using BatlleSpace.GameObjects;

namespace BatlleSpace.GameObjects
{
    class GameManager
    {
        private Ship ship;

        private List<Star> stars;
        private List<Asteroid> asteroids;
        private List<shoot> bullets;
        private List<Boom1> booms;

        private DateTime lastShootTime = DateTime.MinValue;
        private int playerScore;

        public GameManager()
        {
            ship = new Ship(new Vector2(BatlleSpace.Width / 2, BatlleSpace.Height - 85), 0.5f);

            stars = new List<Star>();
            asteroids = new List<Asteroid>();
            bullets = new List<shoot>();
            booms = new List<Boom1>();
        }

        public void Update()
        {
            UpdateStars();

            UpdateAsteroids();

            UpdateBullets();

            ship.Update();
         


        }

        public void ShipShoot()
        {
            if ((DateTime.Now - lastShootTime).Milliseconds > (250 - playerScore/10))
            {
                bullets.Add(new shoot(ship.Position, 0.5f, ShooterEnum.Player));
                lastShootTime = DateTime.Now;
            }
        }
        public void MoveShip(int dx, int dy)
        {
            ship.Move(dx, dy);
        }

       

        private void UpdateStars()
        {
            foreach (Star star in stars)
            {
                star.Update();
            }

            int i = 0;
            while (i < stars.Count)
            {
                if (!stars[i].OnScreen)
                    stars.RemoveAt(i);
                else i++;
            }

            // add some new stars
            for (int j = 0; j < RandomHelper.Next(5); j++)
            {
                stars.Add(new Star(new Vector2(RandomHelper.Next(BatlleSpace.Width), 0), 1 / (float)RandomHelper.Next(5, 11)));
            }
        }

        private void UpdateAsteroids()
        {
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Update();
                #region collision
                if (asteroid.Rectangle.Intersects(ship.Rectangle))
                {
                    DestroyPlayerShip();
                    asteroid.Alive = false;

          
                }
                #endregion
            }

            int i = 0;
            while (i < asteroids.Count)
            {
                if (!asteroids[i].OnScreen || !asteroids[i].Alive)
                    asteroids.RemoveAt(i);
                else i++;
                
            }

            int j = 0;
            while (j < booms.Count)
            {
                if (!booms[j].OnScreen || !booms[j].Alive)
                    booms.RemoveAt(j);
                else j++;

            }
           
            int d = 3 + playerScore/100;
            Random rnd=new Random();
            float t=rnd.Next(30);
            if (RandomHelper.Next(100) < d)
                asteroids.Add(new Asteroid(new Vector2(RandomHelper.Next(BatlleSpace.Width), -50), t/35));
            if (RandomHelper.Next(100) < 3)
            booms.Add(new Boom1(new Vector2(RandomHelper.Next(BatlleSpace.Width), -40), 0.6f));
            }


         private void DestroyPlayerShip()
        {
            ship.Place(BatlleSpace.Width / 2, BatlleSpace.Height - 85);
            playerScore = 0;
        }
        

  

        private void UpdateBullets()
        {
            foreach (shoot bullet in bullets)
            {
                bullet.Update();
                foreach (Asteroid asteroid in asteroids)
                {
                    if (bullet.Owner == ShooterEnum.Player && asteroid.Rectangle.Intersects(bullet.Rectangle))
                    {
                        asteroid.Alive = false;
                        bullet.Alive = false;
                        playerScore += 10;
                    }
                }
              
                 
               
                if (bullet.Owner == ShooterEnum.Computer && bullet.Rectangle.Intersects(ship.Rectangle))
                {
                    DestroyPlayerShip();
                    bullet.Alive = false;
                   
                }
            }
            int i = 0;
            while (i < bullets.Count)
            {
                if (!bullets[i].OnScreen || !bullets[i].Alive)
                    bullets.RemoveAt(i);
                else i++;
            }
        }

        #region draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Texture,BlendState.AlphaBlend);

           

            #region stars
            foreach (Star star in stars)
            {
                star.Draw(spriteBatch);
            }
            #endregion

            #region asteroids
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Draw(spriteBatch);
            }
            foreach (Boom1 boom1 in booms)
            {
                boom1.Draw(spriteBatch);
            }
            #endregion

            #region bullets
            foreach (shoot shoot in bullets)
            {
                shoot.Draw(spriteBatch);
            }
            #endregion

            ship.Draw(spriteBatch);

            #region score
            spriteBatch.DrawString(LoadHelper.Fonts[FontEnum.Arial22],
                                    "Score:" + playerScore.ToString(),
                                   new Vector2(0, 0), Color.White);
            #endregion
          
            spriteBatch.End();


        }
        #endregion
    }
}
