using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageUtil
{
	class Options
	{
		[Option(Default = true, HelpText = "Prints all messages")]
		public bool Verbose { get; set; }

		[Option('c', "container", Default = "$web", Required = false, HelpText = "Blob Container Name")]
		public string Container { get; set; }


		[Option('k', "connectionString", Required = true, HelpText = "Storage connection string")]
		public string ConnectionString { get; set; }

		[Option('s', "config", Required = false, HelpText = "Config file to use")]
		public string ConfigFile { get; set; }
	}
}
