using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using ThakurEscape.Windows.Screens;

namespace ThakurEscape.Windows
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class ThakurEscapeGame : Game
    {
        internal enum ScreenType
        {
            MainMenu,
            LevelSelector,
            Game,
            Exit
        };

        internal static float GameWidth { get; set; }
        internal static float GameHeight { get; set; }

        internal static ContentManager GameContent { get; private set; }
        public GraphicsDeviceManager Graphics { get; set; }
        private SpriteBatch _spriteBatch;
        private ScreenType _currentScreenType;
        private ScreenBase _currentScreen;
        private int _currentLevelNumber = 1;

        private MainScreen _mainScreen;
        internal MainScreen MainScreen
        {
            get
            {
                if (_mainScreen != null) return _mainScreen;
                _mainScreen = new MainScreen();
                _mainScreen.ChangeScreen += OnChangeScreen;
                return _mainScreen;
            }
        }

        private void OnChangeScreen(object sender, ScreenType screenType)
        {
            _currentScreenType = screenType;
            switch (_currentScreenType)
            {
                case ScreenType.MainMenu:
                    _currentScreen = MainScreen;
                    break;
                case ScreenType.LevelSelector:
                    _currentScreen = LevelSelectorScreen;
                    break;
                case ScreenType.Game:
                    _currentScreen = LevelScreen;
                    break;
                case ScreenType.Exit:
                    Exit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("screenType");
            }
        }

        private LevelSelectorScreen _levelSelectorScreen;
        internal LevelSelectorScreen LevelSelectorScreen
        {
            get { return _levelSelectorScreen ?? (_levelSelectorScreen = new LevelSelectorScreen()); }
        }

        private LevelScreen _levelScreen;
        internal LevelScreen LevelScreen
        {
            get { return _levelScreen ?? (_levelScreen = new LevelScreen(_currentLevelNumber)); }
        }

        public ThakurEscapeGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            GameContent = Content;
            GameContent.RootDirectory = "Content";
            _currentScreenType = ScreenType.MainMenu;
            _currentScreen = MainScreen;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GameWidth = GraphicsDevice.Viewport.Width;
            GameHeight = GraphicsDevice.Viewport.Height;

            TouchPanel.EnabledGestures = GestureType.VerticalDrag | GestureType.HorizontalDrag | GestureType.DragComplete |
                GestureType.Tap;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _currentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GameWidth = GraphicsDevice.Viewport.Width;
            GameHeight = GraphicsDevice.Viewport.Height;
            _currentScreen.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
