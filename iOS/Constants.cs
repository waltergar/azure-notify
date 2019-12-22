using System;
using System.Json;
namespace AzureNotification.iOS
{
	public class Constants
	{
		public const string ConnectionString = "Endpoint=sb://trulite.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=EM5bmnmOKD9OmG+UUNHEIqjEQs2xoaRms+YoXghvkJo=";
		public const string NotificationHubName = "trulite02testhub";
		public const string DeviceTag = "UniqueTagForDevice1";

		public static AndroidNotificationObject FCMNotificationContent = new AndroidNotificationObject
		{
			data = new AndroidNotificationData
			{
				bindingData = @"{""salesOrderKey"":""123456789""}",
				message = "The delivery date on your purchase XZY has been updated, the new date is 11/20/2019!",
			}
		};

		public static AppleNotificationObject AppleNotificationContent = new AppleNotificationObject
		{
			aps = new AppleNotificationData { 
				alert = "The delivery date on your purchase XZY has been updated, the new date is 11/20/2019!",
				sound = "default"
			},
			bindingData = @"{""salesOrderKey"":""123456789""}",
		};
	}
}
