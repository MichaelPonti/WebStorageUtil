using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageUtil
{
	class ConfigService
	{
		public Config Read(string filename = null)
		{
			string f = (String.IsNullOrWhiteSpace(filename) || !File.Exists(filename)) ? GetDefaultName() : filename;
			using (StreamReader r = new StreamReader(f))
			{
				string data = r.ReadToEnd();
				Config cfg = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(data);
				return cfg;
			}
		}

		private string GetDefaultName()
		{
			string location = this.GetType().Assembly.Location;
			location = Path.GetDirectoryName(location);
			location = Path.Combine(location, "default.json");
			return location;
		}
	}
}
