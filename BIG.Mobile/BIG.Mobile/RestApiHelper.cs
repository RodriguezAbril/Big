﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using Plugin.Connectivity;
using System.Net.Http;

namespace BIG.Mobile
{
  public static  class RestApiHelper
    {
        public static async Task<MemoryStream> DownloadFileAsync(string url)
        {
            if (CrossConnectivity.Current.IsConnected == false)
            {
                return null;
            }

            try
            {
                var stream = new MemoryStream();
                using (var httpClient = new HttpClient())
                {
                    var downloadStream = await httpClient.GetStreamAsync(new Uri(url));
                    if (downloadStream != null)
                    {
                        await downloadStream.CopyToAsync(stream);
                    }
                }

                return stream;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }
    }
}