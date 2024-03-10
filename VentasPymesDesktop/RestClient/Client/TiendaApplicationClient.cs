using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RestClient.Client
{
    public class TiendaApplicationClient<Tipo>
    {
        string urlApi;
        public TiendaApplicationClient(string urlApi)
        {
            try
            {
                this.urlApi = urlApi;
            }
            catch (Exception ex)            
            {
                throw new Exception(ex.Message);
            }            
        }      
      
    }
}
