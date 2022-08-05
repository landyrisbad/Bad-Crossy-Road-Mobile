using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace Shit_Crossy_Road {
    public abstract class GUIObject
    {
        public GUIObject(GUI container, int x, int y, int width, int height, string label)
        {
            _position = new Vector2(x, y);
            _boundingBox = new Rectangle(x, y, width, height);

            _label = label;

            Container = container;

            container.Components.Add(this);
        }

        public Vector2 _position;
        public string _label;
        public Rectangle _boundingBox;

        protected GUI Container;

        TouchCollection touch = TouchPanel.GetState();

        bool hovering = false;

        public void Interact()
        {
            touch = TouchPanel.GetState();

            if (touch.Count > 0)
            {
                var currentTouch = touch[touch.Count - 1];
                if ((currentTouch.State == TouchLocationState.Released))
                {
                    if (_boundingBox.Contains(currentTouch.Position))
                    {
                        OnClick();
                        hovering = false;
                        UnHover();
                    } else if (hovering)
                    {
                        hovering = false;
                        UnHover();
                    }
                }
                else if ((currentTouch.State == TouchLocationState.Pressed))
                {
                    if (_boundingBox.Contains(currentTouch.Position) && !hovering)
                    {
                        hovering = true;
                        Hover();
                    }
                    else if (!_boundingBox.Contains(currentTouch.Position) && hovering)
                    {
                        hovering = false;
                        UnHover();
                    }
                }
            }
        }

        protected virtual void OnClick() { }
        protected virtual void Hover() { }
        protected virtual void UnHover() { }
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}