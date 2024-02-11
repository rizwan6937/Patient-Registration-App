using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
namespace MVC.Models
{
    public static class GlobalModel
    {
        //public static HttpClient client = new HttpClient();
        //static GlobalModel()
        //{
        //    client.BaseAddress = new Uri("http://localhost:5104/api/");
        //    client.DefaultRequestHeaders.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //}


        public static HttpClient client;

        static GlobalModel()
        {
            InitializeHttpClient();
        }

        public static void InitializeHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5104/api/patient");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
