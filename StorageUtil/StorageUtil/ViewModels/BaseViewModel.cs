using Prism.Logging;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.ViewModels
{
	public abstract class BaseViewModel : BindableBase
	{
		public ILoggerFacade LogService { get; private set; }


		public BaseViewModel(ILoggerFacade logService)
		{
			LogService = logService;
		}
	}
}
