using System.Net;
using Newtonsoft.Json;

namespace ventasPymesClient.Service
{
    public class BaseService
    {
        public BaseService() { }

        protected async Task<string> getJsonResponseFromGetEnpointAsync(HttpWebRequest request)
        {
            try
            {              
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected Tipo mappingFromJson<Tipo>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Tipo>(json);
            }
            catch (Exception)
            {

                throw;
            }            
        }

    }
}
