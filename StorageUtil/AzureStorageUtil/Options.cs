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
		public const string ActionContentType = "contenttype";
		public const string ActionUpload = "upload";

		[Option('a', "action", Default = ActionContentType, HelpText = "Action to perform: contenttype | upload")]
		public string Action { get; set; }

		// these are the common options for both "contenttype" and "upload"
		[Option(Default = true, HelpText = "Prints all messages")]
		public bool Verbose { get; set; }

		[Option('c', "container", Default = "$web", Required = false, HelpText = "Blob Container Name")]
		public string Container { get; set; }


		[Option('k', "connectionString", Required = true, HelpText = "Storage connection string")]
		public string ConnectionString { get; set; }


		// this is specific for changing the content types. It specifies the mapping file
		// we also need it for upload.
		[Option('s', "config", Required = false, HelpText = "Config file to use")]
		public string ConfigFile { get; set; }


		// this is specific for upload.
		[Option('d', "srcdir", HelpText = "For upload, the source directory")]
		public string SourceDirectory { get; set; }

	}
}
