using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace BIG.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : ContentPage
	{
		public Master ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            buttonA.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new A());
            };
            buttonB.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new B());
            };
            buttonC.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new C());
            };
            buttonD.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new Claves());
            };
            buttonF.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new D());
            };
            buttonG.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new Comunicados());
            };
         
            
        }
        // h button
       async void Bornto(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), Navigation.NavigationStack.First());
            await Navigation.PopAsync();

        }
      

    }
}