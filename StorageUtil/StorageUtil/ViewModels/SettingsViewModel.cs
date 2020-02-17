using Prism.Logging;
using StorageUtil.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.ViewModels
{
	public class SettingsViewModel : BaseViewModel
	{
		private ISettingsService _settingsService = null;

		public SettingsViewModel(ILoggerFacade logService, ISettingsService settingsService)
			: base(logService)
		{
			_settingsService = settingsService;
		}


		#region LoadAction

		private ViewUtils.DelegateViewLoadedAction _loadAction = null;
		public ViewUtils.DelegateViewLoadedAction LoadAction =>
			_loadAction ?? (_loadAction = new ViewUtils.DelegateViewLoadedAction(LoadActionExecute));

		private async void LoadActionExecute()
		{
			var settings = await _settingsService.ReadSettingsAsync();
		}


		#endregion
	}
}
