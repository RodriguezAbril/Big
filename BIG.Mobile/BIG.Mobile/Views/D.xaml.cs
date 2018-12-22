using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BIG.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class D : TabbedPage
	{
		public D ()
		{
			InitializeComponent ();
            Children.Add(new D1());
            Children.Add(new D2());
            Children.Add(new D3());
            Children.Add(new D4());
        }
	}
}