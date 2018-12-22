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
	public partial class Claves : ContentPage
	{
        private OneTimePassword otp;
        private Codigo codigo;
        public Claves ()
		{
           
            InitializeComponent ();
            otp = new OneTimePassword("jbsw y3dp ehpk 3pxp");
            tmrUpdate(null, null);

            lblfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
		}

        private void tmrUpdate(object sender, System.EventArgs e)
        {
            if (otp != null)
            {
                CountDown();
            }
            else
            {

            }
        }

        private void CountDown() { System.Timers.Timer timer = new System.Timers.Timer(); timer.Interval = 1000; timer.Elapsed += OnTimedEvent; timer.Enabled = true; }
        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                String vir = otp.GetCode().ToString("000000");
                codigo = new Codigo();
                codigo.Code = vir;

                BindingContext = codigo;
            });

        }



    }
}