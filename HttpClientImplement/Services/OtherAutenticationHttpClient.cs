using System.Net;
using System.Net.Http.Headers;
using System.Text;


namespace HttpClientImplement.Services
{
    public class OtherAutenticationHttpClient
    {

        public HttpClient NetworkCredential()
        {
            //  return new HttpClient(new HttpClientHandler() { Credentials = new NetworkCredential("myuser", "mypassword", "mydomain") });
            // or

            var webRequestHandler = new HttpClientHandler();
            CredentialCache creds = new CredentialCache();
            creds.Add(new Uri("/"), "basic", new NetworkCredential("user", "password"));
            webRequestHandler.Credentials = creds;
            return new HttpClient(webRequestHandler);

        }
        public HttpClient BasicCredential()
        {
            var client = new HttpClient();

            var encoding = new ASCIIEncoding();
            var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(encoding.GetBytes(string.Format("{0}:{1}", "username", "password"))));
            client.DefaultRequestHeaders.Authorization = authHeader;
            // Now, the Authorization header will be sent along with every request, containing the username and password.
            return client;

        }

        public HttpClient BasicCredential2()
        {
            var client = new HttpClient();

            var byteArray = Encoding.ASCII.GetBytes("MyUSER:MyPASS");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            return client;

        }




    }
}
