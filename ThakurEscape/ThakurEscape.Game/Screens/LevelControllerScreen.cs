using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using ThakurEscape.Game.GameObjects;
using ThakurEscape.Game.GameObjects.Arrows;
using ThakurEscape.Game.GameObjects.Keys;

namespace ThakurEscape.Game.Screens
{
    internal class LevelControllerScreen : ScreenBase
    {
        public LevelControllerScreen()
            : base(0, 10, 1, GameContext.Columns)
        {
        }

        internal BoardScreen Board { get; set; }
        internal Thakur Thakur { get; set; }

        private LeftArrow _moveLeft;
        internal LeftArrow MoveLeft => _moveLeft ?? (_moveLeft = new LeftArrow(0, 1));

        private RightArrow _moveRight;
        internal RightArrow MoveRight => _moveRight ?? (_moveRight = new RightArrow(0, 3));

        private UpArrow _moveUp;
        internal UpArrow MoveUp => _moveUp ?? (_moveUp = new UpArrow(0, 16));

        private DownArrow _moveDown;
        internal DownArrow MoveDown => _moveDown ?? (_moveDown = new DownArrow(0, 18));

        private LaalChaabi _laalChaabi;
        internal LaalChaabi LaalChaabi => _laalChaabi ?? (_laalChaabi = new LaalChaabi(0, 11));

        private SabzChaabi _sabzChaabi;
        internal SabzChaabi SabzChaabi => _sabzChaabi ?? (_sabzChaabi = new SabzChaabi(0, 12));

        internal static string KeysText => "Keys: ";

        //internal Vector2 KeysTextPostiion => new Vector2(Position.X + Width / 6 * 3, Position.Y);

        //internal string TaaqatText => string.Format(CultureInfo.CurrentUICulture, "Moves Left: {0}", Thakur.Taaqat);
        //internal Vector2 TaaqatTextPosition => new Vector2(Position.X + Width / 6 * 2, Position.Y);

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            MoveLeft.Draw(this, spriteBatch);
            MoveRight.Draw(this, spriteBatch);
            MoveUp.Draw(this, spriteBatch);
            MoveDown.Draw(this, spriteBatch);

            //Segoe.Instance.Draw(spriteBatch, TaaqatText, TaaqatTextPosition, Color.Black, 1f, 1f);
            //Segoe.Instance.Draw(spriteBatch, KeysText, KeysTextPostiion, Color.Black, 1f, 1f);
            if (Thakur.HasSabzChaabi)
                SabzChaabi.Draw(this, spriteBatch);
            if (Thakur.HasLaalChaabi)
                LaalChaabi.Draw(this, spriteBatch);

            spriteBatch.End();
        }

        internal override void Update(GameTime gameTime)
        {
            HandleInput();
        }

        #region Input handlers,
        internal override void HandleInput()
        {
            HandleTouchInput();
            HandleKeyboardInput();
        }

        private void HandleTouchInput()
        {
            while (TouchPanel.IsGestureAvailable)
            {
                var gesture = TouchPanel.ReadGesture();

                switch (gesture.GestureType)
                {
                    case GestureType.Tap:
                        var position = gesture.Position;
                        if (ExtensionMethods.GetBoundingRectangle(this, GameContext.Instance).Contains(position))
                        {
                            var kidher = GetDirection(position);
                            Board.MovePlayer(kidher);
                        }
                        break;
                    case GestureType.VerticalDrag:
                        {
                            var currentPosition = gesture.Position;
                            _moveTo = currentPosition.Y > _tempPosition.Y ? MovementDirection.Down : MovementDirection.Up;
                            _tempPosition = currentPosition;
                        }
                        break;
                    case GestureType.HorizontalDrag:
                        {
                            var currentPosition = gesture.Position;
                            _moveTo = currentPosition.X > _tempPosition.X ? MovementDirection.Right : MovementDirection.Left;
                            _tempPosition = currentPosition;
                        }
                        break;
                    case GestureType.DragComplete:
                        Board.MovePlayer(_moveTo);
                        break;
                }
            }
        }

        private bool _downDown;
        private bool _upDown;
        private bool _leftDown;
        private bool _rightDown;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
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
                    Board.MovePlayer(MovementDirection.Left);
                }
            }
            if (gamePadState.IsButtonUp(Buttons.DPadRight) && keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.D))
            {
                if (_rightDown)
                {
                    _upDown = _downDown = _leftDown = _rightDown = false;
                    Board.MovePlayer(MovementDirection.Right);
                }
            }
            if (gamePadState.IsButtonUp(Buttons.DPadUp) && keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.W))
            {
                if (_upDown)
                {
                    _upDown = _downDown = _leftDown = _rightDown = false;
                    Board.MovePlayer(MovementDirection.Up);
                }
            }
            if (!gamePadState.IsButtonUp(Buttons.DPadDown) || !keyboardState.IsKeyUp(Keys.Down) ||
                !keyboardState.IsKeyUp(Keys.S)) return;
            if (!_downDown) return;
            _upDown = _downDown = _leftDown = _rightDown = false;
            Board.MovePlayer(MovementDirection.Down);
        }

        private Vector2 _tempPosition;
        private MovementDirection _moveTo;

        internal MovementDirection GetDirection(Vector2 position)
        {
            if (ExtensionMethods.GetBoundingRectangle(this, MoveLeft, GameContext.Instance).Contains(position))
                return MovementDirection.Left;
            if (ExtensionMethods.GetBoundingRectangle(this, MoveRight, GameContext.Instance).Contains(position))
                return MovementDirection.Right;
            if (ExtensionMethods.GetBoundingRectangle(this, MoveUp, GameContext.Instance).Contains(position))
                return MovementDirection.Up;
            return ExtensionMethods.GetBoundingRectangle(this, MoveDown, GameContext.Instance).Contains(position)
                ? MovementDirection.Down
                : MovementDirection.None;
        }
        #endregion
    }
}
