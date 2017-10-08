using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using ThakurEscape.Windows.GameObjects.Menus;

namespace ThakurEscape.Windows.Screens
{
    internal class MainScreen : FullScreenBase
    {
        private NewGame _newGame;
        internal NewGame NewGame => _newGame ??
                                    (_newGame =
                                        new NewGame(BoardScreen.GetPositionFromIndex(new Vector2(), 0, 18),
                                            BoardScreen.GameObjectWidth * 2, BoardScreen.GameObjectHeight));

        private ExitGame _exitGame;
        internal ExitGame ExitGame => _exitGame ??
                                      (_exitGame =
                                          new ExitGame(BoardScreen.GetPositionFromIndex(new Vector2(), 10, 18),
                                              BoardScreen.GameObjectWidth * 2, BoardScreen.GameObjectHeight));

        internal override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            NewGame.Draw(spriteBatch);
            ExitGame.Draw(spriteBatch);

            spriteBatch.End();
        }

        internal override void Update(GameTime gameTime)
        {
            HandleInput();
        }

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

                if (gesture.GestureType != GestureType.Tap) continue;
                var position = gesture.Position;
                if (NewGame.BoundingRectangle.Contains(position))
                    OnChangeScreen(ThakurEscapeGame.ScreenType.Game);
                if (ExitGame.BoundingRectangle.Contains(position))
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
