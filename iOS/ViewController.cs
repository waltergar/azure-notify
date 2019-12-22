using System;
using UIKit;
using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json;

namespace AzureNotification.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
			Button.TouchUpInside += delegate
			{
				var title = string.Format("{0} sent!", count++);
				Button.SetTitle(title, UIControlState.Normal);
                SendPushNotificationAsync();
				var okCancelAlertController = UIAlertController.Create("Congratulations!", $"Notification has been sent to {Constants.DeviceTag} Device successfully!", UIAlertControllerStyle.Alert);

				//Add Actions
				okCancelAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => Console.WriteLine ("Okay was clicked")));

				//Present Alert
				PresentViewController(okCancelAlertController, true, null);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

        public static void SendPushNotificationAsync()
        {
			//Connect to Azure Notification Hub.
			NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(Constants.ConnectionString, Constants.NotificationHubName);

			//Send Notification to iOS device.
			var iOSalert = JsonConvert.SerializeObject(Constants.AppleNotificationContent);
            hub.SendAppleNativeNotificationAsync(iOSalert).Wait();

			//Send Notification to Android device.
			var androidAlert = JsonConvert.SerializeObject(Constants.FCMNotificationContent);
			hub.SendFcmNativeNotificationAsync(androidAlert, Constants.DeviceTag).Wait();
        }
	}
}
