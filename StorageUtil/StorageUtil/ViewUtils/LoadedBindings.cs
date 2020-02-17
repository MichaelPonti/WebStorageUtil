using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StorageUtil.ViewUtils
{
	public sealed class LoadedBindings
	{
		public static readonly DependencyProperty LoadActionProperty =
			DependencyProperty.RegisterAttached(
				"LoadAction",
				typeof(IViewLoadedAction),
				typeof(LoadedBindings),
				new PropertyMetadata(null, new PropertyChangedCallback(OnLoadActionSet)));

		private static void OnLoadActionSet(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (sender is Window w)
			{
				if (e.OldValue != null && e.NewValue == null)
					w.Loaded -= WindowLoaded;
				else if (e.OldValue == null && e.NewValue != null)
					w.Loaded += WindowLoaded;
			}
			else if (sender is UserControl v)
			{
				if (e.OldValue != null && e.NewValue == null)
					v.Loaded -= ViewLoaded;
				else if (e.OldValue == null && e.NewValue != null)
					v.Loaded += ViewLoaded;
			}
		}

		private static void WindowLoaded(object sender, RoutedEventArgs e)
		{
			IViewLoadedAction action = GetLoadAction((Window) sender);
			action?.ViewLoaded();
		}

		private static void ViewLoaded(object sender, RoutedEventArgs e)
		{
			IViewLoadedAction action = GetLoadAction((UserControl) sender);
			action?.ViewLoaded();
		}

		public static IViewLoadedAction GetLoadAction(DependencyObject o) =>
			(IViewLoadedAction) o.GetValue(LoadActionProperty);

		public static void SetLoadAction(DependencyObject o, IViewLoadedAction action) =>
			o.SetValue(LoadActionProperty, action);
	}
}
