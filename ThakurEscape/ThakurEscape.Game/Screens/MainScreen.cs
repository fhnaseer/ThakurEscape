﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using ThakurEscape.Game.GameObjects.Menus;

namespace ThakurEscape.Game.Screens
{
    internal class MainScreen : FullScreenBase
    {
        private NewGame _newGame;
        internal NewGame NewGame => _newGame ?? (_newGame = new NewGame(0, 18));

        private ExitGame _exitGame;
        internal ExitGame ExitGame => _exitGame ?? (_exitGame = new ExitGame(10, 18));

        internal override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            NewGame.Draw(this, spriteBatch);
            ExitGame.Draw(this, spriteBatch);

            spriteBatch.End();
        }

        internal override void Update(GameTime gameTime)
        {
            HandleInput();
        }

        internal override void HandleInput()
        {
            HandleTouchInput();
            HandleMouseInput();
            HandleKeyboardInput();
        }

        private void HandleTouchInput()
        {
            while (TouchPanel.IsGestureAvailable)
            {
                var gesture = TouchPanel.ReadGesture();

                if (gesture.GestureType != GestureType.Tap) continue;
                var position = gesture.Position;
                if (NewGame.Contains(this, position))
                    OnChangeScreen(ThakurEscapeGame.ScreenType.Game);
                if (ExitGame.Contains(this, position))
                    OnChangeScreen(ThakurEscapeGame.ScreenType.Exit);
            }
        }

        private void HandleMouseInput()
        {
            var mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                var position = new Point(mouseState.X, mouseState.Y);
                if (NewGame.Contains(this, position))
                    OnChangeScreen(ThakurEscapeGame.ScreenType.Game);
                if (ExitGame.Contains(this, position))
                    OnChangeScreen(ThakurEscapeGame.ScreenType.Exit);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private void HandleKeyboardInput()
        {
            //var gamePadState = GamePad.GetState(PlayerIndex.One);
            //var keyboardState = Keyboard.GetState();
            //if (gamePadState.IsButtonDown(Buttons.DPadLeft) ||
            //    keyboardState.IsKeyDown(Keys.Left) ||
            //    keyboardState.IsKeyDown(Keys.A))
            //{
            //    _leftDown = true;
            //    _upDown = _downDown = _rightDown = false;
            //}
            //else if (gamePadState.IsButtonDown(Buttons.DPadRight) ||
            //         keyboardState.IsKeyDown(Keys.Right) ||
            //         keyboardState.IsKeyDown(Keys.D))
            //{
            //    _rightDown = true;
            //    _upDown = _leftDown = _leftDown = false;
            //}
            //else if (gamePadState.IsButtonDown(Buttons.DPadUp) ||
            //         keyboardState.IsKeyDown(Keys.Up) ||
            //         keyboardState.IsKeyDown(Keys.W))
            //{
            //    _upDown = true;
            //    _downDown = _leftDown = _rightDown = false;
            //}
            //else if (gamePadState.IsButtonDown(Buttons.DPadDown) ||
            //         keyboardState.IsKeyDown(Keys.Down) ||
            //         keyboardState.IsKeyDown(Keys.S))
            //{
            //    _downDown = true;
            //    _upDown = _leftDown = _rightDown = false;
            //}

            //if (gamePadState.IsButtonUp(Buttons.DPadLeft) && keyboardState.IsKeyUp(Keys.Left) && keyboardState.IsKeyUp(Keys.A))
            //{
            //    if (_leftDown)
            //    {
            //        _upDown = _downDown = _leftDown = _rightDown = false;
            //        Board.MovePlayer(Direction.Baain);
            //    }
            //}
            //if (gamePadState.IsButtonUp(Buttons.DPadRight) && keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.D))
            //{
            //    if (_rightDown)
            //    {
            //        _upDown = _downDown = _leftDown = _rightDown = false;
            //        Board.MovePlayer(Direction.Daain);
            //    }
            //}
            //if (gamePadState.IsButtonUp(Buttons.DPadUp) && keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.W))
            //{
            //    if (_upDown)
            //    {
            //        _upDown = _downDown = _leftDown = _rightDown = false;
            //        Board.MovePlayer(Direction.Ooper);
            //    }
            //}
            //if (!gamePadState.IsButtonUp(Buttons.DPadDown) || !keyboardState.IsKeyUp(Keys.Down) ||
            //    !keyboardState.IsKeyUp(Keys.S)) return;
            //if (!_downDown) return;
            //_upDown = _downDown = _leftDown = _rightDown = false;
            //Board.MovePlayer(Direction.Neechay);
        }
    }
}
