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
	public partial class Patio : MasterDetailPage
	{
        public List<MasterPageItem> menuList { get; set; }
        public List<MasterPageItem> segundalista { get; set; }
        public Patio ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            menuList = new List<MasterPageItem>();
            segundalista = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Existencias LRG", Icon = "itemIcon1.png", TargetType = typeof(A) };
            var page2 = new MasterPageItem() { Title = "Existencias CLT", Icon = "itemIcon2.png", TargetType = typeof(B) };
            var page3 = new MasterPageItem() { Title = "Existencias Promotires", Icon = "itemIcon3.png", TargetType = typeof(C) };
            var page4 = new MasterPageItem() { Title = "Existencias Prollantas", Icon = "itemIcon4.png", TargetType = typeof(D) };
            var page5 = new MasterPageItem() { Title = "Claves", Icon = "itemIcon5.png", TargetType = typeof(Claves) };
            var page6 = new MasterPageItem() { Title = "Comunicados", Icon = "itemIcon7.png", TargetType = typeof(Comunicados) };
            var page7 = new MasterPageItem() { Title = "Salir", Icon = "itemIcon7.png", TargetType = typeof(Comunicados) };

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);
            
            segundalista.Add(page7);
            caspio.ItemsSource = segundalista;


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Detail)));
        }
        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;

            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
        async void OnSegundo(object sender, SelectedItemChangedEventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), Navigation.NavigationStack.First());
            await Navigation.PopAsync();

        }

    }
}