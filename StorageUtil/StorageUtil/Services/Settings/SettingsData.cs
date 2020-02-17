using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.Services.Settings
{
	public class SettingsData
	{
		public List<FileSetting> FileTypes { get; set; } =
			new List<FileSetting>();
	}
}
