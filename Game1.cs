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
        public Texture2D _arrow;

        public Player player;

        public int ticks = 0;

        Grid grid;

        GUI mainMenu;

        public void Begin()
        {
            player.xPos = Game1.self.GAMEWINDOWWIDTH / 2;
            player.yPos = 560;
            player.gameState = Player.GameState.Gaming;
            player.score = 0;
        }

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

            player = new Player(200, 560);

            _font = Content.Load<SpriteFont>("Font");

            #region GUI
            mainMenu = new GUI(GraphicsDevice);
            new Button(mainMenu, GAMEWINDOWWIDTH / 2 - 250, GAMEWINDOWHEIGHT / 2 - 50, 500, 100, "Play", 0.5f, Begin, Color.White, Color.Black, _font);
            Vector2 things = _font.MeasureString("Crossy Road but Worse");
            new Text(mainMenu, GAMEWINDOWWIDTH/2, GAMEWINDOWHEIGHT / 4, 0, 0, "Crossy Road but Worse", 0.8f, Color.Black, Color.White, _font);
            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _blankTexture = new Texture2D(GraphicsDevice, 1, 1);
            _blankTexture.SetData(new Color[] { Color.White });

            _smallFont = Content.Load<SpriteFont>("smallfont");

            spriteSheet = Content.Load<Texture2D>("spritesheet");
            _arrow = Content.Load<Texture2D>("Untitled");

            Background.StartGenerate();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Back))
                Exit();

            Road.Addthings();
                Cars.Update();
            if (player.gameState == Player.GameState.Gaming) {
                player.Update();
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
                player.Draw();
            }
            //grid.Draw();
             else if (player.gameState == Player.GameState.Menu) {
                Background.Draw();
                Cars.Draw();
                if (player.score != 0)
                {
                    _spriteBatch.DrawString(_smallFont, "Your score was " + System.Convert.ToString(player.score), new Vector2(GAMEWINDOWWIDTH / 2 - _smallFont.MeasureString("Your score was " + System.Convert.ToString(player.score)).X / 2, GAMEWINDOWHEIGHT / 2 + 100), Color.White);
                    _spriteBatch.DrawString(_smallFont, player.DeathMessage, new Vector2(GAMEWINDOWWIDTH / 2 - _smallFont.MeasureString(player.DeathMessage).X / 2, GAMEWINDOWHEIGHT / 2 + 200), Color.White);
                }
                mainMenu.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
