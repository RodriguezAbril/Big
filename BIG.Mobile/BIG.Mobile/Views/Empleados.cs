using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BIG.Mobile.Views
{
  public class Empleados
    {

        string id;
        string nombre;
        string empresa;
        bool bajalogica;
     

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [JsonProperty(PropertyName = "empresa")]
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        [JsonProperty(PropertyName = "bajalogica")]
        public bool Bajalogica
        {
            get { return bajalogica; }
            set { bajalogica = value; }
        }


    }
}
