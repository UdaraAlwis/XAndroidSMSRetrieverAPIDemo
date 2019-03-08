using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Com.Google.Android.Gms.Auth.Api.Phone;

namespace XAndroidSMSRetrieverAPIDemo
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { SmsRetriever.SmsRetrievedAction })]
    public class SMSBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action != SmsRetriever.SmsRetrievedAction)
                return;

            var extrasBundleundle = intent.Extras;
            if (extrasBundleundle == null) return;
            var status = (Statuses)extrasBundleundle.Get(SmsRetriever.ExtraStatus);
            switch (status.StatusCode)
            {
                case CommonStatusCodes.Success:
                    // Get SMS message contents
                    var messageContent = (string)extrasBundleundle.Get(SmsRetriever.ExtraSmsMessage);
                    // Extract one-time code from the message and complete verification
                    // by sending the code back to your server.
                    ShowResultOnUI(messageContent, true);
                    break;

                case CommonStatusCodes.Timeout:
                    // Waiting for SMS timed out (5 minutes)
                    // Handle the error ...
                    ShowResultOnUI("Timed Out Error! SMS retrieval failed!", false);
                    break;
            }
        }
        
        private void ShowResultOnUI(string smsContent, bool isSuccess)
        {
            MainActivity.UpdateResultUI(smsContent, isSuccess);
        }
    }
}