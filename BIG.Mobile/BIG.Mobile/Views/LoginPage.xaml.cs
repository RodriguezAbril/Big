using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using BIG.Mobile.Models;
using BIG.Mobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace BIG.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{

			InitializeComponent ();
            btncomplent.Clicked += Btncomplent_Clicked;
           // NavigationPage.SetHasNavigationBar(this, true);

            if (!CrossConnectivity.Current.IsConnected)
            {
                ToolbarItems.Add(new ToolbarItem("Search", "wcon.png", () =>
                {
                    errorcnt.IsVisible = false;
                }));
          
            }
          

           
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Btncomplent_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Denuncia());
        }
        private void btn_nonow(object sender, EventArgs e)
        {

            EntryEmail.Text = "";
            Password.Text = "";

        }


       //antes private 
     private void Button_OnClicked(object sender, EventArgs e)
        {

            var tres = new LoginViewModel();

            var nombre = EntryEmail.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                //DisplayAlert("Error", "Debe proporcionar un usuario", "OK");
                btnSave.IsEnabled = true;
            }
            else
            {
                var email = EntryEmail.Text;

                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    Errorlabel.Text = "";
                    
               
                }
                else
                {
                    
                    Errorlabel.Text = "Su id. de usuario debería tener la forma de una dirección de correo electrónico, por ejemplo someone@contoso.com ";
                }


            }

            
        }

        

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            ToolbarItems.Clear();
        }
      

        private void btncomplent_Clicked(object sender, EventArgs e)
        {

        }
    }
}