using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GameBTsite
{
    public class RequestHelper
    {
        public static string Root = "http://192.168.0.167/";
        public static string baseUrl = $"{Root}api";
        
        public async static Task<ResponseType> MakeGetRequest<ResponseType>(string parameters)
        {
          
            using (var client = new HttpClient())
            {
                
               

                var response = await client.GetAsync(string.Format("{0}/{1}", baseUrl , parameters));

                var responseString = await response.Content.ReadAsStringAsync();

               

                return JsonConvert.DeserializeObject<ResponseType>(responseString);
            }
        }
        public async static Task<ResponseType> MakePostRequest<ResponseType>(string path, object request)
        {
            
            using (var client = new HttpClient())
            {
               

                var json = JsonConvert.SerializeObject(request);

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(string.Format("{0}/{1}", baseUrl, path), byteContent);

                var responseString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ResponseType>(responseString);
            }
        }

    }
}