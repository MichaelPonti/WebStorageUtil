using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageUtil
{
	class MimeType
	{
		public string Extension { get; set; }
		public string Mime { get; set; }

		public MimeType()
		{
		}

		public MimeType(string extension, string mime)
		{
			Extension = extension;
			Mime = mime;
		}
	}
}
