using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;


namespace BIG.Mobile.Views
{
   public  class DenunciaItem
    {
        string id;
        string denuncia;
        string contacto;
        bool status;
        int prioridad;
        string imputado;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "denuncia")]
        public string Denuncia
        {
            get { return denuncia; }
            set { denuncia = value; }
        }

        [JsonProperty(PropertyName = "contacto")]
        public string Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        [JsonProperty(PropertyName = "status")]
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        [JsonProperty(PropertyName = "prioridad")]
        public int Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        [JsonProperty(PropertyName = "imputado")]
        public string Imputado
        {
            get { return imputado; }
            set { imputado = value; }
        }

        [Version]
        public string Version { get; set; }

    }
}
