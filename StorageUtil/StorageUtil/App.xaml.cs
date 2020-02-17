using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;


namespace StorageUtil
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		public App()
		{

		}



		private void RegisterAppViews()
		{
			var regionManager = Container.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("editConnectionStringView", typeof(Views.EditConnectionStringView));
		}


		protected override Window CreateShell()
		{
			RegisterAppViews();

			var w = Container.Resolve<Views.MainWindow>();
			return w;
		}


		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<Views.EditConnectionStringView>();
		}
	}
}
