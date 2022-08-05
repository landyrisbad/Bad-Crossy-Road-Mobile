using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Shit_Crossy_Road
{
    public class Road : Background {
        public Road(int x = 0, int y = -20, int width = 421, int height = 20) : base (x, y, width, height){
            color = Color.Black;

            direction = random.Next(100) < 50;
            speed = random.Next(3, 6);
            if (direction) {
                difficulty = random.Next(600, 750);
            } else {
                difficulty = random.Next(750, 900);
            }

            texture = new Rectangle(0, 100, 421, 20);

            Background.roads.Add(this);
        }
        public bool direction {get; set;}
        public int speed {get; set;}
        public int difficulty {get; set;}

        public List<Cars> cars = new List<Cars>();

        Random random = new Random();

        public bool AddCars () {
            bool addyes = false;
            if (cars.Count != 0) {
                foreach (Cars car in cars.ToList()) {
                    if (direction) {
                        if (car.position.X > difficulty) {
                            addyes = true;
                        } else {
                            addyes = false;
                            break;
                        }
                    } else {
                        if (car.position.X < difficulty) {
                            addyes = true;
                        } else {
                            addyes = false;
                            break;
                        }
                    }
                }
            } else {
                addyes = true;
            }
            return addyes;
        }

        public virtual void AllAddCars () {
            if (AddCars()) {
                new Cars(speed, direction, cars, this);
            }
        }

        public static void Addthings () {
            foreach (Road road in Background.roads) {
                road.AllAddCars();
            }
        }
    }
}