using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageUtil
{
	class Config
	{
		[JsonProperty("extensions")]
		List<MimeType> Extensions { get; set; }
	}
}
