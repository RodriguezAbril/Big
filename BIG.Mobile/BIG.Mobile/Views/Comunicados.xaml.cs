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
	public partial class Comunicados : ContentPage
	{
		public Comunicados ()
		{
			InitializeComponent ();
            PdfListView.ItemsSource = GetPdfs();
        }

        private static IEnumerable<PdfDocEntity> GetPdfs()
        {
            return new[]
            {
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/pptdemo2.pdf",
                    FileName = "Comunicado I"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/pptdemo1.pdf",
                    FileName = "Comunicado II"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/xlsdemo2.pdf",
                    FileName = "Comunicado III"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/xlsdemo2.pdf",
                    FileName = "Comunicado IV"
                }
            };
        }

        private void PdfListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e?.SelectedItem == null)
            {
                return;
            }

            var pdfDocEntity = e.SelectedItem as PdfDocEntity;
            if (pdfDocEntity != null)
            {
                Navigation.PushAsync(new PdfDocumentView(pdfDocEntity));
            }

            PdfListView.SelectedItem = null;
        }
    }
}