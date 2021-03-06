using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace ThakurEscape.Android
{
    [Activity(Label = "ThakurEscape.Android"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Landscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class GameLaunchActivity : Microsoft.Xna.Framework.AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var g = new Game.ThakurEscapeGame();
            SetContentView((View)g.Services.GetService(typeof(View)));
            g.Run();
        }
    }
}

