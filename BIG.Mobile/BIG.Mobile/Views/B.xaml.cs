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
	public partial class B : TabbedPage
    {
		public B ()
		{
			InitializeComponent ();
            
            Children.Add(new B1());
            Children.Add(new B2());
            Children.Add(new B3());
            Children.Add(new B4());
        }
	}
}