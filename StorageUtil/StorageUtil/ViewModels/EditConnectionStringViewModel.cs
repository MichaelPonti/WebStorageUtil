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
	public class EditConnectionStringViewModel : BaseViewModel
	{
		private IEventAggregator _messageBus = null;


		public EditConnectionStringViewModel(ILoggerFacade logService, IEventAggregator messageBus)
			: base(logService)
		{
			_messageBus = messageBus;
		}


		#region properties

		private string _connectionString = null;
		public string ConnectionString
		{
			get => _connectionString;
			set
			{
				if (SetProperty<string>(ref _connectionString, value))
				{
					CommandDone.RaiseCanExecuteChanged();
				}
			}
		}

		#endregion


		#region CommandDone

		private DelegateCommand _commandDone = null;
		public DelegateCommand CommandDone =>
			_commandDone ?? (_commandDone = new DelegateCommand(CommandDoneExecute, CommandDoneCanExecute));


		private void CommandDoneExecute()
		{
			var msg = _messageBus.GetEvent<Messages.CloseFlyoutMessage>();
			msg.Publish(new Messages.CloseFlyoutMessageArgs(Messages.FlyoutEnum.ConnectionString, ConnectionString));
		}

		private bool CommandDoneCanExecute()
		{
			return !String.IsNullOrWhiteSpace(ConnectionString);
		}


		#endregion


		#region CommandCancel

		private DelegateCommand _commandCancel = null;
		public DelegateCommand CommandCancel =>
			_commandCancel ?? (_commandCancel = new DelegateCommand(CommandCancelExecute));

		private void CommandCancelExecute()
		{
			var msg = _messageBus.GetEvent<Messages.CloseFlyoutMessage>();
			msg.Publish(new Messages.CloseFlyoutMessageArgs(Messages.FlyoutEnum.ConnectionString));
		}

		#endregion
	}
}
