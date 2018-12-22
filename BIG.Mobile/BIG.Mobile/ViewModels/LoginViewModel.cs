using System;
using System.Collections.Generic;
using System.Text;
using BIG.Mobile.Services;
using Xamarin.Forms;
using System.Windows.Input;
using BIG.Mobile.Views;
using System.Threading.Tasks;

namespace BIG.Mobile.ViewModels
{
    public class LoginViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    // await  _apiServices.LoginAsync(Username, Password);
                    try
                    {
                        var isSuccess = await _apiServices.LoginAsync(Username, Password);
                        if (isSuccess)
                        {
                            Message = "Login OK";
                             App.Current.MainPage = new NavigationPage(new Patio());

                          
                            //Con este funciona 
                            //  App.Current.MainPage = new NavigationPage(new Page2());


                        }

                        else
                        {
                            //DisplayAlert("Alert", "You have been alerted", "OK");
                            await App.Current.MainPage.DisplayAlert("Error", "Debe de proporcionar un usuario y contraseña validos.", "OK");
                            Message = "Error Login";

                        }
                    }

                    catch(Exception e) {

                        Console.WriteLine("{0} Exception caught cachada.", e);
                        await App.Current.MainPage.DisplayAlert("Error", "Revise su conexión", "OK");
                    }
                   

                });

            }
        }
    }
}
