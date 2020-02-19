using CommandLine;
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
	class Program
	{
		static void Main(string[] args)
		{
			ShowHeader();

			CommandLine.Parser.Default.ParseArguments<Options>(args)
				.WithParsed(RunWithOptions)
				.WithNotParsed(HandleParseErrors);
		}

		static void ShowHeader()
		{
			Console.WriteLine("StorageUtil Commandline Util");
			Console.WriteLine("Written by: Michael Ponti");
			Console.WriteLine("https://github.com/michaelponti/WebStorageUtil");
			Console.WriteLine("Change MIME's of files uploaded to storage account");
			Console.WriteLine("Add to your pipeline for static site deployments");
		}

		static void HandleParseErrors(IEnumerable<Error> errors)
		{
		}



		static void RunWithOptions(Options options)
		{
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
				Console.WriteLine(blob.Uri.AbsoluteUri + " being processed");
				string mime = GetMimeType(config, blob.Uri.AbsoluteUri);
				if (!String.IsNullOrWhiteSpace(mime))
				{
					Console.WriteLine($"Setting content-type to {mime}");
					blob.Properties.ContentType = mime;
					blob.SetProperties();
				}
			}


			Console.WriteLine("Finished processing");
		}

		static string GetMimeType(Config config, string absoluteUri)
		{
			string extension = Path.GetExtension(absoluteUri);
			var mimeSetting = (from m in config.Extensions
							   where String.Compare(m.Extension, extension, StringComparison.InvariantCultureIgnoreCase) == 0
							   select m)
							   .FirstOrDefault();

			return mimeSetting?.Mime;
		}
	}
}
