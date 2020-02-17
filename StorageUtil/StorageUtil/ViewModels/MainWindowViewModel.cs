using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private IEventAggregator _messageBus = null;
		private SubscriptionToken _closeFlyoutMessage = null;


		public MainWindowViewModel(ILoggerFacade logService, IEventAggregator messageBus)
			: base(logService)
		{
			_messageBus = messageBus;

			InitializeMessaging();
		}


		#region messaging

		private void InitializeMessaging()
		{
			var msg = _messageBus.GetEvent<Messages.CloseFlyoutMessage>();
			_closeFlyoutMessage = msg.Subscribe((a) =>
			{
				switch(a.Flyout)
				{
					case Messages.FlyoutEnum.ConnectionString:
						IsConnectionStringOpen = false;
						break;
				}
			});
		}


		#endregion

		#region properties

		private bool _isConnectionStringOpen = false;
		public bool IsConnectionStringOpen
		{
			get => _isConnectionStringOpen;
			set => SetProperty<bool>(ref _isConnectionStringOpen, value);
		}

		private bool _isSettingsOpen = false;
		public bool IsSettingsOpen
		{
			get => _isSettingsOpen;
			set => SetProperty<bool>(ref _isSettingsOpen, value);
		}


		#endregion

		#region CommandOpenConnectionString

		private DelegateCommand _commandOpenConnectionString = null;
		public DelegateCommand CommandOpenConnectionString =>
			_commandOpenConnectionString ?? (_commandOpenConnectionString = new DelegateCommand(CommandOpenConnectionStringExecute));


		private void CommandOpenConnectionStringExecute()
		{
			IsConnectionStringOpen = true;
		}

		#endregion

		#region OpenSettings

		private DelegateCommand _commandOpenSettings = null;
		public DelegateCommand CommandOpenSettings =>
			_commandOpenSettings ?? (_commandOpenSettings = new DelegateCommand(CommandOpenSettingsExecute));


		private void CommandOpenSettingsExecute()
		{
			IsSettingsOpen = true;
		}

		#endregion


	}
}
