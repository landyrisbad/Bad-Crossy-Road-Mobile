using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Shit_Crossy_Road
{
    public class Background {
        public Background (int x = 0, int y = -20, int width = 421, int height = 80) {
            position = new Vector2(x, y);
            texture = new Rectangle(x, y, width, height);

            backgrounds.Add(this);
        }

        public Vector2 position {get; set;}
        public Rectangle texture {get; set;}
        public Color color {get; set;}

        public static List<Background> backgrounds = new List<Background>();
        public static List<Road> roads = new List<Road>();

        static Random random = new Random();

        public static void Move(int speed) {
            foreach (Background background in backgrounds.ToList()) {
                background.position = new Vector2(background.position.X, background.position.Y + speed); 
                if (background.position.Y > Game1.self.GAMEWINDOWHEIGHT) {
                    backgrounds.Remove(background);
                }
            }

        }
        public static void Draw() {
            foreach (Background background in backgrounds.ToList()) {
                Game1.self._spriteBatch.Draw(Game1.self.spriteSheet, background.position, background.texture, background.color, 0f, new Vector2(0, 0), Game1.self.GLOBALMULTIPLIER, SpriteEffects.None, 0f);
                Game1.self._spriteBatch.Draw(Game1.self.spriteSheet, new Vector2(background.position.X + 842, background.position.Y), background.texture, background.color, 0f, new Vector2(0, 0), Game1.self.GLOBALMULTIPLIER, SpriteEffects.None, 0f);
            }
        }
        public static void StartGenerate() { 
            for (int i = 0; i < 6; ++i) {
                int toGenerate = random.Next(7);
                if (toGenerate == 1 || toGenerate == 3) {
                    new Scenery(i*Game1.self.GLOBALMULTIPLIER*20);
                } else if (toGenerate == 2) {
                    new River(0, i* Game1.self.GLOBALMULTIPLIER * 20);
                } else {
                    new Road(0, i* Game1.self.GLOBALMULTIPLIER * 20);
                }
            }
            new Scenery(480);
            new Scenery(560);
            new Scenery(Game1.self.player.yPos + Game1.self.GLOBALMULTIPLIER*20);
        }
        public static void InGameGenerate() {
            int toGenerate = random.Next(7);
            if (toGenerate == 1 || toGenerate == 3) {
                new Scenery(0);
            } else if (toGenerate == 2) {
                new River(0, 0);
            } else {
                new Road(0, 0);
            }
        }
    }
}