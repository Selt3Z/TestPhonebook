﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhotoFullscreen : ContentPage
	{
		public PhotoFullscreen (object bindingContext)
		{
			InitializeComponent ();
            BindingContext = bindingContext;
        }
	}
}