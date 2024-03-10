using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace RestClient.Client
{
    public class SecurityTokenApplicationClient<Tipo>
    {
        string urlApi;
        public SecurityTokenApplicationClient(string urlApi)
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
        public Tipo getSecurityToken(string token)
        {
            try
            {
                Tipo securityToken;
                string uri = urlApi + "/securityToken?token=" + token;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@uri);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    securityToken = JsonConvert.DeserializeObject<Tipo>(json);
                }
                return securityToken;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }
    }
}
