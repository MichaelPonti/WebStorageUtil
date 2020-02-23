using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace AzureStorageUtil
{
	static class ActionUpload
	{
		public static bool ValidateOptions(Options options)
		{
			bool valid = true;

			if (String.IsNullOrWhiteSpace(options.Container) || options.Container != "$web")
			{
				Console.WriteLine("You must specify the --container argument and it must be $web for this command");
				valid = false;
			}

			if (String.IsNullOrWhiteSpace(options.ConnectionString))
			{
				Console.WriteLine("A --connectionString must be specified");
				valid = false;
			}

			return valid;
		}


		private static List<KeyValuePair<string, string>> GetListOfFilesToUpload(Options options)
		{
			List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
			ProcessDirectoryForUpload(options.SourceDirectory, options.SourceDirectory, ret);
			return ret;
		}

		private static void ProcessDirectoryForUpload(string sourceDir, string scanDir, List<KeyValuePair<string, string>> list)
		{
			string[] files = Directory.GetFiles(scanDir);
			foreach(string f in files)
			{
				// +1 to remove the path separator
				string relativePath = f.Substring(sourceDir.Length + 1);
				KeyValuePair<string, string> item = new KeyValuePair<string, string>(relativePath, f);
				list.Add(item);
			}

			string[] dirs = Directory.GetDirectories(scanDir);
			foreach (string dir in dirs)
				ProcessDirectoryForUpload(sourceDir, dir, list);
		}

		#region DEBUG

		public static void TestProcessDirectoryForUpload(string sourceDir, string scanDir, List<KeyValuePair<string, string>> list) =>
			ProcessDirectoryForUpload(sourceDir, scanDir, list);

		public static List<KeyValuePair<string, string>> TestGetListOfFilesToUpload(Options options) =>
			GetListOfFilesToUpload(options);

		#endregion


		public static void Run(Options options)
		{
			bool valid = ValidateOptions(options);
			if (!valid)
				return;

			var configService = new ConfigService();
			var config = configService.Read(options.ConfigFile);

			List<KeyValuePair<string, string>> files = GetListOfFilesToUpload(options);

			var storageAccount = CloudStorageAccount.Parse(options.ConnectionString);
			var blobClient = storageAccount.CreateCloudBlobClient();

			foreach (var f in files)
			{
				Console.WriteLine($"{f.Key}/{f.Value}");
			}
		}
	}
}
