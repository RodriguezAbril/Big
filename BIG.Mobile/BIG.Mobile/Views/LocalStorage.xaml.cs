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
	public partial class LocalStorage : ContentPage
	{
      
        public LocalStorage ()
		{
			InitializeComponent ();
          
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ProductListView.ItemsSource = await App.Database.GetProductAsync();
        }


        
      

        

        
    }
}