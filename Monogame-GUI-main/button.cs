using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Shit_Crossy_Road {
    public class Button : GUIObject
    {
        public Button(GUI container, int x, int y, int width, int height, string label, float textSize, Action onClick, Color color, Color textColor, SpriteFont font) : base(container, x, y, width, height, label)
        {
            _message = label;
            _texture = new Texture2D(Container.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });
            _backGroundColor = color;
            _textColor = textColor;
            _textSize = textSize;
            _onClick = onClick;

            _font = font;
            Console.WriteLine(font);

            _shadowBox = _boundingBox;
            _drawBox = new Rectangle(_boundingBox.X - shadowSize, _boundingBox.Y - shadowSize, _boundingBox.Width, _boundingBox.Height);
        }

        string _message;
        float _textSize;
        SpriteFont _font;
        Color _textColor;
        Color _backGroundColor;
        Texture2D _texture;
        public Action _onClick;

        Rectangle _shadowBox;
        Rectangle _drawBox;
        int shadowSize = 10;

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _shadowBox, Color.Gray);
            spriteBatch.Draw(_texture, _drawBox, _backGroundColor);

            float labelLength = (int)_font.MeasureString(_message).X * _textSize;
            float centreX = _drawBox.Width / 2 - labelLength / 2 + _drawBox.X;
            float labelHeight = (int)_font.MeasureString(_message).Y * _textSize;
            float centreY = _drawBox.Height / 2 - labelHeight / 2 + _drawBox.Y;

            Vector2 centrePosition = new Vector2(centreX, centreY);

            spriteBatch.DrawString(_font, _message, centrePosition, _textColor, 0f, new Vector2(0, 0), _textSize, SpriteEffects.None, 0f);
        }
        protected override void Hover()
        {
            _drawBox = new Rectangle(_drawBox.X + shadowSize, _drawBox.Y + shadowSize, _drawBox.Width, _drawBox.Height);
        }
        protected override void UnHover()
        {
            _drawBox = new Rectangle(_drawBox.X - shadowSize, _drawBox.Y - shadowSize, _drawBox.Width, _drawBox.Height);
        }
        protected override void OnClick()
        {
            _onClick();
        }
    }
}