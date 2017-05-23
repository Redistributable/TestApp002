using System;
using Android.App;
using Android.Content;
using Android.Nfc;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TestApp002
{
    [Activity(Label = "TestApp002", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            NfcManager nfcMan =  (NfcManager) this.GetSystemService(MainActivity.NfcService);
            NfcAdapter nfcAdp = nfcMan.DefaultAdapter;
            
            if (!nfcAdp.IsEnabled)
            {
                new AlertDialog.Builder(this)
                    .SetTitle("確認")
                    .SetMessage("NFCを有効にしてください。")
                    .SetPositiveButton("OK", delegate { })
                    .Create()
                    .Show();
                return;
            }
        }
    }
}

