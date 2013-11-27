using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ThakurEscape.Android
{
    [Activity(Label = "ThakurEscape.Android"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        //, LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Landscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)]
    public class ThakurEscapeActivity : Microsoft.Xna.Framework.AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ThakurEscapeGame.Activity = this;
            var game = new ThakurEscapeGame();
            SetContentView(game.Window);
            game.Run();
        }
    }
}

