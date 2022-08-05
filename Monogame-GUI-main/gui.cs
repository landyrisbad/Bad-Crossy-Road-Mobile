using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Shit_Crossy_Road
{
    public class GUI
    {
        public GUI(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        public GraphicsDevice GraphicsDevice;
        public List<GUIObject> Components = new List<GUIObject>();

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GUIObject part in Components)
            {
                part.Interact();
                part.Draw(spriteBatch);
            }
        }
    }
}