﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlexLayoutInItemTemplatePage : ContentPage
	{
		public FlexLayoutInItemTemplatePage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public List<string> Items { get; } = new List<string> { "aaa", "bbbb", "cc" };

	}
}