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
	public partial class A : TabbedPage
	{
		public A ()
		{
            InitializeComponent();
            Children.Add(new A1());
            Children.Add(new A2());
            Children.Add(new A3());
            Children.Add(new A4());
		}
	}
}