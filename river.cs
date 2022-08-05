using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Shit_Crossy_Road
{
    public class River : Road {
        public River (int x, int y) : base(x, y) {
            color = Color.White;

            speed = random.Next(2,4);
            if (direction) {
                difficulty = random.Next(300, 450);
            } else {
                difficulty = random.Next(700, 900);
            }   

            texture = new Rectangle(0, 80, 421, 20);

            riverList.Add(this);
        }
         
        Random random = new Random();
        public static List<River> riverList = new List<River>();

        public override void AllAddCars() {
            if (AddCars()) {
                new Log(speed, direction, cars, this);
            }

        }

        /*public static void IsInRiver() {
            foreach (River river in riverList) {
                if (Game1.self.player.collisionBox.Y == river.position.Y) {
                    Game1.self.player.CheckRiverDeath();
                }
            }
        }*/
    }
}