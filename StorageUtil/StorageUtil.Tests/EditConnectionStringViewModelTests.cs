using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Events;
using Prism.Logging;
using StorageUtil.ViewModels;
using Unity;

namespace StorageUtil.Tests
{
	[TestClass]
	public class EditConnectionStringViewModelTests
	{
		private UnityContainer _container = null;
		private IEventAggregator _messageBus = null;
		private ILoggerFacade _logger = null;

		private EditConnectionStringViewModel _viewmodel = null;

		[TestInitialize]
		public void Initialize()
		{
			_container = new UnityContainer();
			_messageBus = new EventAggregator();
			_logger = new EmptyLogger();

			_container.RegisterInstance<IEventAggregator>(_messageBus);
			_container.RegisterInstance<ILoggerFacade>(_logger);

			_viewmodel = _container.Resolve<EditConnectionStringViewModel>();
		}

		[TestMethod]
		public void TestCancelButton()
		{
			bool canCancel = _viewmodel.CommandCancel.CanExecute();
			Assert.IsTrue(canCancel, "cancel button should always be enabled");
		}

		[TestMethod]
		public void TestDoneButton()
		{
			bool canExecute = _viewmodel.CommandDone.CanExecute();
			Assert.IsFalse(canExecute, "no connection string, shouldn't be enabled");

			_viewmodel.ConnectionString = "test connection string";
			canExecute = _viewmodel.CommandDone.CanExecute();
			Assert.IsTrue(canExecute, "there is a connection string, should be enabled");
		}
	}
}
