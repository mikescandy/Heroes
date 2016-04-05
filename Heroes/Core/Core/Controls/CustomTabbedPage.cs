using System;
using System.Collections;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Core.Controls
{
	public class CustomTabbedPage:TabbedPage
	{
 
		public static readonly BindableProperty ChildrenListProperty = BindableProperty.Create(
			defaultBindingMode: BindingMode.TwoWay,
			propertyName: "ChildrenList",
			returnType: typeof(IList<Page>),
			declaringType: typeof(CustomTabbedPage),
			propertyChanged: UpdateList,
			defaultValue: new List<Page>());

		public IList<Page> ChildrenList
	{
		get { return (IList<Page>)GetValue(ChildrenListProperty); }
		set { SetValue(ChildrenListProperty, value); }
	}
		 
	private static void UpdateList(BindableObject bindable, object oldValue, object newValue)
	{

			var page = bindable as CustomTabbedPage;
		if (page != null)
		{
			page.Children.Clear();
				foreach (var p in (IList<Page>)newValue)
				page.Children.Add(p);
		}

	}
 }
}
