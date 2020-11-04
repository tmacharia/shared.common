using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Represents a custom Http Handler.
    /// </summary>
    public class HttpHandler : IBaseInterface, IHttpHandler
    {
        private HttpClient _client;
        /// <summary>
        /// Parameter-less constructor that instanciates internal <see cref="HttpClient"/>
        /// </summary>
        public HttpHandler()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// Get or access the current <see cref="HttpClient"/> instance.
        /// </summary>
        public HttpClient Client
        {
            get
            {
                if (_client == null)
                    _client = new HttpClient();
                return _client;
            }
        }
        /// <summary>
        /// Constructor that instaciates the internal <see cref="HttpClient"/> with a custom
        /// <see cref="HttpClientHandler"/>
        /// </summary>
        /// <param name="httpClientHandler"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public HttpHandler(HttpClientHandler httpClientHandler)
        {
            if (httpClientHandler == null)
                throw new ArgumentNullException(nameof(httpClientHandler));

            _client = new HttpClient(httpClientHandler);
        }
        /// <summary>
        /// Base/Root Address
        /// </summary>
        public Uri BaseAddress
        {
            get
            {
                return Client.BaseAddress;
            }
            set
            {
                Client.BaseAddress = value;
            }
        }
        /// <summary>
        /// Adds a header item to the default request headers.
        /// </summary>
        /// <param name="key">Header name</param>
        /// <param name="value">Header value</param>
        public void AddHeader(string key, string value)
        {
            Client.DefaultRequestHeaders.Add(key, value);
        }
        /// <summary>
        /// Runs a Http GET request.
        /// </summary>
        /// <param name="uri">Uri resource/route</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return Client.GetAsync(uri);
        }
        /// <summary>
        /// Runs a Http POST request
        /// </summary>
        /// <param name="uri">Uri resource/route</param>
        /// <param name="content">Body content to post.</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content)
        {
            return Client.PostAsync(uri, content);
        }
        /// <summary>
        /// Dispose the current instance.
        /// </summary>
        /// <param name="isDisposing"></param>
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                base.DisposeItem(ref _client);
            }
        }
    }
}