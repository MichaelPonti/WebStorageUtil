using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.ViewModels
{
	public abstract class BaseItemViewModel : BindableBase
	{
		public IEventAggregator MessageBus { get; private set; }


		public BaseItemViewModel()
		{
		}

		public BaseItemViewModel(IEventAggregator messageBus)
		{
			MessageBus = messageBus;
		}


		protected virtual void OnChecked(bool newValue)
		{
		}

		protected virtual void OnSelected(bool newValue)
		{
		}


		private bool _isChecked = false;
		public bool IsChecked
		{
			get => _isChecked;
			set
			{
				if (SetProperty<bool>(ref _isChecked, value))
					OnChecked(_isChecked);
			}
		}

		private bool _isSelected = false;
		public bool IsSelected
		{
			get => _isSelected;
			set
			{
				if (SetProperty<bool>(ref _isSelected, value))
					OnSelected(_isSelected);
			}
		}
	}
}
