# Xamarin Android SMS Retriever API Demo

Android SMS Retriever API allows you to access the SMS Messages in the phone without having to request SMS read access permission, thus giving a complete peace of mind for the user. :wink:
Oh yes it's available in Xamarin Android as well! :relaxed:

<img src="https://github.com/UdaraAlwis/XAndroidSMSRetrieverAPIDemo/blob/master/screenshots/Android SMS Retriever API OTP Action Demo.gif"  height="400" /> <img src="https://github.com/UdaraAlwis/XAndroidSMSRetrieverAPIDemo/blob/master/screenshots/Android SMS Retriever API OTP Action Demo.png"  height="400" />

In simplest terms we are going to have an object called SmsRetrieverClient that's going to wait for an incoming SMS message with the matching hash key to the app we are using. This active waiting is going to execute for 5 minutes and automatically dispose itself.
When the certain SMS arrived at the inbox during the 5 minute waiting , the SmsRetrieverClient then sends a broadcast to the app with the captured message content, for any listening broadcast receivers registered in the app.  From there we pick up the message inside our broadcast receiver and we process it or do whatever the heck we want with it. :stuck_out_tongue_winking_eye:

- Udara Alwis