using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace BIG.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Denuncia : ContentPage
	{
        DenunciaItemManager manager;
        EmpleadoManager namagor;

        public Denuncia()
        {

            InitializeComponent();
            manager = DenunciaItemManager.DefaultManager;
            namagor = EmpleadoManager.DefaultManager;
          

            if (!CrossConnectivity.Current.IsConnected)
            {
                ToolbarItems.Add(new ToolbarItem("Search", "wcon.png", () =>
                  {
                      errorcnt.IsVisible = false;

                  }));
              
            }
            
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

             protected override async void OnAppearing()
             {
                     base.OnAppearing();
                     await RefreshItems(true, syncItems: true);
                     await RefreshItems2(true, syncItems: true);
                     modepicker.ItemsSource = await namagor.GetTodoItemsAsync();



             }



        async Task AddItem(DenunciaItem item)
        {
            await manager.SaveTaskAsync(item);
            var night = await manager.GetTodoItemsAsync();

        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            ToolbarItems.Clear();
        }

        public async void OnAdd(object sender, EventArgs e)
        {
            var denu = newItemName.Text;
            if (string.IsNullOrEmpty(denu))
            {
                await DisplayAlert("Error", "Debe de ingresar su denuncia o comentario", "OK");
            }


            else
            {

                if (switcher.IsToggled)
                {
                    var stroke = newContacto.Text;
                    if (string.IsNullOrEmpty(stroke))
                    {
                        await DisplayAlert("Error", "Ingrese un correo de contacto", "OK");
                    }
                    else
                    {
                        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match match = regex.Match(stroke);
                        if (match.Success)
                        {
                            var todo = new DenunciaItem { Denuncia = newItemName.Text, Imputado = modepicker.SelectedItem.ToString(), Contacto = newContacto.Text };
                            await AddItem(todo);
                            await RefreshItems(true, syncItems: true);

                            newContacto.Text = string.Empty;
                            newItemName.Text = string.Empty;
                            newItemName.Unfocus();
                            newContacto.Unfocus();

                        }
                        else
                        {
                            await DisplayAlert("Error", "Debe de ingresar un correo valido", "OK");

                        }

                    }

                }
                else
                {
                    var todo = new DenunciaItem { Denuncia = newItemName.Text, Imputado = modepicker.SelectedItem.ToString(), Contacto = newContacto.Text };
                    await AddItem(todo);
                    await RefreshItems(true, syncItems: true);

                    newContacto.Text = string.Empty;
                    newItemName.Text = string.Empty;
                    newItemName.Unfocus();
                    newContacto.Unfocus();

                }

                //var todo = new DenunciaItem { Denuncia = newItemName.Text, Imputado = modepicker.SelectedItem.ToString(), Contacto = newContacto.Text };
                //await AddItem(todo);
                //await RefreshItems(true, syncItems: true);

                //newContacto.Text = string.Empty;
                //newItemName.Text = string.Empty;
                //newItemName.Unfocus();
                //newContacto.Unfocus();




            }

        }

        public void OnToggled(object sender, EventArgs e)
        {
            if (!switcher.IsToggled)
            {
                newContacto.IsVisible = false;

            }
            else
            {
                newContacto.IsVisible = true;

            }

        }

       
        public async void OnSyncItems(object sender, EventArgs e)
        {
            await RefreshItems(true, true);
        }

        private async Task RefreshItems(bool showActivityIndicator, bool syncItems)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                var sorpresa = await manager.GetTodoItemsAsync(syncItems);
            }
        }

        private async Task RefreshItems2(bool showActivityIndicator, bool syncItems)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                modepicker.ItemsSource = await namagor.GetTodoItemsAsync(syncItems);
            }
        }

        private class ActivityIndicatorScope : IDisposable
        {
            private bool showIndicator;
            private ActivityIndicator indicator;
            private Task indicatorDelay;

            public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
            {
                this.indicator = indicator;
                this.showIndicator = showIndicator;

                if (showIndicator)
                {
                    indicatorDelay = Task.Delay(2000);
                    SetIndicatorActivity(true);
                }
                else
                {
                    indicatorDelay = Task.FromResult(0);
                }
            }

            private void SetIndicatorActivity(bool isActive)
            {
                this.indicator.IsVisible = isActive;
                this.indicator.IsRunning = isActive;
            }

            public void Dispose()
            {
                if (showIndicator)
                {
                    indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }

    }

      

    
}