using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.Services.Settings
{
	public interface ISettingsService
	{
		Task InitializeAsync();
		Task SaveSettingsAsync(SettingsData data);
		Task<SettingsData> ReadSettingsAsync();
	}
}
