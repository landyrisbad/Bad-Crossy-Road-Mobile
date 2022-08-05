using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Shit_Crossy_Road {
    public class Text : GUIObject
    {
        public Text(GUI container, int x, int y, int width, int height, string label, float textSize, Color color, Color textColor, SpriteFont font) : base(container, x, y, width, height, label)
        {
            _text = label;
            _textColor = textColor;
            _backgroundColor = color;
            _textSize = textSize;
            _font = font;

            _background = new Texture2D(Container.GraphicsDevice, 1, 1);
            _background.SetData(new Color[] { Color.White });
        }
        string _text;
        Color _textColor;
        Color _backgroundColor;
        float _textSize;
        Texture2D _background;
        SpriteFont _font;

        protected override void OnClick()
        {
            if (_label == "Insert Game Name Here")
            {
                Console.WriteLine("Credits:");
                Console.WriteLine("Me");
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, _boundingBox, _backgroundColor);

            float labelLength = (int)_font.MeasureString(_text).X * _textSize;
            float centreX = _boundingBox.Width / 2 - labelLength / 2 + _boundingBox.X;
            float labelHeight = (int)_font.MeasureString(_text).Y * _textSize;
            float centreY = _boundingBox.Height / 2 - labelHeight / 2 + _boundingBox.Y;

            Vector2 centrePosition = new Vector2(centreX, centreY);

            spriteBatch.DrawString(_font, _text, centrePosition, _textColor, 0f, new Vector2(0, 0), _textSize, SpriteEffects.None, 0f);
        }
    }

}