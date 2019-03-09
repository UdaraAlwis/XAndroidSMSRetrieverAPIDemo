using System;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Google.Android.Gms.Auth.Api.Phone;
using XAndroidSMSRetrieverAPIDemo.Util;
using Exception = Java.Lang.Exception;
using Object = Java.Lang.Object;

namespace XAndroidSMSRetrieverAPIDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private SmsRetrieverClient _client;

        private Button btnStartSMSRetreiver;
        private TextView tvSMSContent;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // UI elements
            btnStartSMSRetreiver = FindViewById<Button>(Resource.Id.btnStartSMSRetreiver);
            btnStartSMSRetreiver.Click += btnStartSMSRetreiver_OnClick;

            tvSMSContent = FindViewById<TextView>(Resource.Id.tvSMSContent);
            // UI elements

            _instance = this;

            //// One time execution just to retrieve the App Hash Key
            // var appHashKey = AppHashKeyHelper.GetAppHashKey(this);
        }
        
        private void btnStartSMSRetreiver_OnClick(object sender, EventArgs eventArgs)
        {
            // Get an instance of SmsRetrieverClient, used to start listening for a matching SMS message.
            _client = SmsRetriever.GetClient(this.ApplicationContext);
            // Starts SmsRetriever, which waits for ONE matching SMS message until timeout
            // (5 minutes). The matching SMS message will be sent via a Broadcast Intent with
            // action SmsRetriever#SMS_RETRIEVED_ACTION.
            var task = _client.StartSmsRetriever();

            // You could also Listen for success/failure of StartSmsRetriever
            task.AddOnSuccessListener(new SuccessListener());
            task.AddOnFailureListener(new FailureListener());
            
            Snackbar.Make((View)sender, "SMS Retriever started...", Snackbar.LengthShort).Show();
            tvSMSContent.Text = $"SMS retrieval results will be shown here...";
        }

        private static MainActivity _instance;
        public static void UpdateResultUI(string smsContent, bool isSuccess)
        {
            _instance.tvSMSContent.Text = isSuccess ? $"SMS retrieved: \n\n{smsContent}" : $"Failed: \n\n{smsContent}";
        }
    }

    internal class SuccessListener : Java.Lang.Object, IOnSuccessListener
    {
        public void OnSuccess(Object result)
        {

        }
    }

    internal class FailureListener : Java.Lang.Throwable, IOnFailureListener
    {
        public void OnFailure(Exception e)
        {
            
        }
    }
}

