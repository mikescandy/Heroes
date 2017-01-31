using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Heroes
{
	public partial class TabPage : ContentPage
	{
		public TabPage ()
		{
			InitializeComponent ();
		}

		public void UpdateLabel ()
		{
			Label.Text = string.Format (Label.Text, Title);
		}
	}
}

