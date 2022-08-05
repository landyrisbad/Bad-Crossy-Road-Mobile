using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace Shit_Crossy_Road
{
    public class Cars {
        public Cars (int pSpeed, bool pDirection, List<Cars> pCollection, Road pParent) {
            parent = pParent;

            if (pDirection) {
                position = new Vector2(random.Next(-300, -220), pParent.position.Y);
                speed = pSpeed;
            } else {
                position = new Vector2(random.Next(Game1.self.GAMEWINDOWWIDTH, Game1.self.GAMEWINDOWWIDTH + 40), pParent.position.Y);
                speed = -pSpeed;
            }

            width = carLengths[random.Next(carLengths.Count())];

            if (width == 80) {
                    texture = textures[0,random.Next(3)];
                } else if (width == 60) {
                    texture = textures[1,random.Next(3)];
                } else if (width == 40) {
                    texture = textures[2,random.Next(3)];
            }

            pCollection.Add(this);
            carDrawList.Add(this);
            carCollisionList.Add(this);
        }
        
        public int speed {get; set;}
        public Vector2 position {get; set;}
        public Rectangle collisionBox {get; set;}
        Road parent {get; set;}
        public int width {get; set;}
        public Rectangle texture {get; set;}

        static int[] carLengths = new int[] {40, 60, 80};
        public static Rectangle[,] textures = new Rectangle[4,3] {
            {new Rectangle(0, 0, 80, 20), new Rectangle(81, 0, 80, 20), new Rectangle(161, 0, 80, 20)},
            {new Rectangle(0, 20, 60, 20), new Rectangle(81, 20, 60, 20), new Rectangle(161, 20, 60, 20)},
            {new Rectangle(0, 40, 40, 20), new Rectangle(81, 40, 40, 20), new Rectangle(161, 40, 40, 20)},
            {new Rectangle(300, 0, 40, 20), new Rectangle(300, 0, 60, 20), new Rectangle(300, 0, 80, 20)}
        };

        Random random = new Random();
        public static List<Cars> carDrawList = new List<Cars>();
        public static List<Cars> carCollisionList = new List<Cars>();

        public static void Update () {
            foreach (Cars car in carDrawList.ToList()) {
                car.position = new Vector2(car.position.X + car.speed, car.parent.position.Y);
                car.collisionBox = new Rectangle(Convert.ToInt32(car.position.X), Convert.ToInt32(car.position.Y), car.width*Game1.self.GLOBALMULTIPLIER, 20*Game1.self.GLOBALMULTIPLIER);

                if (car.position.Y > Game1.self.GAMEWINDOWHEIGHT) {
                    carDrawList.Remove(car);
                    carCollisionList.Remove(car);
                } 

                if (car.speed > 0) {
                    if (car.position.X > Game1.self.GAMEWINDOWWIDTH + 100) {
                        carDrawList.Remove(car);
                        carCollisionList.Remove(car);
                    }
                } else {
                    if (car.position.X < -300) {
                        carDrawList.Remove(car);
                        carCollisionList.Remove(car);
                    }
                } 
                if (car.position.Y < 0) {
                    carDrawList.Remove(car);
                    carCollisionList.Remove(car);
                }

            }
        }

        public static void Draw () {
            foreach (Cars car in carDrawList) {
                if (car.speed < 0) {
                    Game1.self._spriteBatch.Draw(Game1.self.spriteSheet, car.position, car.texture, Color.White, 0f, new Vector2(0, 0), Game1.self.GLOBALMULTIPLIER, SpriteEffects.None, 0f);
                } else {
                    Game1.self._spriteBatch.Draw(Game1.self.spriteSheet, car.position, car.texture, Color.White, 0f, new Vector2(0, 0), Game1.self.GLOBALMULTIPLIER, SpriteEffects.FlipHorizontally, 0f);
                }
            }
        }
    }
}