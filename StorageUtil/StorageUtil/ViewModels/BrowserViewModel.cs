using Prism.Events;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.ViewModels
{
	public class BrowserViewModel : BaseViewModel
	{
		private IEventAggregator _messageBus = null;
		private SubscriptionToken _flyoutMessageToken = null;


		public BrowserViewModel(ILoggerFacade logService, IEventAggregator messageBus)
			: base(logService)
		{
			_messageBus = messageBus;

			InitializeMessaging();
		}


		private void InitializeMessaging()
		{
			var flyoutMessage = _messageBus.GetEvent<Messages.CloseFlyoutMessage>();
			_flyoutMessageToken = flyoutMessage.Subscribe(HandleCloseFlyoutMessage);
		}

		private void HandleCloseFlyoutMessage(Messages.CloseFlyoutMessageArgs args)
		{
			switch(args.Flyout)
			{
				case Messages.FlyoutEnum.ConnectionString:
					string connectionString = (string) args.Data;
					if (!String.IsNullOrWhiteSpace(connectionString))
						RefreshBlobListing(connectionString);
					break;
			}
		}


		private void RefreshBlobListing(string connectionString)
		{
			Services.Azure.AzureBlobService bs = new Services.Azure.AzureBlobService();
			bs.SetConnectionString(connectionString);
			var blobs = bs.LoadBlobs();
			foreach (var blob in blobs)
				LogService.Log(blob, Category.Info, Priority.None);
		}
	}
}
