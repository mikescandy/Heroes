using System;
using PropertyChanged;

namespace Heroes
{
	[ImplementPropertyChanged]
	public class HomePageViewModel
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public ItemType ItemType { get; set; }

		public string Image { get; set; }

		public string LineOne { get; set; }

		public string LineTwo { get; set; }

		public string LineThree { get; set; }

		public bool IsReal { get; set; }

		public bool IsAdd { get; set; }

		public double TimeStamp { get; set;}

		public HomePageViewModel ()
		{
		}
	}
}

