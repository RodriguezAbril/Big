using System;
using Android.OS;
using BIG.Mobile.Views;
using System.IO;
using Xamarin.Forms;
using BIG.Mobile.Droid;


[assembly:Dependency(typeof(LocalFileHelper))]
namespace BIG.Mobile.Droid
{
    public class LocalFileHelper : ILocalFileHelper
    {
      public string GetLocalFilePath(string filename)
        {
            string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
