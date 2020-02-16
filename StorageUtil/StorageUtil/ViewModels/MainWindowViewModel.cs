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
		public MainWindowViewModel(ILoggerFacade logService)
			: base(logService)
		{

		}
	}
}
