using System;
using System.Json;
namespace AzureNotification.iOS
{
	public class AndroidNotificationData
	{
		public string bindingData { get; set; }
		public string message { get; set; }
	}
	public class AndroidNotificationObject
	{
		public AndroidNotificationData data { get; set; }
	}
}
