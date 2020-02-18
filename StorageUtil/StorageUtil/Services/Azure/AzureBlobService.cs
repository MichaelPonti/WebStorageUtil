using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.Services.Azure
{
	public class AzureBlobService
	{
		private string _connectionString = null;

		public void SetConnectionString(string connectionString) =>
			_connectionString = connectionString;


		public List<string> LoadBlobs()
		{
			if (String.IsNullOrWhiteSpace(_connectionString))
				throw new InvalidOperationException("need a connection string");

			List<string> ret = new List<string>();

			var storageAccount = CloudStorageAccount.Parse(_connectionString);
			var blobClient = storageAccount.CreateCloudBlobClient();

			var blobs = blobClient
				.GetContainerReference("$web")
				.ListBlobs(useFlatBlobListing: true)
				.OfType<CloudBlockBlob>();

			foreach(var blob in blobs)
			{
				ret.Add(blob.Uri.AbsoluteUri);
			}

			return ret;
		}
	}
}
