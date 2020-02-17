using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.Services.Settings
{
	public class FileSetting
	{
		public string FileExtension { get; set; }
		public string MimeType { get; set; }


		public FileSetting()
		{
		}

		public FileSetting(string fileExtension, string mimeType)
		{
			FileExtension = fileExtension;
			MimeType = mimeType;
		}
	}
}
