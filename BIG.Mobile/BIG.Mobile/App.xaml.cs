using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Mobile.Views;
using Xamarin.Forms;

using System.Threading.Tasks;


namespace BIG.Mobile
{
	public partial class App : Application
	{
        public static MasterDetailPage MasterDetail { get; set; }
        public static bool IsUserLoggedIn { get; set; }
        public async static Task NavigateMasterDetail(Page page)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(page);
        }
        static ProductDatabase database;
        public App ()
		{
           
            InitializeComponent();
            if (!IsUserLoggedIn)
            {
               MainPage = new NavigationPage(new LoginPage());
            
            }
            else
            {
                 MainPage = new NavigationPage(new BIG.Mobile.Views.Page2());
              //  MainPage = new NavigationPage(new BIG.Mobile.Views.Patio());
            }

            // MainPage = new NavigationPage(new LoginPage());

            //  MainPage = new NavigationPage(new Page2());

        }

        public static ProductDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProductDatabase(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("EmployeeDb.db3"));
                }
                return database;
            }
        }

        protected override void OnStart ()
		{
          
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
