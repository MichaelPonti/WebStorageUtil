using Prism.Commands;
using Prism.Logging;
using StorageUtil.Services.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			MimeTypes.Clear();
			if (settings != null && settings.FileTypes != null)
			{
				foreach (var item in settings.FileTypes)
					MimeTypes.Add(new MimeTypeItemViewModel(item.FileExtension, item.MimeType));
			}
		}


		#endregion

		#region properties

		public ObservableCollection<MimeTypeItemViewModel> MimeTypes { get; private set; } =
			new ObservableCollection<MimeTypeItemViewModel>();

		private MimeTypeItemViewModel _selectedMimeType = null;
		public MimeTypeItemViewModel SelectedMimeType
		{
			get => _selectedMimeType;
			set
			{
				if (SetProperty<MimeTypeItemViewModel>(ref _selectedMimeType, value))
				{

				}
			}
		}

		#endregion


		#region CommandSave implementation

		private DelegateCommand _commandSave = null;
		public DelegateCommand CommandSave =>
			_commandSave ?? (_commandSave = new DelegateCommand(CommandSaveExecute));

		private void CommandSaveExecute()
		{

		}


		#endregion

		#region CommandOpenDir

		private DelegateCommand _commandOpenDir = null;
		public DelegateCommand CommandOpenDir =>
			_commandOpenDir ?? (_commandOpenDir = new DelegateCommand(CommandOpenDirExecute));


		private void CommandOpenDirExecute()
		{
			string d = _settingsService.SettingsDirectory;
			System.Diagnostics.Process.Start(d);
		}

		#endregion
	}
}
