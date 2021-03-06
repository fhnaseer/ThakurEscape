﻿using ThakurEscape.Game;
using Windows.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ThakurEscape
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage
    {
        public ThakurEscapeGame Game { get; }

        public GamePage()
        {
            InitializeComponent();
            // Create the game.
            var launchArguments = string.Empty;
            Game = MonoGame.Framework.XamlGame<ThakurEscapeGame>.Create(launchArguments, Window.Current.CoreWindow, SwapChainPanel);
        }
    }
}
