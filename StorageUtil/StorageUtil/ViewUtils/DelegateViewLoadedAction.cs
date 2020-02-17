using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.ViewUtils
{
	public class DelegateViewLoadedAction : IViewLoadedAction
	{
		public Action LoadedActionDelegate { get; set; }

		protected DelegateViewLoadedAction()
		{
		}

		public DelegateViewLoadedAction(Action action)
		{
			LoadedActionDelegate = action;
		}

		public void ViewLoaded()
		{
			LoadedActionDelegate?.Invoke();
		}
	}
}
