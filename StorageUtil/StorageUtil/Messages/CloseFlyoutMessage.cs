using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.Messages
{
	public enum FlyoutEnum
	{
		ConnectionString,
	}


	public sealed class CloseFlyoutMessageArgs
	{
		public FlyoutEnum Flyout { get; private set; }
		public object Data { get; private set; }

		public CloseFlyoutMessageArgs(FlyoutEnum flyout, object data = null)
		{
			Flyout = flyout;
			Data = data;
		}
	}


	public sealed class CloseFlyoutMessage : PubSubEvent<CloseFlyoutMessageArgs>
	{
	}
}
