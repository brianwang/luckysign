using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ServiceHost
{
	public class ServiceConfig
	{
		public static string ServiceName
		{
			get
			{
				try
				{
					System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(Assembly.GetCallingAssembly().Location);

					string configedServiceName = config.AppSettings.Settings["ServiceName"].Value;
					if (!String.IsNullOrWhiteSpace(configedServiceName))
					{
						return configedServiceName;
					}
				}
				catch { }
				return Constants.DefaultServiceName;
			}
		}

		public static string DisplayName
		{
			get
			{
				try
				{
					System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(Assembly.GetCallingAssembly().Location);

					string configedDisplayName = config.AppSettings.Settings["DisplayName"].Value;
					if (!String.IsNullOrWhiteSpace(configedDisplayName))
					{
						return configedDisplayName;
					}
				}
				catch { }
				return Constants.DefaultServiceDisplayName;
			}
		}

		public static string Description
		{
			get
			{
				return Constants.DefaultServiceDescription;
			}
		}
	}
}
