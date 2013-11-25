using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using ThakurEscape.GameObjects;

namespace ThakurEscape
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class ThakurEscapeGame : Game
    {
        internal static float GameWidth; 
        internal static float GameHeight;

        internal static ContentManager GameContent { get; private set; }
        public GraphicsDeviceManager Graphics { get; set; }

        SpriteBatch _spriteBatch;
        private Level _level;

        public ThakurEscapeGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            GameContent = Content;
            GameContent.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _level = new Level();
            TouchPanel.EnabledGestures = GestureType.Pinch | GestureType.PinchComplete |
                GestureType.VerticalDrag | GestureType.HorizontalDrag | GestureType.DragComplete;

            GameWidth = GraphicsDevice.Viewport.Width;
            GameHeight = GraphicsDevice.Viewport.Height;
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

            //var playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X,
            //    GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            //_player.Initialize(Content.Load<Texture2D>("Graphics\\player\\Akram.png"), playerPosition); 
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
            HandleInput();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //_spriteBatch.Begin();

            _level.Draw(_spriteBatch);

            //_spriteBatch.End();

            base.Draw(gameTime);
        }

        private void HandleInput()
        {
            HandleTouchInput();
            HandleKeyboardInput();
        }

        bool _pinching;
        float _pinchInitialDistance;
        private void HandleTouchInput()
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                if (gesture.GestureType == GestureType.Pinch)
                {
                    // current positions
                    Vector2 a = gesture.Position;
                    Vector2 b = gesture.Position2;
                    float dist = Vector2.Distance(a, b);

                    // prior positions
                    Vector2 aOld = gesture.Position - gesture.Delta;
                    Vector2 bOld = gesture.Position2 - gesture.Delta2;
                    float distOld = Vector2.Distance(aOld, bOld);

                    if (!_pinching)
                    {
                        // start of pinch, record original distance
                        _pinching = true;
                        _pinchInitialDistance = distOld;
                    }

                    // work out zoom amount based on pinch distance...
                    float scale = (distOld - dist) * 0.05f;
                    ZoomBy(scale);
                }
                else if (gesture.GestureType == GestureType.PinchComplete)
                {
                    // end of pinch
                    _pinching = false;
                }
                else if (gesture.GestureType == GestureType.VerticalDrag)
                {
                    var currentPosition = gesture.Position;
                    _moveTo = currentPosition.Y > _tempPosition.Y ? KithayChalayHoBadshaho.Thallay : KithayChalayHoBadshaho.Utay;
                    _tempPosition = currentPosition;
                }
                else if (gesture.GestureType == GestureType.HorizontalDrag)
                {
                    var currentPosition = gesture.Position;
                    _moveTo = currentPosition.X > _tempPosition.X ? KithayChalayHoBadshaho.Sajjay : KithayChalayHoBadshaho.Khabbay;
                    _tempPosition = currentPosition;
                }
                else if (gesture.GestureType == GestureType.DragComplete)
                {
                    _level.MovePlayer(_moveTo);
                }
            }
        }

        private bool _downDown;
        private bool _upDown;
        private bool _leftDown;
        private bool _rightDown;
        private void HandleKeyboardInput()
        {
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            var keyboardState = Keyboard.GetState();
            if (gamePadState.IsButtonDown(Buttons.DPadLeft) ||
                keyboardState.IsKeyDown(Keys.Left) ||
                keyboardState.IsKeyDown(Keys.A))
            {
                _leftDown = true;
                _upDown = _downDown = _rightDown = false;
            }
            else if (gamePadState.IsButtonDown(Buttons.DPadRight) ||
                     keyboardState.IsKeyDown(Keys.Right) ||
                     keyboardState.IsKeyDown(Keys.D))
            {
                _rightDown = true;
                _upDown = _leftDown = _leftDown = false;
            }
            else if (gamePadState.IsButtonDown(Buttons.DPadUp) ||
                     keyboardState.IsKeyDown(Keys.Up) ||
                     keyboardState.IsKeyDown(Keys.W))
            {
                _upDown = true;
                _downDown = _leftDown = _rightDown = false;
            }
            else if (gamePadState.IsButtonDown(Buttons.DPadDown) ||
                     keyboardState.IsKeyDown(Keys.Down) ||
                     keyboardState.IsKeyDown(Keys.S))
            {
                _downDown = true;
                _upDown = _leftDown = _rightDown = false;
            }

            if (gamePadState.IsButtonUp(Buttons.DPadLeft) && keyboardState.IsKeyUp(Keys.Left) && keyboardState.IsKeyUp(Keys.A))
            {
                if (_leftDown)
                {
                    _upDown = _downDown = _leftDown = _rightDown = false;
                    _level.MovePlayer(KithayChalayHoBadshaho.Khabbay);
                }
            }
            if (gamePadState.IsButtonUp(Buttons.DPadRight) && keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.D))
            {
                if (_rightDown)
                {
                    _upDown = _downDown = _leftDown = _rightDown = false;
                    _level.MovePlayer(KithayChalayHoBadshaho.Sajjay);
                }
            }
            if (gamePadState.IsButtonUp(Buttons.DPadUp) && keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.W))
            {
                if (_upDown)
                {
                    _upDown = _downDown = _leftDown = _rightDown = false;
                    _level.MovePlayer(KithayChalayHoBadshaho.Utay);
                }
            }
            if (gamePadState.IsButtonUp(Buttons.DPadDown) && keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.S))
            {
                if (_downDown)
                {
                    _upDown = _downDown = _leftDown = _rightDown = false;
                    _level.MovePlayer(KithayChalayHoBadshaho.Thallay);
                }
            }
        }

        private Vector2 _tempPosition;
        private KithayChalayHoBadshaho _moveTo;

        private void ZoomBy(float scale)
        {
            //throw new System.NotImplementedException();
        }
    }
}
