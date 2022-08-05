using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Shit_Crossy_Road
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        public static Game1 self;

        public int GAMEWINDOWWIDTH;
        public int GAMEWINDOWHEIGHT;

        public int GLOBALMULTIPLIER;

        public int SCREENSIZEHEIGHT;
        public int SCREENSIZEWIDTH;

        public Texture2D _blankTexture;
        public Texture2D spriteSheet;
        public SpriteFont _font;
        public SpriteFont _smallFont;

        public Player player;

        public int ticks = 0;

        Grid grid;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            GLOBALMULTIPLIER = 4;
            self = this;

            GAMEWINDOWHEIGHT = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 31;
            GAMEWINDOWWIDTH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 38;

            _graphics.PreferredBackBufferHeight = GAMEWINDOWHEIGHT;
            _graphics.PreferredBackBufferWidth = GAMEWINDOWWIDTH;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            System.Console.WriteLine(GAMEWINDOWHEIGHT + ":" + GAMEWINDOWWIDTH);

            grid = new Grid();

            player = new Player(200, 380);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _blankTexture = new Texture2D(GraphicsDevice, 1, 1);
            _blankTexture.SetData(new Color[] { Color.White });

            _font = Content.Load<SpriteFont>("Font");
            _smallFont = Content.Load<SpriteFont>("smallfont");

            spriteSheet = Content.Load<Texture2D>("spritesheet");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Back))
                Exit();

            if (player.gameState == Player.GameState.Gaming) {
                Road.Addthings();
                Cars.Update();
                player.Update();
            } else if (player.gameState == Player.GameState.Menu) {
                MainMenu.UseButtons();
            } 

            ticks++;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (player.gameState == Player.GameState.Gaming) {
                Background.Draw();
                Cars.Draw();
            }
            //grid.Draw();
             else if (player.gameState == Player.GameState.Menu) {
                MainMenu.Draw();
            }

            player.Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
