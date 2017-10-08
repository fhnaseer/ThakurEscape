﻿using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using ThakurEscape.Windows.GameObjects;
using ThakurEscape.Windows.GameObjects.Arrows;
using ThakurEscape.Windows.GameObjects.Chaabiyan;
using ThakurEscape.Windows.GameObjects.Fonts;

namespace ThakurEscape.Windows.Screens
{
    class LevelControllerScreen : ScreenBase
    {
        public LevelControllerScreen()
            : base(0, ThakurEscapeGame.GameHeight / 11 * 10,
            ThakurEscapeGame.GameWidth, ThakurEscapeGame.GameHeight / 11)
        {
        }

        internal Thakur Thakur { get; set; }
        internal BoardScreen Board { get; set; }

        private LeftArrow _moveLeft;
        internal LeftArrow MoveLeft
        {
            get { return _moveLeft ?? (_moveLeft = new LeftArrow(Position.X, Position.Y, Width / 6, Height)); }
        }

        private RightArrow _moveRight;
        internal RightArrow MoveRight
        {
            get { return _moveRight ?? (_moveRight = new RightArrow(Position.X + Width / 6, Position.Y, Width / 6, Height)); }
        }

        private UpArrow _moveUp;
        internal UpArrow MoveUp
        {
            get { return _moveUp ?? (_moveUp = new UpArrow(Position.X + Width / 6 * 4, Position.Y, Width / 6, Height)); }
        }

        private DownArrow _moveDown;
        internal DownArrow MoveDown
        {
            get { return _moveDown ?? (_moveDown = new DownArrow(Position.X + Width / 6 * 5, Position.Y, Width / 6, Height)); }
        }

        private LaalChaabi _laalChaabi;
        internal LaalChaabi LaalChaabi
        {
            get { return _laalChaabi ?? (_laalChaabi = new LaalChaabi(Position.X + Width / 6 * 3 + Height, Position.Y, Height, Height)); }
        }

        private SabzChaabi _sabzChaabi;
        internal SabzChaabi SabzChaabi
        {
            get { return _sabzChaabi ?? (_sabzChaabi = new SabzChaabi(Position.X + Width / 6 * 3 + Height + Height, Position.Y, Height, Height)); }
        }

        internal static string KeysText { get { return "Keys: "; } }
        internal Vector2 KeysTextPostiion
        {
            get { return new Vector2(Position.X + Width / 6 * 3, Position.Y); }
        }

        internal string TaaqatText
        {
            get
            {
                return string.Format(CultureInfo.CurrentUICulture, "Moves Left: {0}", Thakur.Taaqat);
            }
        }
        internal Vector2 TaaqatTextPosition
        {
            get { return new Vector2(Position.X + Width / 6 * 2, Position.Y); }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            MoveLeft.Draw(spriteBatch);
            MoveRight.Draw(spriteBatch);
            MoveUp.Draw(spriteBatch);
            MoveDown.Draw(spriteBatch);

            Segoe.Instance.Draw(spriteBatch, TaaqatText, TaaqatTextPosition, Color.Black, 1f, 1f);
            Segoe.Instance.Draw(spriteBatch, KeysText, KeysTextPostiion, Color.Black, 1f, 1f);
            if (Thakur.HasSabzChaabi)
                SabzChaabi.Draw(spriteBatch);
            if (Thakur.HasLaalChaabi)
                LaalChaabi.Draw(spriteBatch);
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
                        if (BoundingRectangle.Contains(position))
                        {
                            var kidher = GetDirection(position);
                            Board.MovePlayer(kidher);
                        }
                        break;
                    case GestureType.Pinch:
                        {
                            // TODO: This code should be in Board,
                            // Do we need this?,
                            // current positions
                            //var firstPosition = gesture.Position;
                            //var lastPosition = gesture.Position2;
                            //var distance = Vector2.Distance(firstPosition, lastPosition);

                            //// prior positions
                            //var oldFirstPosition = gesture.Position - gesture.Delta;
                            //var oldLastPosition = gesture.Position2 - gesture.Delta2;
                            //var oldDistance = Vector2.Distance(oldFirstPosition, oldLastPosition);

                            //if (!_pinching)
                            //{
                            //    // start of pinch, record original distance
                            //    _pinching = true;
                            //    _pinchInitialDistance = oldDistance;
                            //}

                            //// work out zoom amount based on pinch distance...
                            //var zoomFactor = (oldDistance - distance) * 0.05f;
                            //ZoomBy(zoomFactor);
                        }
                        break;
                    case GestureType.PinchComplete:
                        //_pinching = false;
                        break;
                    case GestureType.VerticalDrag:
                        {
                            var currentPosition = gesture.Position;
                            _moveTo = currentPosition.Y > _tempPosition.Y ? KidherChalayHoBadshaho.Neechay : KidherChalayHoBadshaho.Ooper;
                            _tempPosition = currentPosition;
                        }
                        break;
                    case GestureType.HorizontalDrag:
                        {
                            var currentPosition = gesture.Position;
                            _moveTo = currentPosition.X > _tempPosition.X ? KidherChalayHoBadshaho.Daain : KidherChalayHoBadshaho.Baain;
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
                    Board.MovePlayer(KidherChalayHoBadshaho.Baain);
                }
            }
            if (gamePadState.IsButtonUp(Buttons.DPadRight) && keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.D))
            {
                if (_rightDown)
                {
                    _upDown = _downDown = _leftDown = _rightDown = false;
                    Board.MovePlayer(KidherChalayHoBadshaho.Daain);
                }
            }
            if (gamePadState.IsButtonUp(Buttons.DPadUp) && keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.W))
            {
                if (_upDown)
                {
                    _upDown = _downDown = _leftDown = _rightDown = false;
                    Board.MovePlayer(KidherChalayHoBadshaho.Ooper);
                }
            }
            if (!gamePadState.IsButtonUp(Buttons.DPadDown) || !keyboardState.IsKeyUp(Keys.Down) ||
                !keyboardState.IsKeyUp(Keys.S)) return;
            if (!_downDown) return;
            _upDown = _downDown = _leftDown = _rightDown = false;
            Board.MovePlayer(KidherChalayHoBadshaho.Neechay);
        }

        private Vector2 _tempPosition;
        private KidherChalayHoBadshaho _moveTo;

        internal KidherChalayHoBadshaho GetDirection(Vector2 position)
        {
            if (MoveLeft.BoundingRectangle.Contains(position))
                return KidherChalayHoBadshaho.Baain;
            if (MoveRight.BoundingRectangle.Contains(position))
                return KidherChalayHoBadshaho.Daain;
            if (MoveUp.BoundingRectangle.Contains(position))
                return KidherChalayHoBadshaho.Ooper;
            return MoveDown.BoundingRectangle.Contains(position)
                ? KidherChalayHoBadshaho.Neechay
                : KidherChalayHoBadshaho.KahinBhiNahin;
        }
        #endregion
    }
}