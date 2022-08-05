using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Graphics;

namespace Shit_Crossy_Road
{
    public class MainMenu {
        public MainMenu() {}

        static Rectangle playButton = new Rectangle(20, 550, 250, 100);

        public static bool autoRestart = false;

        static Player player = Game1.self.player;

        static TouchCollection touch = TouchPanel.GetState();

        public static void UseButtons() {
            touch = TouchPanel.GetState();

            if (touch.Count > 0) {
                if (touch[0].State == TouchLocationState.Moved || touch[0].State == TouchLocationState.Pressed)
                {
                    if (playButton.Contains(touch[0].Position))
                    {
                        player.xPos = Game1.self.GAMEWINDOWWIDTH/2;
                        player.yPos = 560;
                        player.gameState = Player.GameState.Gaming;
                        Background.StartGenerate();
                        player.score = 0;
                    }
                }
            }

        }

        public static void Draw () {
            
            //Game1.self._spriteBatch.Draw(Game1.self._blankTexture, playButton, Color.White);
            Game1.self._spriteBatch.DrawString(Game1.self._font, "Play", new Vector2(playButton.X, playButton.Y), Color.White);

            Game1.self._spriteBatch.DrawString(Game1.self._font, "Crossy Road \n But Worse", new Vector2(10, 20), Color.White);
            Game1.self._spriteBatch.DrawString(Game1.self._smallFont, "Your score was " + player.score, new Vector2(10, 300), Color.White);


        }

    }
}