using System;
using System.Json;
namespace AzureNotification.iOS
{
	public class AppleNotificationData
	{
		public string alert { get; set; }
		public string sound { get; set; }
	}

	public class AppleNotificationObject
	{
		public AppleNotificationData aps { get; set; }
		public string bindingData { get; set; }
	}
}
