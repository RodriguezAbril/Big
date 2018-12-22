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
	public partial class C : TabbedPage
    {
		public C ()
		{
			InitializeComponent ();
            Children.Add(new C1());
            Children.Add(new C2());
            Children.Add(new C3());
            Children.Add(new C4());
        }
	}
}