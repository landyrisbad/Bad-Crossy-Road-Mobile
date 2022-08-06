using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;
using System.IO;

namespace Shit_Crossy_Road
{
    public class Player {
        public Player (int x, int y) {
            xPos = x;
            yPos = y;
        }

        public Vector2 position;
        public Rectangle collisionBox;
        Rectangle texture = new Rectangle(256, 0, 20, 20);
        public int score = 0;

        public int yPos {get; set;}
        public int xPos {get; set;}
        
        public void Update () {
            Move();
            Interact();
            CheckRiverDeath();

            position = new Vector2(xPos, yPos);
            collisionBox = new Rectangle(Convert.ToInt32(position.X) + 4 * Game1.self.GLOBALMULTIPLIER, Convert.ToInt32(position.Y) + 3 * Game1.self.GLOBALMULTIPLIER, 12 * Game1.self.GLOBALMULTIPLIER, 13 * Game1.self.GLOBALMULTIPLIER);
        }

        public Rectangle goLeft = new Rectangle(0, Game1.self.GAMEWINDOWHEIGHT - 200, 200, 200);
        public Rectangle goRight = new Rectangle(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 200, Game1.self.GAMEWINDOWHEIGHT - 200, 200, 200);
        public Rectangle goBack = new Rectangle(400, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 150, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 800, 150);

        TouchCollection touch = TouchPanel.GetState();
        TouchCollection pastTouch = TouchPanel.GetState();

        public string DeathMessage;

        int move = Game1.self.GLOBALMULTIPLIER * 20;

        string[] CarDeaths = new string[5] { 
            "You were hit by a car",
            "You didn't cross the road fast enough",
            "A car didn't stop in time",
            "You got squashed",
            "You are no longer a complete chicken"
        };
        string[] WaterDeaths = new string[3] {
            "Chickens cant swim!",
            "You are meant to step on a log not off it",
            "You fell in a river"
        };
        string[] EdgeDeaths = new string[2] {
            "Turns out the earth is flat, \nand you just fell off it",
            "You went to Narnia"
        };

        public enum GameState {
            Gaming,
            menuNewHi,
            Menu,
        }

        public GameState gameState = GameState.Menu;

        void Move() {
            touch = TouchPanel.GetState();

            if (touch.Count == 0 && pastTouch.Count > 0 )
            {
                    if (goBack.Contains(pastTouch[0].Position))
                    {
                        
                        if (score != 0)
                        {
                            Background.Move(-move);
                            xPos = (xPos / move) * move;
                            score--;
                        }
                    }
                    else if (goLeft.Contains(pastTouch[0].Position))
                    {
                        if (position.X != 20)
                        {
                            xPos -= move;
                        }
                    }
                    else if (goRight.Contains(pastTouch[0].Position))
                    {
                        if (position.X != 380)
                        {
                            xPos += move;
                        }
                    } else
                    {
                        Background.Move(move);
                        if (gameState == GameState.Gaming)
                        {
                            Background.InGameGenerate();
                        }
                        xPos = (xPos / move) * move;
                        score++;
                    }
                    
            }

            pastTouch = touch;
        }

        void Interact () {
            //River.IsInRiver();
            
            foreach (Cars car in Cars.carCollisionList) {
                if (collisionBox.Intersects(car.collisionBox)) {
                    Reset("car");
                    break;
                }
            }

            bool die = false;
            foreach (Log log in Log.logCollisionList) {
                if (collisionBox.Intersects(log.collisionBox)) {
                    die = false;
                    xPos += log.speed;
                    break;
                } 
                die = false;
            }
            if (die) {
                Reset("log");
            }
            if (position.X > Game1.self.GAMEWINDOWWIDTH) {
                Reset("edge");
            } else if (position.X < 0) {
                Reset("edge");
            }

        }

        void CheckRiverDeath() {
            bool dead = false;
            foreach (River river in River.riverList) {
                if (position.Y == river.position.Y) {
                    foreach (Log log in river.cars) {
                        if (position.X > log.position.X && position.X + collisionBox.Width < log.position.X + log.collisionBox.Width) {
                            dead = false;
                            break;
                        } else {
                            dead = true;
                        }
                    } if (dead) {
                        Reset("log");
                        break;
                    }
                }
            }
        }

        public void Draw () {
            //Game1.self._spriteBatch.Draw(Game1.self._blankTexture, collisionBox, Color.Orange);
            // Game1.self._spriteBatch.Draw(Game1.self._blankTexture, goBack, Color.Green);
            //Game1.self._spriteBatch.Draw(Game1.self._blankTexture, goRight, Color.Red);
            //Game1.self._spriteBatch.Draw(Game1.self._blankTexture, goLeft , Color.Red);
            Game1.self._spriteBatch.Draw(Game1.self._arrow, new Vector2(goRight.X, goRight.Y), new Rectangle(0, 0, 400, 400), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0.1f);
            Game1.self._spriteBatch.Draw(Game1.self._arrow, new Vector2(goLeft.X, goLeft.Y), new Rectangle(0, 0, 400, 400), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.FlipHorizontally, 0.1f); 
            Game1.self._spriteBatch.Draw(Game1.self.spriteSheet, position, texture, Color.White, 0f, new Vector2(0, 0), Game1.self.GLOBALMULTIPLIER, SpriteEffects.None, 0f);
            if (gameState == GameState.Gaming) {
                Game1.self._spriteBatch.DrawString(Game1.self._font, Convert.ToString(score), new Vector2(20, 100), Color.White);
            }
        }

        public void Reset(string deathType, bool checkMenu = true) {

            var random = new Random();
            if (deathType == "car")
            {
                DeathMessage = CarDeaths[random.Next(0, CarDeaths.Length)];
            }
            if (deathType == "log")
            {
                DeathMessage = WaterDeaths[random.Next(0, WaterDeaths.Length)];
            }
            if (deathType == "edge")
            {
                DeathMessage = EdgeDeaths[random.Next(0, EdgeDeaths.Length)];
            }

            xPos = 200;
            yPos = 560;
            
            Background.backgrounds.Clear();
            Background.roads.Clear();

            River.riverList.Clear();

            Cars.carCollisionList.Clear();
            Cars.carDrawList.Clear();
            Log.logCollisionList.Clear();

            foreach(Road road in Background.roads) {
                road.cars.Clear();
            }

            if(checkMenu) {
                if (!MainMenu.autoRestart) {
                    gameState = GameState.Menu;
                }
            } else {
                gameState = GameState.Menu;
            }

            Background.StartGenerate();
        }

    }
}