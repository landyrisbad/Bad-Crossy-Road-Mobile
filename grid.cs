using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shit_Crossy_Road
{
    public class Grid {
        public Grid () {}

        public void Draw() {
            for (float x = -100; x < 100; x++)
            {
                Rectangle rectangle = new Rectangle((int)(0 + x * 20), 0, 1, Game1.self.GAMEWINDOWHEIGHT);
                Game1.self._spriteBatch.Draw(Game1.self._blankTexture, rectangle, Color.Red);
            }
            for (float y = -100; y < 100; y++)
            {
                Rectangle rectangle = new Rectangle(0, (int)(0 + y * 20), Game1.self.GAMEWINDOWWIDTH, 1);
                Game1.self._spriteBatch.Draw(Game1.self._blankTexture, rectangle, Color.Red);
            }
        }
    }
}