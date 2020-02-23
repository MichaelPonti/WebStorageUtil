using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageUtil
{
	class ActionContentTypes
	{
		public static bool ValidateOptions(Options options)
		{
			bool valid = true;

			if (String.IsNullOrWhiteSpace(options.Container) || options.Container != "$web")
			{
				Console.WriteLine("You must specify the --container property and it must be $web for this command");
				valid = false;
			}

			if (String.IsNullOrWhiteSpace(options.ConnectionString))
			{
				Console.WriteLine("A --connectionString must be specified");
				valid = false;
			}

			if (!String.IsNullOrWhiteSpace(options.ConfigFile) && !File.Exists(options.ConfigFile))
			{
				Console.WriteLine("A --config parameter must specify an existing file");
				valid = false;
			}



			return valid;
		}


		public static string GetMimeType(Config config, string absoluteUri)
		{
			string extension = Path.GetExtension(absoluteUri);
			var mimeSetting = (from m in config.Extensions
							   where String.Compare(extension, m.Extension, StringComparison.InvariantCultureIgnoreCase) == 0
							   select m)
							   .FirstOrDefault();
			return mimeSetting?.Mime;
		}

		public static void Run(Options options)
		{
			bool valid = ValidateOptions(options);
			if (!valid)
				return;


			var configService = new ConfigService();
			var config = configService.Read(options.ConfigFile);

			var storageAccount = CloudStorageAccount.Parse(options.ConnectionString);
			var blobClient = storageAccount.CreateCloudBlobClient();
			var blobs = blobClient
				.GetContainerReference(options.Container)
				.ListBlobs(useFlatBlobListing: true)
				.OfType<CloudBlockBlob>();

			foreach(var blob in blobs)
			{
				Console.WriteLine($"Processing:\t{blob.Uri.AbsoluteUri}");
				string mime = GetMimeType(config, blob.Uri.AbsoluteUri);
				if (!String.IsNullOrWhiteSpace(mime))
				{
					Console.WriteLine($"Setting content type:\t{mime}");
					blob.Properties.ContentType = mime;
					blob.SetProperties();
				}
			}

			Console.WriteLine("Finished processing");
		}
	}
}
